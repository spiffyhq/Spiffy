using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Spiffy
{
    public partial class SpiffyPopup : Form
    {
        #region SpiffyNotifier Protected Members
        protected Bitmap BackgroundBitmap;

        protected Rectangle WorkAreaRectangle;

        protected string titleText;
        protected string timeText;
        protected string nameText;
        protected string subjectText;
        protected string contentText;
        protected string contentUrl; //047 url for alert message link

        protected Color ColorBlack = Color.FromArgb(0, 0, 0);
        protected Color ColorSpiffy = Color.FromArgb(0, 120, 0);

        protected FontStyle fs_Normal = FontStyle.Regular;
        protected FontStyle fs_Bold = FontStyle.Regular | FontStyle.Bold;
        protected FontStyle fs_Italic = FontStyle.Regular | FontStyle.Italic;
        protected FontStyle fs_BoldItalic = FontStyle.Regular | FontStyle.Italic | FontStyle.Bold;
        
        protected TaskbarStates taskbarState = TaskbarStates.hidden;
        protected int nShowEvents;
        protected int nHideEvents;
        protected int nVisibleEvents;
        protected int nIncrementShow;
        protected int nIncrementHide;

        protected bool bIsMouseOverContent = false;
        protected bool bIsMouseOverClose = false;
        
        protected bool bIsMouseDown = false;
        protected bool bIsMouseOverPopup = false;
        protected bool bKeepVisibleOnMouseOver = true;
        protected bool bReShowOnMouseOver = false;

        protected bool bAppearBySliding = true;
        protected bool bIsCustom = Properties.Settings.Default.AppEnableCustomAlerts;

        protected int nPadding = 10;

        protected int nBaseWindowBottom = 0;
        protected int nBaseWindowRight = 0;

        #endregion

        #region SpiffyNotifier Public Members
        public Rectangle TitleRectangle;
        public Rectangle TimeRectangle;
        public Rectangle NameRectangle;
        public Rectangle SubjectRectangle;
        public Rectangle ContentRectangle;
        public Rectangle CloseRectangle;
        public Font CustomFont;
        public bool CloseClickable = true;
        public bool ContentClickable = true;
        //public event EventHandler CloseClick = null;
        //public event EventHandler ContentClick = null; //046
        public event EventHandler<SpiffyAlertEventArgs> ContentClick = null; //047 url for alert message link
                
        #endregion

        #region SpiffyNotifier Constructor
        public SpiffyPopup()
        {
            InitializeComponent();

            //SET RTL LAYOUT FOR HEBREW
            /*if (Properties.Settings.Default.AppLocale == "Hebrew")
            {
                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;
            }*/

            base.Hide();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = false;

            timer.Enabled = true;
            timer.Tick += new EventHandler(OnTimer);            
        }
        #endregion

        #region SpiffyNotifier Enums
        /// <summary>
        /// List of the different popup animation status
        /// </summary>
        public enum TaskbarStates
        {
            hidden = 0,
            appearing = 1,
            visible = 2,
            disappearing = 3
        }
        #endregion

        #region SpiffyNotifier Properties
        /// <summary>
        /// Get the current TaskbarState (hidden, showing, visible, hiding)
        /// </summary>
        public TaskbarStates TaskbarState
        {
            get
            {
                return taskbarState;
            }
        }

        /// <summary>
        /// Indicates if the popup should remain visible when the mouse pointer is over it.
        /// Added Rev 002
        /// </summary>
        public bool KeepVisibleOnMousOver
        {
            get
            {
                return bKeepVisibleOnMouseOver;
            }
            set
            {
                bKeepVisibleOnMouseOver = value;
            }
        }

        /// <summary>
        /// Indicates if the popup should appear again when mouse moves over it while it's disappearing.
        /// Added Rev 002
        /// </summary>
        public bool ReShowOnMouseOver
        {
            get
            {
                return bReShowOnMouseOver;
            }
            set
            {
                bReShowOnMouseOver = value;
            }
        }

        /// <summary>
        /// Indicates if the popup should diplayed with fadding or slidding effect
        /// Added Rev 003-CAS
        /// </summary>
        public bool AppearBySliding
        {
            get
            {
                return bAppearBySliding;
            }
            set
            {
                bAppearBySliding = value;
            }
        }
        /// <summary>
        /// Get/Set the popup padding (distance between 2 popups)
        /// Added Rev 004-CAS: New Property: Padding
        /// </summary>
        public new int Padding
        {
            get
            {
                return nPadding;
            }
            set
            {
                nPadding = value;
                Refresh();
            }
        }
        /// <summary>
        /// Get/Set the popup distance from the working area bottom border due to popup stacking
        /// Added Rev 005-CAS: New feature: Management of Toasts' Collection and last position storage
        /// </summary>
        public int BaseWindowBottom
        {
            get
            {
                return nBaseWindowBottom;
            }
            set
            {
                nBaseWindowBottom = value;
                Refresh();
            }
        }
        /// <summary>
        /// Get/Set the popup distance from the working area right border due to popup stacking
        /// Added Rev 005-CAS: New feature: Management of Toasts' Collection and last position storage
        /// </summary>
        public int BaseWindowRight
        {
            get
            {
                return nBaseWindowRight;
            }
            set
            {
                nBaseWindowRight = value;
                Refresh();
            }
        }
        #endregion

        #region SpiffyNotifier Public Methods
        internal static class NativeMethods
        {            
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool SetWindowPos(IntPtr hWnd,
              Int32 hWndInsertAfter, Int32 X, Int32 Y, Int32 cx, Int32 cy, uint uFlags);
        }

        private static int m_MessageNo = 0; //spiffy

        /// <summary>
        /// Displays the popup for a certain amount of time
        /// </summary>
        /// <param name="strTitle">The string which will be shown as the title of the popup</param>
        /// <param name="strContent">>The string which will be shown as the content of the popup</param>
        /// <param name="nTimeToShow">Duration of the showing animation (in milliseconds)</param>
        /// <param name="nTimeToStay">Duration of the visible state before collapsing (in milliseconds)</param>
        /// <param name="nTimeToHide">Duration of the hiding animation (in milliseconds)</param>
        /// <returns>Nothing</returns>
        public void Show(string strAccountName, string alertUrl, string strName, string strEmail,
            string strSubject, string strMessage, string strTime, int nTimeToShow, int nTimeToStay, int nTimeToHide)
        {
            WorkAreaRectangle = Screen.GetWorkingArea(WorkAreaRectangle);            

            if (Properties.Settings.Default.AppAlertsStackAlerts) // (default)
            {
                WorkAreaRectangle.Y = WorkAreaRectangle.Y - (m_MessageNo++) * BackgroundBitmap.Height;
                nVisibleEvents = nTimeToStay;
            }
            else //on top of each other 
            {
                //Set Y to bottem
                WorkAreaRectangle.Y = 0;
                nVisibleEvents = nTimeToStay;
                //Increase message nr
                m_MessageNo++;
            }           

            //Fill the areas with text <- PRETTY CRITICAL
            titleText = strAccountName;
            nameText = strName + " (" + strEmail + ")";

            //check if subject is not empty
            if (String.IsNullOrEmpty(strSubject))
            {
                subjectText = SpiffyText.String00316;
            }
            else
            {
                subjectText = strSubject;
            }

            contentText = strMessage;
            contentUrl = alertUrl;
            timeText = strTime;
            
            // We calculate the pixel increment and the timer value for the showing animation
            int nEvents = 0;
            if (nTimeToShow > 10)
            {
                nEvents = Math.Min((nTimeToShow / 10), BackgroundBitmap.Height);
                nShowEvents = nTimeToShow / nEvents;
                nIncrementShow = BackgroundBitmap.Height / nEvents;
            }
            else
            {
                nShowEvents = 10;
                nIncrementShow = BackgroundBitmap.Height;
            }

            // We calculate the pixel increment and the timer value for the hiding animation
            if (nTimeToHide > 10)
            {
                nEvents = Math.Min((nTimeToHide / 10), BackgroundBitmap.Height);
                nHideEvents = nTimeToHide / nEvents;
                nIncrementHide = BackgroundBitmap.Height / nEvents;
            }
            else
            {
                nHideEvents = 10;
                nIncrementHide = BackgroundBitmap.Height;
            }

            switch (taskbarState)
            {
                case TaskbarStates.hidden:
                    taskbarState = TaskbarStates.appearing;

                    if (bAppearBySliding)
                    {
                        this.Opacity = 1.0;
                        NativeMethods.SetWindowPos(
                            this.Handle,
                            -1,
                            WorkAreaRectangle.Right - BackgroundBitmap.Width - nPadding - nBaseWindowRight,
                            WorkAreaRectangle.Bottom,
                            BackgroundBitmap.Width,
                            0,
                            0x0010
                        );

                    }
                    else //default
                    {
                        this.Opacity = 0.0;
                        NativeMethods.SetWindowPos(
                            this.Handle,
                            -1,
                            WorkAreaRectangle.Right - BackgroundBitmap.Width - nPadding - nBaseWindowRight,
                            WorkAreaRectangle.Bottom - BackgroundBitmap.Height - nPadding - nBaseWindowBottom,
                            BackgroundBitmap.Width,
                            BackgroundBitmap.Height,
                            0x0010
                        );
                    }
                    timer.Interval = nShowEvents;
                    timer.Start();

                    // We Show the popup without stealing focus
                    NativeMethods.ShowWindow(this.Handle, 4);
                    break;

                case TaskbarStates.appearing:
                    Refresh();
                    break;

                case TaskbarStates.visible:
                    timer.Stop();
                    timer.Interval = nVisibleEvents;
                    timer.Start();
                    Refresh();
                    break;

                case TaskbarStates.disappearing:
                    timer.Stop();
                    taskbarState = TaskbarStates.visible;
                    
                    if (bAppearBySliding)
                    {
                        NativeMethods.SetWindowPos(
                            this.Handle,
                            -1,
                            WorkAreaRectangle.Right - BackgroundBitmap.Width - nPadding - nBaseWindowRight,
                            WorkAreaRectangle.Bottom - BackgroundBitmap.Height - nPadding - nBaseWindowBottom,
                            BackgroundBitmap.Width,
                            BackgroundBitmap.Height,
                            0x0010
                        );
                    }
                    else
                    {
                        NativeMethods.SetWindowPos(
                            this.Handle,
                            -1,
                            WorkAreaRectangle.Right - BackgroundBitmap.Width - nPadding - nBaseWindowRight,
                            WorkAreaRectangle.Bottom - nPadding - nBaseWindowBottom,
                            BackgroundBitmap.Width,
                            0,
                            0x0010
                        );
                    }
                    timer.Interval = nVisibleEvents;
                    timer.Start();
                    Refresh();
                    break;
            }
        }

        /// <summary>
        /// Hides the popup
        /// </summary>
        /// <returns>Nothing</returns>
        public new void Hide()
        {
            if (taskbarState != TaskbarStates.hidden)
            {
                timer.Stop();
                m_MessageNo--; //spiffy -> lower count so alerts are shown at the bottem
                taskbarState = TaskbarStates.hidden;
                base.Hide();
                
                //Cleanup
                if (BackgroundBitmap != null)
                {
                    BackgroundBitmap.Dispose();
                    BackgroundBitmap = null;
                }

                if (timer != null)
                {
                    timer.Dispose();
                    timer = null;
                }
                
                if (this != null)
                {
                    this.Dispose();
                }
            }
        }

        /// <summary>
        /// Sets the background bitmap and its transparency color
        /// </summary>
        /// <param name="fileName">>Path of the Background Bitmap on the disk</param>
        /// <param name="transparencyColor">Color of the Bitmap which won't be visible</param>
        /// <returns>Nothing</returns>
        public void SetBackgroundBitmap(string fileName, Color transparencyColor)
        {
            BackgroundBitmap = new Bitmap(fileName);
            Width = BackgroundBitmap.Width;
            Height = BackgroundBitmap.Height;
            Region = BitmapToRegion(BackgroundBitmap, transparencyColor);
        }

        /// <summary>
        /// Sets the background bitmap and its transparency color
        /// </summary>
        /// <param name="image">Image/Bitmap object which represents the Background Bitmap</param>
        /// <param name="transparencyColor">Color of the Bitmap which won't be visible</param>
        /// <returns>Nothing</returns>
        public void SetBackgroundBitmap(Image image, Color transparencyColor)
        {
            BackgroundBitmap = new Bitmap(image);
            Width = BackgroundBitmap.Width;
            Height = BackgroundBitmap.Height;
            Region = BitmapToRegion(BackgroundBitmap, transparencyColor);
        }
        #endregion

        #region SpiffyNotifier Protected Methods

        //Puts the message in the popup
        protected void DrawText(Graphics grfx)
        {
            #region TITLE
            if (titleText != null && titleText.Length != 0)
            {
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;          

                if (bIsCustom)
                {
                    if (Properties.Settings.Default.AppAlertTitleEnabled)
                    {
                        Font cFont;

                        if (Properties.Settings.Default.AppAlertTitleCenter)
                            sf.Alignment = StringAlignment.Center;
                        else sf.Alignment = StringAlignment.Near;

                        if (Properties.Settings.Default.AppAlertTitleBold &&
                            !Properties.Settings.Default.AppAlertTitleItalic)
                            cFont = new Font(CustomFont, fs_Bold);
                        else if (!Properties.Settings.Default.AppAlertTitleBold &&
                            Properties.Settings.Default.AppAlertTitleItalic)
                            cFont = new Font(CustomFont, fs_Italic);
                        else if (Properties.Settings.Default.AppAlertTitleBold &&
                            Properties.Settings.Default.AppAlertTitleItalic)
                            cFont = new Font(CustomFont, fs_BoldItalic);
                        else cFont = new Font(CustomFont, fs_Normal);

                        grfx.DrawString(
                        titleText,
                        cFont,
                        new SolidBrush(
                            Properties.Settings.Default.AppAlertTitleColor),
                            TitleRectangle, sf);
                        //cleanup
                        cFont.Dispose();
                    }
                }
                else //default
                {
                    sf.Alignment = StringAlignment.Center;
                    grfx.DrawString(
                        titleText,
                        new Font("tahoma", 11, FontStyle.Regular | FontStyle.Bold, GraphicsUnit.Pixel),
                        new SolidBrush(ColorBlack),
                        TitleRectangle, sf);
                }

                //cleanup
                sf.Dispose();
            }
            #endregion
            #region TIME
            if (timeText != null && timeText.Length != 0)
            {
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                
                if (bIsCustom)
                {
                    if (Properties.Settings.Default.AppAlertTimeEnabled)
                    {
                        Font cFont;

                        if (Properties.Settings.Default.AppAlertTimeCenter)
                            sf.Alignment = StringAlignment.Center;
                        else sf.Alignment = StringAlignment.Far;

                        if (Properties.Settings.Default.AppAlertTimeBold &&
                            !Properties.Settings.Default.AppAlertTimeItalic)
                            cFont = new Font(CustomFont, fs_Bold);
                        else if (!Properties.Settings.Default.AppAlertTimeBold &&
                            Properties.Settings.Default.AppAlertTimeItalic)
                            cFont = new Font(CustomFont, fs_Italic);
                        else if (Properties.Settings.Default.AppAlertTimeBold &&
                            Properties.Settings.Default.AppAlertTimeItalic)
                            cFont = new Font(CustomFont, fs_BoldItalic);
                        else cFont = new Font(CustomFont, fs_Normal);

                        grfx.DrawString(
                        timeText,
                        cFont,
                        new SolidBrush(
                            Properties.Settings.Default.AppAlertTimeColor),
                            TimeRectangle, sf);

                        //cleanup
                        cFont.Dispose();
                    }
                }
                else //default
                {
                    sf.Alignment = StringAlignment.Far;                              
                        grfx.DrawString(
                            timeText,
                            new Font("tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel),
                            new SolidBrush(ColorBlack), TimeRectangle, sf);
                }

                //cleanup
                sf.Dispose();
            }
            #endregion
            #region NAME
            if (nameText != null && nameText.Length != 0)
            {
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Trimming = StringTrimming.Character;

                if (bIsCustom)
                {
                    if (Properties.Settings.Default.AppAlertFromEnabled)
                    {
                        Font cFont;
                        if (Properties.Settings.Default.AppAlertFromCenter)
                            sf.Alignment = StringAlignment.Center;
                        else sf.Alignment = StringAlignment.Near;

                        if (Properties.Settings.Default.AppAlertFromBold &&
                            !Properties.Settings.Default.AppAlertFromItalic)
                            cFont = new Font(CustomFont, fs_Bold);
                        else if (!Properties.Settings.Default.AppAlertFromBold &&
                            Properties.Settings.Default.AppAlertFromItalic)
                            cFont = new Font(CustomFont, fs_Italic);
                        else if (Properties.Settings.Default.AppAlertFromBold &&
                            Properties.Settings.Default.AppAlertFromItalic)
                            cFont = new Font(CustomFont, fs_BoldItalic);
                        else cFont = new Font(CustomFont, fs_Normal);

                        grfx.DrawString(
                        nameText,
                        cFont,
                        new SolidBrush(
                            Properties.Settings.Default.AppAlertFromColor),
                            NameRectangle, sf);

                        //cleanup
                        cFont.Dispose();
                    }
                }
                else //default
                {
                    sf.Alignment = StringAlignment.Near;
                    grfx.DrawString(
                        nameText,
                        new Font("tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel),
                        new SolidBrush(ColorBlack), NameRectangle, sf);
                }

                //cleanup
                sf.Dispose();

            }
            #endregion
            #region SUBJECT
            if (subjectText != null && subjectText.Length != 0)
            {
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Trimming = StringTrimming.EllipsisWord;

                if (bIsCustom)
                {
                    if (Properties.Settings.Default.AppAlertSubjectEnabled)
                    {
                        Font cFont;

                        if (Properties.Settings.Default.AppAlertSubjectCenter)
                            sf.Alignment = StringAlignment.Center;
                        else sf.Alignment = StringAlignment.Near;

                        if (Properties.Settings.Default.AppAlertSubjectBold &&
                            !Properties.Settings.Default.AppAlertSubjectItalic)
                            cFont = new Font(CustomFont, fs_Bold);
                        else if (!Properties.Settings.Default.AppAlertSubjectBold &&
                            Properties.Settings.Default.AppAlertSubjectItalic)
                            cFont = new Font(CustomFont, fs_Italic);
                        else if (Properties.Settings.Default.AppAlertSubjectBold &&
                            Properties.Settings.Default.AppAlertSubjectItalic)
                            cFont = new Font(CustomFont, fs_BoldItalic);
                        else cFont = new Font(CustomFont, fs_Normal);

                        grfx.DrawString(
                        subjectText,
                        cFont,
                        new SolidBrush(
                            Properties.Settings.Default.AppAlertSubjectColor),
                            SubjectRectangle, sf);

                        //cleanup
                        cFont.Dispose();
                    }
                }
                else //default
                {
                    sf.Alignment = StringAlignment.Near;
                    grfx.DrawString(
                        subjectText,
                        new Font("tahoma", 11, FontStyle.Regular | FontStyle.Italic, GraphicsUnit.Pixel),
                        new SolidBrush(ColorBlack), SubjectRectangle, sf);
                }

                //cleanup
                sf.Dispose();
            }
            #endregion
            #region MESSAGE
            if (contentText != null && contentText.Length != 0)
            {
                StringFormat sf = new StringFormat();
                //sf.LineAlignment = StringAlignment.Center; //zet tekst midden in vak
                sf.LineAlignment = StringAlignment.Near; // zet tekst linksboven in vak
                //sf.Trimming = StringTrimming.None; //set trimming of text 059
                sf.Trimming = StringTrimming.EllipsisWord; //0510

                if (bIsCustom)
                {
                    if (Properties.Settings.Default.AppAlertMessageEnabled)
                    {
                        Font cFont;

                        if (Properties.Settings.Default.AppAlertMessageCenter)
                            sf.Alignment = StringAlignment.Center;
                        else sf.Alignment = StringAlignment.Near;
                        

                        if (Properties.Settings.Default.AppAlertMessageBold &&
                            !Properties.Settings.Default.AppAlertMessageItalic)
                            cFont = new Font(CustomFont, fs_Bold);
                        else if (!Properties.Settings.Default.AppAlertMessageBold &&
                            Properties.Settings.Default.AppAlertMessageItalic)
                            cFont = new Font(CustomFont, fs_Italic);
                        else if (Properties.Settings.Default.AppAlertMessageBold &&
                            Properties.Settings.Default.AppAlertMessageItalic)
                            cFont = new Font(CustomFont, fs_BoldItalic);
                        else cFont = new Font(CustomFont, fs_Normal);

                        grfx.DrawString(
                        contentText,
                        cFont,
                        new SolidBrush(
                            Properties.Settings.Default.AppAlertMessageColor),
                            ContentRectangle, sf);

                        //cleanup
                        cFont.Dispose();
                    }
                }
                else //default
                {
                    sf.Alignment = StringAlignment.Near;
                    grfx.DrawString(
                        contentText,
                        new Font("tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel),
                        new SolidBrush(ColorSpiffy), ContentRectangle, sf);
                }

                //cleanup
                sf.Dispose();
            }
            #endregion

            //cleanup
            grfx.Dispose();
        }

        protected static Region BitmapToRegion(Bitmap alertBackground, Color transparencyColor)
        {
            //if (alertBackground == null)
            //    throw new ArgumentNullException("Bitmap", "Bitmap cannot be null!");        
            //null is check in InitSpiffyPopup

            int height = alertBackground.Height;
            int width = alertBackground.Width;

            GraphicsPath path = new GraphicsPath();

            for (int j = 0; j < height; j++)
                for (int i = 0; i < width; i++)
                {
                    if (alertBackground.GetPixel(i, j) == transparencyColor)
                        continue;

                    int x0 = i;

                    while ((i < width) && (alertBackground.GetPixel(i, j) != transparencyColor))
                        i++;

                    path.AddRectangle(new Rectangle(x0, j, i - x0, 1));
                }

            Region region = new Region(path);
            path.Dispose();
            return region;
        }
        #endregion

        #region SpiffyNotifier Events Overrides
        private void OnTimer(Object obj, EventArgs ea)
        {
            switch (taskbarState)
            {
                case TaskbarStates.appearing:
                    if (bAppearBySliding)
                    {
                        if (Height < BackgroundBitmap.Height) 
                        {
                            Top -= nIncrementShow; //0510
                            Height += nIncrementShow; //0510
                            //SetBounds(Left, Top - nIncrementShow, Width, Height + nIncrementShow);
                        }
                        else
                        {
                            if (Bottom > WorkAreaRectangle.Bottom - nPadding - nBaseWindowBottom + 2)
                            {
                                SetBounds(Left, Top - nIncrementShow, Width, Height);
                            }
                            else
                            {
                                timer.Stop();
                                Height = BackgroundBitmap.Height;
                                timer.Interval = nVisibleEvents;
                                taskbarState = TaskbarStates.visible;
                                timer.Start();
                            }
                        }
                    }
                    else
                    {
                        if (Opacity < 1.0)
                            Opacity = Opacity + (1.0 / (BackgroundBitmap.Height / nIncrementShow));
                        else
                        {
                            timer.Stop();
                            Height = BackgroundBitmap.Height;
                            timer.Interval = nVisibleEvents;
                            taskbarState = TaskbarStates.visible;
                            timer.Start();
                        }
                    }
                    break;

                case TaskbarStates.visible:
                    timer.Stop();
                    timer.Interval = nHideEvents;
                    if ((bKeepVisibleOnMouseOver && !bIsMouseOverPopup) || (!bKeepVisibleOnMouseOver))
                    {
                        taskbarState = TaskbarStates.disappearing;
                    }
                    timer.Start();
                    break;

                case TaskbarStates.disappearing:
                    if (bReShowOnMouseOver && bIsMouseOverPopup)
                    {
                        taskbarState = TaskbarStates.appearing;
                    }
                    else
                    {
                        if (bAppearBySliding)
                        {
                            if ((Top + Height) < WorkAreaRectangle.Bottom)
                            {
                                SetBounds(Left, Top + nIncrementHide, Width, Height);
                            }
                            else
                            {
                                if (Top < WorkAreaRectangle.Bottom)
                                {
                                    SetBounds(Left, Top + nIncrementHide, Width, Height - nIncrementHide);
                                }
                                else
                                {
                                    //Hide notifier
                                    Hide();
                                }
                            }

                        }
                        else
                        {
                            if (Opacity > 0.1)
                            {
                                Opacity = Opacity - (1.0 / (BackgroundBitmap.Height / nIncrementHide));
                            }
                            else
                            {
                                //Hide notifier
                                Hide();
                            }

                        }
                    }
                    break;
            }
        }

        protected override void OnMouseEnter(EventArgs ea)
        {
            base.OnMouseEnter(ea);
            bIsMouseOverPopup = true;
            Refresh();
        }

        protected override void OnMouseLeave(EventArgs ea)
        {
            base.OnMouseLeave(ea);
            bIsMouseOverPopup = false;
            bIsMouseOverClose = false;
            bIsMouseOverContent = false;
            Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs mea)
        {
            base.OnMouseMove(mea);

            bool bContentModified = false;

            //checks if mouse is in close or content region
            if (CloseRectangle.Contains(new Point(mea.X, mea.Y)) && CloseClickable)
            {
                if (!bIsMouseOverClose)
                {
                    bIsMouseOverClose = true;
                    bIsMouseOverContent = false;
                    Cursor = Cursors.Hand;
                    bContentModified = true;
                }
            }
            else if (ContentRectangle.Contains(new Point(mea.X, mea.Y)) && ContentClickable)
            {
                if (!bIsMouseOverContent)
                {
                    bIsMouseOverClose = false;
                    bIsMouseOverContent = true;
                    Cursor = Cursors.Hand;
                    bContentModified = true;
                }
            }
            else
            {
                if (bIsMouseOverClose || bIsMouseOverContent)
                    bContentModified = true;
                
                bIsMouseOverClose = false;
                bIsMouseOverContent = false;
                Cursor = Cursors.Default;
            }

            if (bContentModified)
                Refresh();

        }

        protected override void OnMouseDown(MouseEventArgs mea)
        {
            base.OnMouseDown(mea);

            bIsMouseDown = true;

            if (bIsMouseOverClose)
                Refresh();

        }

        protected override void OnMouseUp(MouseEventArgs mea)
        {
            base.OnMouseUp(mea);
            bIsMouseDown = false;

            if (bIsMouseOverClose)
            {
                Hide(); //must be done here otherwise hides spiffy main aswell
                
                //if (CloseClick != null)
                //    CloseClick(this, new EventArgs());
            }
            else if (bIsMouseOverContent)
            {
                //if (ContentClick != null)
                //    ContentClick(this, new EventArgs()); //046

                if (ContentClick != null)
                    ContentClick(this, new SpiffyAlertEventArgs(contentUrl, null)); //047
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pea)
        {
            //0510 RC5 updated with using() to auto dispose
            Graphics offScreenGraphics = null;
            Bitmap offscreenBitmap = null;
            Graphics grfx = pea.Graphics;

            using (offscreenBitmap = new Bitmap(BackgroundBitmap.Width, BackgroundBitmap.Height))
            using (offScreenGraphics = Graphics.FromImage(offscreenBitmap))
            {
                grfx.PageUnit = GraphicsUnit.Pixel;

                offScreenGraphics = Graphics.FromImage(offscreenBitmap);

                if (BackgroundBitmap != null)
                {
                    offScreenGraphics.DrawImage(BackgroundBitmap, 0, 0, BackgroundBitmap.Width, BackgroundBitmap.Height);
                }
                //Draw text on alert
                DrawText(offScreenGraphics);
                grfx.DrawImage(offscreenBitmap, 0, 0);
            }
        }
        #endregion
    }
}
