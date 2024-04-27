using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Spiffy
{
    public partial class options_customize_popup : UserControl
    {
        public options_customize_popup()
        {
             InitializeComponent();
        }

        private void options_customize_popup_Load(object sender, EventArgs e)
        {
            InitializeLocale();

            //Check stuff that can be empty on first startup
            if (String.IsNullOrEmpty(Properties.Settings.Default.AppAlertCustomFont))
                Properties.Settings.Default.AppAlertCustomFont = "Tahoma";                
            if (String.IsNullOrEmpty(Properties.Settings.Default.AppAlertCustomFontSize))
                Properties.Settings.Default.AppAlertCustomFontSize = "11";

            comboBox1.SelectedItem = Properties.Settings.Default.AppAlertCustomFont;
            comboBox2.SelectedItem = Properties.Settings.Default.AppAlertCustomFontSize;
        }

        private void InitializeLocale()
        {
            label9.Text = SpiffyText.String00229;
            cbAppUseCustomAlertBG.Text = SpiffyText.String00230;
            groupBox2.Text = SpiffyText.String00231;
            btnDefaults.Text = SpiffyText.String00232;

            label2.Text = SpiffyText.String00233;
            label7.Text = SpiffyText.String00234;
            label26.Text = SpiffyText.String00235;
            label10.Text = SpiffyText.String00236;
            label5.Text = SpiffyText.String00237;

            //checkboxes
            checkBox11.Text = SpiffyText.String00238;
            checkBox14.Text = SpiffyText.String00239;
            checkBox15.Text = SpiffyText.String00240;
            checkBox16.Text = SpiffyText.String00241;
            checkBox17.Text = SpiffyText.String00242;
            
            //font and time
            label4.Text = SpiffyText.String00243;
            label6.Text = SpiffyText.String00244; //px
            label8.Text = SpiffyText.String00245;
            toolTipCustomPopup.SetToolTip(pictureBox1, SpiffyText.String00252);

            btnTestPopup.Text = SpiffyText.String00246;

            //Custom BG
            groupBox1.Text = SpiffyText.String00247;

            //info labels
            label1.Text = SpiffyText.String00250;
            label3.Text = SpiffyText.String00251;


        }

        private void btnBrowsePopupBG_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
                SpiffyText.String00052 + " (*.bmp;*.gif;*.jpg;*.png)|*.bmp;*.gif;*.jpg;*.png|" + SpiffyText.String00066 + " (*.*)|*.*"; //image files
            dialog.Title = SpiffyText.String00049; //select a notifier background
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbPopupBGLocation.Text = dialog.FileName;
            }
            dialog.Dispose();
        }

        //Returns notifier instance with options (KEEP SAME AS THE ONE IN FORM1)
        public static SpiffyPopup InitSpiffyPopupCustom(SpiffyPopup notifier)
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.AppCustomAlertBackgroundPath) &&
                File.Exists(Properties.Settings.Default.AppCustomAlertBackgroundPath))
            {
                notifier.SetBackgroundBitmap(
                    Properties.Settings.Default.AppCustomAlertBackgroundPath,
                    Color.FromArgb(255, 0, 255));
            }
            else //default skin
            {
                notifier.SetBackgroundBitmap(
                    Properties.Resources.skin_default,
                    Color.FromArgb(255, 0, 255));
            }

            //Rectangles (check if enabled and create)

            //Close
            notifier.CloseRectangle = new Rectangle(
                Int32.Parse(Properties.Settings.Default.AppAlertCloseAreaX.ToString()),
                Int32.Parse(Properties.Settings.Default.AppAlertCloseAreaY.ToString()),
                Int32.Parse(Properties.Settings.Default.AppAlertCloseAreaW.ToString()),
                Int32.Parse(Properties.Settings.Default.AppAlertCloseAreaH.ToString())
                );
            //Title
            if (Properties.Settings.Default.AppAlertTitleEnabled)
                notifier.TitleRectangle = new Rectangle(
                    Int32.Parse(Properties.Settings.Default.AppAlertTitleX.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertTitleY.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertTitleW.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertTitleH.ToString())
                    );
            //Time
            if (Properties.Settings.Default.AppAlertTimeEnabled)
                notifier.TimeRectangle = new Rectangle(
                    Int32.Parse(Properties.Settings.Default.AppAlertTimeX.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertTimeY.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertTimeW.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertTimeH.ToString())
                    );
            //Name / From
            if (Properties.Settings.Default.AppAlertFromEnabled)
                notifier.NameRectangle = new Rectangle(
                    Int32.Parse(Properties.Settings.Default.AppAlertFromX.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertFromY.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertFromW.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertFromH.ToString())
                    );
            //Subject
            if (Properties.Settings.Default.AppAlertSubjectEnabled)
                notifier.SubjectRectangle = new Rectangle(
                    Int32.Parse(Properties.Settings.Default.AppAlertSubjectX.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertSubjectY.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertSubjectW.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertSubjectH.ToString())
                    );
            //Message / Content
            if (Properties.Settings.Default.AppAlertMessageEnabled)
                notifier.ContentRectangle = new Rectangle(
                    Int32.Parse(Properties.Settings.Default.AppAlertMessageX.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertMessageY.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertMessageW.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertMessageH.ToString())
                    );

            //Change font
            notifier.CustomFont = new Font(Properties.Settings.Default.AppAlertCustomFont,
                float.Parse(Properties.Settings.Default.AppAlertCustomFontSize), GraphicsUnit.Pixel);

            //Set misc options
            notifier.CloseClickable = Properties.Settings.Default.AppAlertCloseClickable;
            notifier.ContentClickable = Properties.Settings.Default.AppAlertMessageLineClickable;
            notifier.KeepVisibleOnMousOver = Properties.Settings.Default.AppAlertKeepVisibleOnMouseOver;
            notifier.ReShowOnMouseOver = Properties.Settings.Default.AppAlertReShowOnMouseOver;
            notifier.AppearBySliding = Properties.Settings.Default.AppAlertSliding;

            notifier.Padding = 2;

            return notifier;
        }

        private void btnTestPopup_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            SpiffyPopup popup = InitSpiffyPopupCustom(new SpiffyPopup());
            popup.Show("Spiffy Notifier",
                "http://",
                "Spiffy HQ",
                "spiffyhq@gmail.com",
                "Re: The quick brown fox jumps over the lazy dog",
                "The quick brown fox jumps over the lazy dog",
                SpiffyStuff.convertGTime(dt, Properties.Settings.Default.AppAlertDateTimeFormat),
                Int32.Parse(Properties.Settings.Default.AppAlertShowDelay.ToString()), //showing in... ms
                10000, //staying for... ms
                Int32.Parse(Properties.Settings.Default.AppAlertHideDelay.ToString()) //hiding in ... ms
                );            
        }

        private void btnDefaults_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show
                    (SpiffyText.String00054, //reset to default?
                     "Spiffy", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                     MessageBoxDefaultButton.Button1))
            {
                //clear bg location
                tbPopupBGLocation.Clear();

                //reset enabled/bold/italic/center
                checkBox11.Checked = true;
                checkBox14.Checked = true;
                checkBox15.Checked = true;
                checkBox16.Checked = true;
                checkBox17.Checked = true;
                //title
                checkBox2.Checked = true;
                checkBox1.Checked = false;
                checkBox4.Checked = true;
                //time
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox3.Checked = false;
                //name
                checkBox9.Checked = false;
                checkBox7.Checked = false;
                checkBox18.Checked = false;
                //subject
                checkBox12.Checked = false;
                checkBox10.Checked = true;
                checkBox19.Checked = false;
                //message
                checkBox8.Checked = false;
                checkBox13.Checked = false;
                checkBox20.Checked = false;

                //colors
                btnColorTitle.BackColor = Color.Black;
                btnColorTime.BackColor = Color.Black;
                btnColorFrom.BackColor = Color.Black;
                btnColorSubject.BackColor = Color.Black;
                btnColorMessage.BackColor = Color.FromArgb(0, 120, 0);
 
                //close 338, 3, 12, 14
                numericUpDown1.Value = 338;
                numericUpDown7.Value = 3;
                numericUpDown23.Value = 12;
                numericUpDown24.Value = 15;

                //title 47, 4, 160, 14
                numericUpDown2.Value = 47;
                numericUpDown8.Value = 4;
                numericUpDown15.Value = 160;
                numericUpDown14.Value = 14;
                
                //time 216, 4, 120, 14
                numericUpDown3.Value = 216;
                numericUpDown9.Value = 4;
                numericUpDown16.Value = 120;
                numericUpDown20.Value = 14;

                //name 47, 20, 310, 14
                numericUpDown4.Value = 47;
                numericUpDown10.Value = 20;
                numericUpDown17.Value = 310;
                numericUpDown21.Value = 14;

                //subject 47, 37, 310, 14
                numericUpDown5.Value = 47;
                numericUpDown11.Value = 37;
                numericUpDown18.Value = 310;
                numericUpDown22.Value = 14;

                //message 47, 54, 310, 14
                numericUpDown6.Value = 47;
                numericUpDown12.Value = 54;
                numericUpDown19.Value = 310;
                numericUpDown13.Value = 14; //height

                //Font
                Properties.Settings.Default.AppAlertCustomFont = "Tahoma";
                Properties.Settings.Default.AppAlertCustomFontSize = "11";

                //Date Time
                Properties.Settings.Default.AppAlertDateTimeFormat = String.Empty;

                //Set font dropdowns from settings
                comboBox1.SelectedItem = Properties.Settings.Default.AppAlertCustomFont;
                comboBox2.SelectedItem = Properties.Settings.Default.AppAlertCustomFontSize;

            }

        }

        private void btnColorTitle_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColorTitle.BackColor = colorDialog1.Color;
            }
            else
            {
                btnColorTitle.BackColor = Color.Black;
            }
            colorDialog1.Dispose();
        }

        private void btnColorTime_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColorTime.BackColor = colorDialog1.Color;
            }
            else
            {
                btnColorTime.BackColor = Color.Black;
            }
            colorDialog1.Dispose();
        }

        private void btnColorFrom_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColorFrom.BackColor = colorDialog1.Color;
            }
            else
            {
                btnColorFrom.BackColor = Color.Black;
            }
            colorDialog1.Dispose();
        }

        private void btnColorSubject_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColorSubject.BackColor = colorDialog1.Color;
            }
            else
            {
                btnColorSubject.BackColor = Color.Black;
            }
            colorDialog1.Dispose();
        }

        private void btnColorMessage_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColorMessage.BackColor = colorDialog1.Color;
            }
            else
            {
                btnColorMessage.BackColor = Color.FromArgb(0,120,0);
            }
            colorDialog1.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SpiffyStuff.openHelpURL("datetime");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SpiffyStuff.openHelpURL("customalert");
        }

    }
}
