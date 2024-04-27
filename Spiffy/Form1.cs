using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Threading;
using System.Resources;
using System.Collections;
//
//using System.Text.RegularExpressions;
using System.Configuration;
using System.Security;
using System.Security.Permissions;
using System.Windows.Shell;


namespace Spiffy
{
    public partial class Form1 : Form
    {
        //VERSION INFO
        public const string appVersion = "0.6.1";

        //BUILD TIME
        public static string AppBuild
        {
            get
            {
                return BuildTime().ToString("r", DateTimeFormatInfo.CurrentInfo);
            }
        }

        //GLOBAL TIMER BOOL
        internal bool timersRunning = false;

        //ACCOUNTS
        internal static SpiffyAccount AC1, AC2, AC3, AC4, AC5;

        //TELL ME AGAIN ARRAY
        internal static ArrayList TMA;

        internal static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            internal extern static int SetProcessWorkingSetSize(IntPtr hProcess, int min, int max);
        }

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            // culture could be 'nl-NL', 'it-IT' etc... program default is English
            if (Properties.Settings.Default.AppLocale == null)
                Properties.Settings.Default.AppLocale = "English";

            //create temp string to convert name Dutch (Netherlands) to nl-NL etc
            String cultureName = SpiffyStuff.getCulture(Properties.Settings.Default.AppLocale);

            //create the new culture
            CultureInfo SpiffyCultureInfo = new CultureInfo(cultureName);
            
            //Thread.CurrentThread.CurrentCulture = myCultureInfo; //sets time format etc
            Thread.CurrentThread.CurrentUICulture = SpiffyCultureInfo; //sets ui language
           
            //Default
            InitializeComponent();

            //Styles
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            //SET RTL LAYOUT FOR HEBREW
            if (Properties.Settings.Default.AppLocale == "Hebrew")
            {
                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;

                trayContextMenu.RightToLeft = RightToLeft.Yes;
            }

            //Set app build datetime
            //appBuild = getBuildTime().ToString("r", CultureInfo.CurrentCulture); //DateTimeFormatInfo.CurrentInfo

            //SPIFFY
            InitializeAccounts();
        }

        //Init accounts, set name, url etc, clear tellmeagain, trayicon.
        private void InitializeAccounts()
        {
            //Create accounts
            AC1 = InitSpiffyAccount(new SpiffyAccount());
            AC1.AccountName = Properties.Settings.Default.A1Name;
            AC1.IsAppsAccount = Properties.Settings.Default.A1GoogleApps;
            AC1.AccountUrl = createAccountUrl(AC1.IsAppsAccount, Properties.Settings.Default.A1GoogleAppsDomain);
            AC1.AccountHasCustomAlert = Properties.Settings.Default.A1CustomAlertEnabled;
            AC1.AccountCustomAlertPath = Properties.Settings.Default.A1CustomAlert;

            AC2 = InitSpiffyAccount(new SpiffyAccount());
            AC2.AccountName = Properties.Settings.Default.A2Name;
            AC2.IsAppsAccount = Properties.Settings.Default.A2GoogleApps;
            AC2.AccountUrl = createAccountUrl(AC2.IsAppsAccount, Properties.Settings.Default.A2GoogleAppsDomain);
            AC2.AccountHasCustomAlert = Properties.Settings.Default.A2CustomAlertEnabled;
            AC2.AccountCustomAlertPath = Properties.Settings.Default.A2CustomAlert;

            AC3 = InitSpiffyAccount(new SpiffyAccount());
            AC3.AccountName = Properties.Settings.Default.A3Name;
            AC3.IsAppsAccount = Properties.Settings.Default.A3GoogleApps;
            AC3.AccountUrl = createAccountUrl(AC3.IsAppsAccount, Properties.Settings.Default.A3GoogleAppsDomain);
            AC3.AccountHasCustomAlert = Properties.Settings.Default.A3CustomAlertEnabled;
            AC3.AccountCustomAlertPath = Properties.Settings.Default.A3CustomAlert;

            AC4 = InitSpiffyAccount(new SpiffyAccount());
            AC4.AccountName = Properties.Settings.Default.A4Name;
            AC4.IsAppsAccount = Properties.Settings.Default.A4GoogleApps;
            AC4.AccountUrl = createAccountUrl(AC4.IsAppsAccount, Properties.Settings.Default.A4GoogleAppsDomain);
            AC4.AccountHasCustomAlert = Properties.Settings.Default.A4CustomAlertEnabled;
            AC4.AccountCustomAlertPath = Properties.Settings.Default.A4CustomAlert;

            AC5 = InitSpiffyAccount(new SpiffyAccount());
            AC5.AccountName = Properties.Settings.Default.A5Name;
            AC5.IsAppsAccount = Properties.Settings.Default.A5GoogleApps;
            AC5.AccountUrl = createAccountUrl(AC5.IsAppsAccount, Properties.Settings.Default.A5GoogleAppsDomain);
            AC5.AccountHasCustomAlert = Properties.Settings.Default.A5CustomAlertEnabled;
            AC5.AccountCustomAlertPath = Properties.Settings.Default.A5CustomAlert;

            //Clear Tell Me Again array - changed 0510 array is created here now instead of when starting
            TMA = new ArrayList();
            //TMA.Clear();

            //Clear Tell Me Again buttons
            tellMeAgainToolStripMenuItem.Enabled = false;
            toolStripButtonTellMeAgain.Enabled = false;

            //Clear New Mail Icon
            SpiffyStuff.changeTrayicon(notifyIcon1, false);
                
        }

        private void InitializeLocale()
        {
            //Main window, menustrip1
            fileToolStripMenuItem.Text = SpiffyText.String00101; 
            toolsToolStripMenuItem.Text = SpiffyText.String00102;
            helpToolStripMenuItem.Text = SpiffyText.String00103;

            //File menu
            //hideLogToolStripMenuItem.Text = SpiffyText.String00105; //set on load & toggleview
            clearLogToolStripMenuItem2.Text = SpiffyText.String00106;
            exitToolStripMenuItem.Text = SpiffyText.String00107;

            //Options menu
            checkNowToolStripMenuItem.Text = SpiffyText.String00108;
            enableTimersToolStripMenuItem1.Text = SpiffyText.String00110;
            useProxyToolStripMenuItem.Text = SpiffyText.String00112;
            accountsToolStripMenuItem.Text = SpiffyText.String00113 + "...";
            optionsToolStripMenuItem.Text = SpiffyText.String00114 + "...";
            
            //Help menu
            spiffyWebsiteToolStripMenuItem.Text = SpiffyText.String00115;
            //spiffyForumsToolStripMenuItem.Text = SpiffyText.String00116;
            //reportProblemToolStripMenuItem.Text = SpiffyText.String00117;
            checkForUpdateToolStripMenuItem.Text = SpiffyText.String00118;
            donateToolStripMenuItem.Text = SpiffyText.String00119;
            aboutToolStripMenuItem.Text = SpiffyText.String00120;
            
            //Main window, toolstrip1 -> set tooltips!! remove ampersands! 
            toolStripButton2.ToolTipText = SpiffyText.String00121.Replace("&", "");
            toolStripButtonTellMeAgain.ToolTipText = SpiffyText.String00122.Replace("&","");
            toolStripButton4.ToolTipText = SpiffyText.String00123.Replace("&", "");
            toolStripTimerLabel.ToolTipText = SpiffyText.String00124;
            toolStripProxyLabel.ToolTipText = SpiffyText.String00127;

            //Log context menu
            checkNowToolStripMenuItem1.Text = SpiffyText.String00108;
            //hide log auto
            clearLogToolStripMenuItem1.Text = SpiffyText.String00106;
            accountsToolStripMenuItem1.Text = SpiffyText.String00113 + "...";
            optionsToolStripMenuItem1.Text = SpiffyText.String00114 + "...";
            quitSpiffyToolStripMenuItem1.Text = SpiffyText.String00107;

            //Tray menu
            restoreWindowToolStripMenuItem.Text = SpiffyText.String00128;
            tellMeAgainToolStripMenuItem.Text = SpiffyText.String00122;
            quitSpiffyToolStripMenuItem.Text = SpiffyText.String00107;
            checkNowToolStripMenuItem2.Text = SpiffyText.String00108;
            gmailInboxToolStripMenuItem.Text = SpiffyText.String00123;
            toolsToolStripMenuItem1.Text = SpiffyText.String00102;
            accountsToolStripMenuItem3.Text = SpiffyText.String00130 + "...";
            configurationToolStripMenuItem1.Text = SpiffyText.String00131 + "...";

            //HELP
            helpToolStripMenuItem1.Text = SpiffyText.String00103; //help submenu
            spiffyWebsiteToolStripMenuItem1.Text = SpiffyText.String00115;
            //spiffyForumsToolStripMenuItem1.Text = SpiffyText.String00116;
            //reportProblemToolStripMenuItem1.Text = SpiffyText.String00117;
            checkForUpdateToolStripMenuItem1.Text = SpiffyText.String00118;
            donateWithPaypalToolStripMenuItem.Text = SpiffyText.String00119;
            aboutSpiffyToolStripMenuItem.Text = SpiffyText.String00120;

            //OPTIONS
            alwaysHideWindowToolStripMenuItem.Text = SpiffyText.String00129;
            enableSoundsToolStripMenuItem.Text = SpiffyText.String00067;
            enableAlertsToolStripMenuItem.Text = SpiffyText.String00068;
            enableTimersToolStripMenuItem.Text = SpiffyText.String00069;
            enableProxyFromTrayToolStripMenuItem.Text = SpiffyText.String00070;
        }
            
        private void Form1_Load(object sender, EventArgs e)
        {           
            //CHECK IF DEBUG LOGGING IS ENABLED
            if (Properties.Settings.Default.DebugLoggingEnabled)
            {
                //Check for -32000 window location
                if (this.Location.X == -32000 && this.Location.Y == -32000)
                {
                    Properties.Settings.Default.AppWindowLocation = new Point(100, 100);
                    this.Location = Properties.Settings.Default.AppWindowLocation;
                }

                //when Yes is pressed debug is disabled
                if (DialogResult.Yes ==
                    MessageBox.Show(
                    SpiffyText.String00302 + "\n" +
                    SpiffyText.String00303 + "\n\n" +
                    SpiffyText.String00304,
                    "Spiffy", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    SpiffyStuff.writeErrorLog("@ LOAD DISABLE");
                    Properties.Settings.Default.DebugLoggingEnabled = false;
                    saveNow();
                }
                else
                {
                    SpiffyStuff.writeErrorLog("@ LOAD ENABLE");
                }
            }

            //Check if Always Hide Main is enabled
            //if so set check on tray menu item (like proxy toggle) and hide window before the rest loads
            if (Properties.Settings.Default.AlwaysHideMainWindow)
            {
                SpiffyStuff.HideApp(this);
                alwaysHideWindowToolStripMenuItem.Checked = true;
            }
            else
            {
                alwaysHideWindowToolStripMenuItem.Checked = false;
            }

            //STARTUP MESSAGES
            rtbLog.Clear(); //clear log window
            SpiffyStuff.writeLog(Properties.Resources.AppStringAppName + " " + appVersion + " " +
                SpiffyText.String00002, rtbLog); //spiffy 0.x.x started
            //Show build time
            try
            {
                SpiffyStuff.writeLog(SpiffyText.String00003 + " " + //build
                    AppBuild, rtbLog);
            }
            catch (Exception buildStringLoad)
            {
                SpiffyStuff.LogExceptionInfo(buildStringLoad, "buildStringOnLoad", true);
            }

            //CHECK RUNNING MODE AND REPORT TO LOG
            if (PortableSettingsProvider.saveMode == "custom") //CUSTOM MODE
            {
                SpiffyStuff.writeLog(SpiffyText.String00330, rtbLog);
                SpiffyStuff.writeLog(SpiffyText.String00332 + ": " + PortableSettingsProvider.customAppSettingsPath, rtbLog);
            }
            else if (PortableSettingsProvider.saveMode == "local") //USB MODE
            {
                SpiffyStuff.writeLog(SpiffyText.String00331, rtbLog);
                SpiffyStuff.writeLog(SpiffyText.String00332 + ": " + PortableSettingsProvider.exePath, rtbLog);
            }
            else 
            {
                //Normal Mode, show nothing
                //SpiffyStuff.writeLog("Running in Normal Mode", rtbLog);
                //SpiffyStuff.writeLog("Working dir: " + PortableSettingsProvider.appData + "\\Spiffy", rtbLog);
            }

            //Set buttons etc to current language
            InitializeLocale();

            //Set Window Title & Tray Title
            this.Text = Properties.Settings.Default.AppWindowTitleText;
            notifyIcon1.Text = Properties.Settings.Default.AppWindowTitleText;

            //Set Window Location (Only when Form is active)
            if(this.WindowState == FormWindowState.Normal) 
                this.Location = Properties.Settings.Default.AppWindowLocation;

            //Compare Window Location with Screen Resolution and reset if out of screen
            if (this.Location.X > Screen.FromControl(this).Bounds.Width
                || this.Location.Y > Screen.FromControl(this).Bounds.Height)
            {
                Properties.Settings.Default.AppWindowLocation = new Point(100, 100);
                this.Location = Properties.Settings.Default.AppWindowLocation;
            }
          
            //Set Window Size from Settings
            this.Size = Properties.Settings.Default.AppWindowSize;

            //Set Window Opacity from Settings
            this.Opacity = (Double.Parse(Properties.Settings.Default.AppOpacity.ToString()) / 100);

            //Check if window heigt isn't wrong, if so reset
            if (this.Size.Height < 40)
            {
                Properties.Settings.Default.AppWindowSize = new Size(430, 200);
                this.Size = Properties.Settings.Default.AppWindowSize;
            }

            //CHECK - Show or hide logwindow and set menu icon -> reverse toggleView()
            //(Without extra panel rtbLog.visible default = false, otherwise true)
            //also, when log is hidden menuitem must swith to show and vv.
            if (Properties.Settings.Default.AppShowLog)
            {
                hideLogToolStripMenuItem.Text = SpiffyText.String00104; //set to &hide log (menu item)
                hideLogToolStripMenuItem.Image = Properties.Resources.application_put;
                hideLogToolStripMenuItem1.Text = SpiffyText.String00104; //set to hide log (contextmenu item)
                hideLogToolStripMenuItem1.Image = Properties.Resources.application_put;
                rtbLog.Visible = true;
            }
            else  
            {
                hideLogToolStripMenuItem.Text = SpiffyText.String00105; //set to &show log (menu item)
                hideLogToolStripMenuItem.Image = Properties.Resources.application_get;
                hideLogToolStripMenuItem1.Text = SpiffyText.String00105; //set to show log (context menu item)
                hideLogToolStripMenuItem1.Image = Properties.Resources.application_get;
                rtbLog.Visible = false;
            }

            //Check which trayicon must be used
            if (!String.IsNullOrEmpty(Properties.Settings.Default.AppDefaultTrayIcon))
                SpiffyStuff.changeTrayicon(notifyIcon1);

            //SET CHECKBOX IN TRAY AND TOOLSTRIP ICON - PROXY 
            if (Properties.Settings.Default.proxyEnabled)
            {
                useProxyToolStripMenuItem.Checked = true;
                enableProxyFromTrayToolStripMenuItem.Checked = true;
                toolStripProxyLabel.Visible = true;
            }
            else //if disabled
            {
                useProxyToolStripMenuItem.Checked = false;
                enableProxyFromTrayToolStripMenuItem.Checked = false;
                toolStripProxyLabel.Visible = false;
            }

            //LOG IF PROXY IS ENABLED
            if (Properties.Settings.Default.proxyEnabled)
            {
                SpiffyStuff.writeLog(SpiffyText.String00018 + " (" + Properties.Settings.Default.proxyServerName 
                    + ":" + Properties.Settings.Default.proxyServerPort + ")", rtbLog);
            }
           
            //Set timer intervals
            timer1.Interval = 
                (Int32.Parse(Properties.Settings.Default.A1Interval.ToString()) * 60000);
            timer2.Interval = 
                (Int32.Parse(Properties.Settings.Default.A2Interval.ToString()) * 60000);
            timer3.Interval =
                (Int32.Parse(Properties.Settings.Default.A3Interval.ToString()) * 60000);
            timer4.Interval =
                (Int32.Parse(Properties.Settings.Default.A4Interval.ToString()) * 60000);
            timer5.Interval =
                (Int32.Parse(Properties.Settings.Default.A5Interval.ToString()) * 60000);
            pauseTimer.Interval =
                (Int32.Parse(Properties.Settings.Default.AppPauseInterval.ToString()) * 3600000);

            //START TIMERS FOR USED ACCOUNTS (if enabled and username present)
            if (Properties.Settings.Default.A1EnableInterval && !String.IsNullOrEmpty(Properties.Settings.Default.A1Username))
            {
                timer1.Enabled = true;
                timer1.Start();
                timersRunning = true;
                SpiffyStuff.writeLog
                    (SpiffyText.String00012 + " \"" + Properties.Settings.Default.A1Name + "\" " + //checking
                        SpiffyText.String00013 + " " + Properties.Settings.Default.A1Interval + //every x
                        " " + SpiffyText.String00014, //minutes
                    rtbLog);
            }
            if (Properties.Settings.Default.A2EnableInterval && Properties.Settings.Default.A2Username != "")
            {
                timer2.Enabled = true;
                timer2.Start();
                timersRunning = true;
                SpiffyStuff.writeLog
                    (SpiffyText.String00012 + " \"" + Properties.Settings.Default.A2Name + "\" " + //checking
                        SpiffyText.String00013 + " " + Properties.Settings.Default.A2Interval + //every x
                        " " + SpiffyText.String00014, //minutes
                    rtbLog);
            }
            if (Properties.Settings.Default.A3EnableInterval && Properties.Settings.Default.A3Username != "")
            {
                timer3.Enabled = true;
                timer3.Start();
                timersRunning = true;
                SpiffyStuff.writeLog
                    (SpiffyText.String00012 + " \"" + Properties.Settings.Default.A3Name + "\" " + //checking
                        SpiffyText.String00013 + " " + Properties.Settings.Default.A3Interval + //every x
                        " " + SpiffyText.String00014, //minutes
                    rtbLog);
            }
            if (Properties.Settings.Default.A4EnableInterval && Properties.Settings.Default.A4Username != "")
            {
                timer4.Enabled = true;
                timer4.Start();
                timersRunning = true;
                SpiffyStuff.writeLog
                    (SpiffyText.String00012 + " \"" + Properties.Settings.Default.A4Name + "\" " + //checking
                        SpiffyText.String00013 + " " + Properties.Settings.Default.A4Interval + //every x
                        " " + SpiffyText.String00014, //minutes
                    rtbLog);
            }
            if (Properties.Settings.Default.A5EnableInterval && Properties.Settings.Default.A5Username != "")
            {
                timer5.Enabled = true;
                timer5.Start();
                timersRunning = true;
                SpiffyStuff.writeLog
                    (SpiffyText.String00012 + " \"" + Properties.Settings.Default.A5Name + "\" " + //checking
                        SpiffyText.String00013 + " " + Properties.Settings.Default.A5Interval + //every x
                        " " + SpiffyText.String00014, //minutes
                    rtbLog);
            }

            //SET CHECKBOX IN TRAY OPTIONS - TIMERS
            //Check if any timers are running and set tray item text and image
            if (timer1.Enabled || timer2.Enabled || timer3.Enabled || timer4.Enabled || timer5.Enabled)
            {
                enableTimersToolStripMenuItem.Checked = true;
                enableTimersToolStripMenuItem1.Checked = true;
                enableTimersToolStripMenuItem.Enabled = true;
                enableTimersToolStripMenuItem1.Enabled = true;                
                toolStripTimerLabel.Visible = false;
                timersRunning = true;
            }
            else
            {
                enableTimersToolStripMenuItem.Checked = false;
                enableTimersToolStripMenuItem1.Checked = false;
                enableTimersToolStripMenuItem.Enabled = false;
                enableTimersToolStripMenuItem1.Enabled = false;
                toolStripTimerLabel.Visible = true;
                timersRunning = false;
            }

            //SET CHECKBOX IN TRAY OPTIONS - ALERTS
            if (Properties.Settings.Default.AppAlertEnabled)
            {
                enableAlertsToolStripMenuItem.Checked = true;
            }
            else
            {
                enableAlertsToolStripMenuItem.Checked = false;
            }

            //SET CHECKBOX IN TRAY OPTIONS - SOUNDS
            if (Properties.Settings.Default.AppAlertSoundEnabled)
            {
                enableSoundsToolStripMenuItem.Checked = true;
            }
            else
            {
                enableSoundsToolStripMenuItem.Checked = false;
            }

            //Minimize to Tray (if enabled) (useless when AlwaysHideWindow is enabled)
            if (Properties.Settings.Default.AppStartMinimized)
            {
                SpiffyStuff.HideApp(this);
            }

            //Check only for new mail on Startup when minimized.
            if (Properties.Settings.Default.AppStartMinimized)
            {
                //Check for new mail if enabled
                if (Properties.Settings.Default.AppCheckforMailonStartup)
                {
                    SpiffyStuff.writeLog(SpiffyText.String00015, rtbLog); //checking for new mail now
                    checkNow();
                }
            }

            //Startup Version Check
            if (Properties.Settings.Default.AppCheckVersionOnStartup)
                SpiffyStuff.checkVersionStartup(notifyIcon1, rtbLog);

            //CHECK FOR OLD SAVE FILE AND SAVE SETTINGS (SPIFFY READS OLD CFG AT FIRST STARTUP)
            if (Properties.Settings.Default._spiffyVersion != appVersion)
            {     
                //Setting new version in current cfg file
                Properties.Settings.Default._spiffyVersion = appVersion;
                //and save settings

                SpiffyStuff.writeLog(SpiffyText.String00004 + "...", rtbLog); //new version detected
                SpiffyStuff.writeLog(SpiffyText.String00005 + "...", rtbLog);  //saving settings...
                SpiffyStuff.writeLog(SpiffyText.String00010, rtbLog);  //done!

                saveNow();
            }
        }

        #region Catch and Override System Events and Keys
        
        //Catch
        const int WM_SYSCOMMAND = 0x112;
        const int SC_CLOSE = 0xF060;
        const int SC_MINIMIZE = 0xF020;
        
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        //Override events
        protected override void WndProc(ref Message m)
        {
            
            if (m.Msg == WM_SYSCOMMAND)
            {
                // override form close button
                if (m.WParam.ToInt32() == SC_CLOSE && 
                        Properties.Settings.Default.AppCloseToTray == true)
                {
                    SpiffyStuff.HideApp(this);
                }
                // override form minimize button
                else if (m.WParam.ToInt32() == SC_MINIMIZE &&
                        Properties.Settings.Default.AppMinimizeToTray == true)
                {
                    SpiffyStuff.HideApp(this);
                }
            }

            base.WndProc(ref m);
            
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        //Override keys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) 
        {
            const int WM_KEYDOWN = 0x100;

            if (msg.Msg == WM_KEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        SpiffyStuff.HideApp(this);
                        break;

                    case Keys.F9:
                        checkNow();
                        break;

                    case Keys.F1:
                        SpiffyStuff.openHelpURL(String.Empty);
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion        

        #region Mail Methods
        //Checks all accounts for new mail
        public void checkforunreadMail(SpiffyAccount currentAccount, string userName, SecureString password, string domain,
            string label, bool checkLabel, bool googleApps, bool logtoLog)
        {
            //SHOW REFRESH ICON IN MAIN
            toolStripRefreshLabel.Visible = true;

            int totalUnread, realUnread, newUnread;
            bool showuntilRead = Properties.Settings.Default.AppAlertShowUntilRead;
            bool bIsCustom = Properties.Settings.Default.AppEnableCustomAlerts;
            bool bCheckLabel = checkLabel;

            //Remove ALL messages from TMA array for current account
            //when AppAlertShowUntilRead is enabled. (default = enabled)
            if (Properties.Settings.Default.AppAlertShowUntilRead)
            {
                #region remove items from tellmeagain array
                try
                {
                    int count = TMA.Count;
                    for (int i = 0; i < count; )
                    {
                        String[] item = (String[])TMA[i];
                        if (item.GetValue(0).ToString() == currentAccount.AccountName)
                        {
                            TMA.RemoveAt(i);
                            count--;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
                catch (Exception e4)
                {
                    SpiffyStuff.LogExceptionInfo(e4, "TMA remove 1", true);
                }
                #endregion
            }

            //CHECK FOR GMAIL OR GOOGLE APPS ACCOUNT AND SET FEED ADDRES FOR getUnreadCount
            if (googleApps == false) //GMAIL
            {
                SpiffyAtomFeed.FeedUrl = Properties.Settings.Default.AppFeedAddress;
            }
            else //APPS
            {
                SpiffyAtomFeed.FeedUrl = "https://mail.google.com/a/" + domain + "/feed/atom";
                userName = userName + "@" + domain; //set username for this domain
            }

            //SET USERNAME AND PASSWORD
            SpiffyAtomFeed gmailFeed = new SpiffyAtomFeed(userName, password);

            //TEXT ENCODING (for weird characters)
            Encoding coder = Encoding.GetEncoding(1252);

            //Sets custom label to check if Enabled otherwise set inbox (Empty)
            if (bCheckLabel)
            {
                gmailFeed.FeedLabel = label;                
            }

            //get LATEST unread count
            totalUnread = getUnreadCount(userName, password, label, checkLabel); //Total unread count
            realUnread = totalUnread; //save totalUnread for later use, continue with realUnread 

            //set max realUnread to 20 if totalUnread > 20 (Feed only shows last 20 mails)
            if (totalUnread > 20) realUnread = 20;

            //check realUnread uit vorige check -> if 0 (NO UNREAD) -> THEN NO NEW MAIL
            if (realUnread == 0) 
            {
                //CLEAR ACCOUNT
                currentAccount.AccountHasNewMail = false;
                currentAccount.AccountUnread = 0;
                currentAccount.AccountTotalUnread = 0;

                //CLEAR TELLMEAGAIN FOR THIS ACCOUNT - FIND ACCOUNT TMA's bij ACC NAME AND DELETE
                #region remove items from tellmeagain array
                try
                {                    
                    int count = TMA.Count;
                    for (int i = 0; i < count; )
                    {
                        String[] item = (String[])TMA[i];
                        if (item.GetValue(0).ToString() == currentAccount.AccountName)
                        {
                            TMA.RemoveAt(i);
                            count--;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
                catch (Exception e4a)
                {
                    SpiffyStuff.LogExceptionInfo(e4a, "TMA remove 2", true);
                }
                #endregion
            }
            //unread groter dan vorige dan nieuwe mails laten zien
            else if (realUnread > currentAccount.AccountUnread) //WE HAVE NEW MAIL
            {
                //SET NEW MAIL TO TRUE
                currentAccount.AccountHasNewMail = true;

                //Set total unread count for this account
                currentAccount.AccountTotalUnread = totalUnread; 

                //Calculate new nr of mails count (for loop)
                newUnread = realUnread - currentAccount.AccountUnread;

                //GET THE FEED :D
                gmailFeed.GetFeed();

                //PLAY SOUND EFFECT IF ENABLED
                if (Properties.Settings.Default.AppAlertSoundEnabled)
                {
                    if (currentAccount.AccountHasCustomAlert == false)
                    {
                        SpiffyStuff.playNewMailSound(Properties.Settings.Default.AppAlertSound);
                    }
                    else
                    {
                        SpiffyStuff.playNewMailSound(currentAccount.AccountCustomAlertPath);
                    }
                }

                #region while 'loop thru new mails'

                //set max alerts from settings
                int alertMax = Int32.Parse(Properties.Settings.Default.AppAlertShowNumber.ToString()); //grab from setting
                alertMax = alertMax - 1; //set minus 1 (newunread starts at 0)
                int alertsShown = 0;

                //Finally show alerts
                int i = 0; // i = messagenr (index)
                while (newUnread > i)
                {
                
                    #region try -> show alerts and set tell me again stuff
                    try
                    {
                        string recTime;
                        //Check if custom alert is enabled and show custom datetime
                        if (bIsCustom == false)
                        {
                            recTime = SpiffyStuff.convertGTime(
                                   gmailFeed.FeedEntries[i].Received, String.Empty);
                        }
                        else
                        {
                            recTime = SpiffyStuff.convertGTime(
                               gmailFeed.FeedEntries[i].Received,
                               Properties.Settings.Default.AppAlertDateTimeFormat);
                        }
                        string fromName = gmailFeed.FeedEntries[i].FromName;
                        string fromEmail = gmailFeed.FeedEntries[i].FromEmail;

                        string subEmail = gmailFeed.FeedEntries[i].Subject;
                        string sumEmail = gmailFeed.FeedEntries[i].Summary;
                        //string msgId = gmailFeed.FeedEntries[i].Id.Substring(26);

                        //LOG NEW MAIL
                        if (logtoLog) //used with checknow button
                        {
                            //new mail from (no account)
                            SpiffyStuff.writeLog(
                                SpiffyText.String00016 + " " + fromEmail, rtbLog);
                        }
                        else //used by timers
                        {
                            //new mail from (with account)
                            SpiffyStuff.writeLog(
                                SpiffyText.String00016 + " " + fromEmail + " (" + currentAccount.AccountName + ")", rtbLog); //new mail from
                        }

                        //SHOW ALERT IF ENABLED
                        if (Properties.Settings.Default.AppAlertEnabled)
                        {
                            //check max alerts
                            if (alertsShown <= alertMax)
                            {
                                //show it
                                showTrayAlert(currentAccount, fromName, fromEmail, subEmail, sumEmail, recTime);
                                
                                //increase nr of alerts shown
                                alertsShown++;
                                
                                //add message to tell me again array
                                string[] temp = new string[6] {
                                currentAccount.AccountName, fromName, fromEmail, subEmail, sumEmail, recTime};
                                try
                                {
                                    TMA.Add(temp);
                                }
                                catch (Exception e3)
                                {
                                    SpiffyStuff.LogExceptionInfo(e3, "checkNew() add", true);
                                }
                                //Clear temp string array
                                temp = null;
                            }
                        }

                        //GO TO NEXT NEWEST MESSAGE
                        i++;
                        
                        //END OF WHILE LOOP

                    }
                    catch (Exception gmailFeedGet)
                    {
                        SpiffyStuff.writeLog(
                            SpiffyText.String00023 + " (" + gmailFeedGet.Message + ")", rtbLog); //feed trouble
                        SpiffyStuff.LogExceptionInfo(gmailFeedGet, "checkNew()", true);
                    }
                    #endregion
                }
                #endregion

            }

            /*
             * Stuff that happens only once on new mail check
             */            

            #region Stuff that happens only once on new mail check for each account
            //write total new mail in log (only for checknow())
            //checkNow uses logtoLog true , timers use false to hide logging
            if (logtoLog)
            {
                if (totalUnread > 0)
                {
                    SpiffyStuff.writeLog(SpiffyText.String00022 + " " + currentAccount.AccountName + ": " + totalUnread, rtbLog); //total unread
                }
                else
                {
                    //If there is no connection getunreadCount returns negative values, if so hide 'no mail' message
                    if (totalUnread != -1 && totalUnread != -2)
                        SpiffyStuff.writeLog(SpiffyText.String00031 + " " + currentAccount.AccountName, rtbLog); //no unread
                }
            }
            
            
            //Set option to show alerts only once (if disabled) ie. 'sync after check'
            //Counter saves number of unread mails (realUnread) if option is disabled 
            //the counter stays at 0 and alert keeps showing.
            if (showuntilRead == false)
            {
                //reset unreadcounter to real unread (stays 0 if true)
                currentAccount.AccountUnread = realUnread;
            }

            //Enable tell me again stuff for each account (same as tray check) (OR)
            //must stay enabled if one account has new mail (OR) disable when alerts are disabled
            if (AC1.AccountHasNewMail
                || AC2.AccountHasNewMail
                || AC3.AccountHasNewMail
                || AC4.AccountHasNewMail
                || AC5.AccountHasNewMail)
            {
                if (Properties.Settings.Default.AppAlertEnabled) //only enable buttons when alerts are enabled
                {
                    tellMeAgainToolStripMenuItem.Enabled = true;
                    toolStripButtonTellMeAgain.Enabled = true;
                }
            }

            //Finally check if there's new mail for ANY account and change tray icon (if enabled)
            //must stay enabled if one account has new mail
            if (Properties.Settings.Default.AppTrayIconChange)
            {
                if (AC1.AccountHasNewMail 
                    || AC2.AccountHasNewMail 
                    || AC3.AccountHasNewMail 
                    || AC4.AccountHasNewMail 
                    || AC5.AccountHasNewMail)
                {
                    SpiffyStuff.changeTrayicon(notifyIcon1, true);
                }
                else //if no newmails
                {
                    //reset new mail trayicon, no matter what
                    SpiffyStuff.changeTrayicon(notifyIcon1, false);
                }
            }

            //If NONE of the accounts has new mail, disable tell me again... (AND)
            if (AC1.AccountHasNewMail == false 
                && AC2.AccountHasNewMail == false 
                && AC3.AccountHasNewMail == false 
                && AC4.AccountHasNewMail == false 
                && AC5.AccountHasNewMail == false)
            {
                tellMeAgainToolStripMenuItem.Enabled = false;
                toolStripButtonTellMeAgain.Enabled = false;
            }
            #endregion

            //CLEANUP
            if (gmailFeed != null) gmailFeed = null;

            //HIDE REFRESH ICON IN MAIN
            toolStripRefreshLabel.Visible = false;

        }

        //Get's unreadcount for specified account - INT
        private int getUnreadCount(string username, SecureString password, string label, bool checkLabel)
        {
            string gmailstatus;

            if (Properties.Settings.Default.AppCheckForConnection)
            {
                gmailstatus = SpiffyStuff.connectionStatus("https://mail.google.com");
            }
            else
            {
                gmailstatus = "SKIP"; //hardcoded option to know if AppCheckForConnection was used, only for debug logging
            }

            if (gmailstatus == "OK" || gmailstatus == "SKIP")
            {
                SpiffyAtomFeed.FeedUrl = Properties.Settings.Default.AppFeedAddress;
                try
                {
                    SpiffyAtomFeed gmailFeed = new SpiffyAtomFeed(username, password);

                    //Set custom label if enabled
                    if (checkLabel)
                        gmailFeed.FeedLabel = label;

                    gmailFeed.GetFeed();

                    XmlDocument myXml = gmailFeed.FeedXml;
                    int fullcount = Int32.Parse(myXml.GetElementsByTagName("fullcount")[0].ChildNodes[0].Value);

                    //cleanup
                    if (gmailFeed != null) gmailFeed = null;
                    if (myXml != null) myXml = null;
                    
                    return fullcount;
                }
                catch (NullReferenceException e1)
                {
                    SpiffyStuff.writeLog(
                        SpiffyText.String00024 + " (Error -1)", rtbLog); //error connecting to gmail
                    SpiffyStuff.writeErrorLog("getUnreadCount() Error -1");
                    SpiffyStuff.LogExceptionInfo(e1, "Connection Status: " + gmailstatus, true);
                    return -1;
                }
            }
            else //show whatever is going on
            {
                SpiffyStuff.writeLog(
                    SpiffyText.String00024 + " (" + gmailstatus + ")", rtbLog); //error connecting to gmail
                SpiffyStuff.writeErrorLog("getUnreadCount() Error -2");
                SpiffyStuff.writeErrorLog("Connection Status: " + gmailstatus);
                return -2;
            }
            
        }
      
        //Shows Alert
        public void showTrayAlert(SpiffyAccount account, string name, string email, string subject, string summary, string received)
        {
            //Init notifier
            SpiffyPopup notifier = InitSpiffyPopup(new SpiffyPopup());

            //ADD CLICK EVENT FOR MESSAGE FIELD
            notifier.ContentClick += new EventHandler<SpiffyAlertEventArgs>(notifier_ContentClick);

            //Window text (shown in ALT-TAB)
            notifier.Text = "Spiffy - " + subject;

            //SHOW THE ALERT
            notifier.Show(account.AccountName, account.AccountUrl, name, email, subject, summary, received,
                Int32.Parse(Properties.Settings.Default.AppAlertShowDelay.ToString()), //showing in... ms
                Int32.Parse(Properties.Settings.Default.AppAlertDelay.ToString()) * 1000, //staying for... ms
                Int32.Parse(Properties.Settings.Default.AppAlertHideDelay.ToString()) //hiding in ... ms
                );
        }

        void notifier_ContentClick(object sender, SpiffyAlertEventArgs e)
        {
            //e.Url comes from SpiffyAlertEventArgs in SpiffyPopup (sets contentURL in InitializeAccounts())
            SpiffyStuff.openURL(e.Url);
        }

        //Mail check helper
        public void disableButtonsBeforeNewMailCheck()
        {
            //SHOW REFRESH ICON IN MAIN
            toolStripRefreshLabel.Visible = true;

            //Disable buttons
            toolStripButton2.Enabled = false;
            toolStripButton4.Enabled = false;
            checkNowToolStripMenuItem.Enabled = false;
            checkNowToolStripMenuItem1.Enabled = false;
            checkNowToolStripMenuItem2.Enabled = false;
            toolStripButtonTellMeAgain.Enabled = false;
            tellMeAgainToolStripMenuItem.Enabled = false;

            this.Refresh();
        }

        //Mail check helper
        public void enableButtonsAfterNewMailCheck()
        {
            //HIDE REFRESH ICON IN MAIN
            toolStripRefreshLabel.Visible = false;

            //Enable buttons again and refresh
            toolStripButton2.Enabled = true;
            toolStripButton4.Enabled = true;
            checkNowToolStripMenuItem.Enabled = true;
            checkNowToolStripMenuItem1.Enabled = true;
            checkNowToolStripMenuItem2.Enabled = true;
            
            //TMA button is set by checkNew()
            //toolStripButtonTellMeAgain.Enabled = true; 
            //tellMeAgainToolStripMenuItem.Enabled = true;

            this.Refresh();
        }

        //Checknow (for button clicks)
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void checkNow()
        {
            //Disable buttons
            disableButtonsBeforeNewMailCheck();

            //Set wait cursor
            this.Cursor = Cursors.WaitCursor;

            if (Properties.Settings.Default.A1Username != "" &&
                Properties.Settings.Default.A1Password != "")
            {
                SpiffyStuff.writeLog(SpiffyText.String00012 + " " + AC1.AccountName + "...", rtbLog); //checking account nr
                checkforunreadMail(
                    AC1,
                    Properties.Settings.Default.A1Username,
                    getPwd(1),
                    Properties.Settings.Default.A1GoogleAppsDomain,
                    Properties.Settings.Default.A1Label,
                    Properties.Settings.Default.A1CheckLabel,
                    Properties.Settings.Default.A1GoogleApps, true
                    );
            }
            else
            {
                SpiffyStuff.writeLog(SpiffyText.String00028 + " (" + AC1.AccountName + ")", rtbLog); //no account info
            }

            System.Threading.Thread.Sleep(500); //wait a bit

            if (Properties.Settings.Default.A2Username != "" &&
                Properties.Settings.Default.A2Password != "")
            {
                SpiffyStuff.writeLog(SpiffyText.String00012 + " " + AC2.AccountName + "...", rtbLog);
                checkforunreadMail(
                    AC2,
                    Properties.Settings.Default.A2Username,
                    getPwd(2),
                    Properties.Settings.Default.A2GoogleAppsDomain,
                    Properties.Settings.Default.A2Label,
                    Properties.Settings.Default.A2CheckLabel,
                    Properties.Settings.Default.A2GoogleApps, true
                    );
            }
            else
            {
                //SpiffyStuff.writeLog("No account info (Account 2)", rtbLog);
            }

            System.Threading.Thread.Sleep(500); //wait a bit

            if (Properties.Settings.Default.A3Username != "" &&
                Properties.Settings.Default.A3Password != "")
            {
                SpiffyStuff.writeLog(SpiffyText.String00012 + " " + AC3.AccountName + "...", rtbLog);
                checkforunreadMail(
                    AC3,
                    Properties.Settings.Default.A3Username,
                    getPwd(3),
                    Properties.Settings.Default.A3GoogleAppsDomain,
                    Properties.Settings.Default.A3Label,
                    Properties.Settings.Default.A3CheckLabel,
                    Properties.Settings.Default.A3GoogleApps, true
                    );
            }
            else
            {
                //SpiffyStuff.writeLog("No account info (Account 3)", rtbLog);
            }

            System.Threading.Thread.Sleep(500); //wait a bit

            if (Properties.Settings.Default.A4Username != "" &&
                Properties.Settings.Default.A4Password != "")
            {
                SpiffyStuff.writeLog(SpiffyText.String00012 + " " + AC4.AccountName + "...", rtbLog);
                checkforunreadMail(
                    AC4,
                    Properties.Settings.Default.A4Username,
                    getPwd(4),
                    Properties.Settings.Default.A4GoogleAppsDomain,
                    Properties.Settings.Default.A4Label,
                    Properties.Settings.Default.A4CheckLabel,
                    Properties.Settings.Default.A4GoogleApps, true
                    );
            }
            else
            {
                //SpiffyStuff.writeLog("No account info (Account 4)", rtbLog);
            }

            System.Threading.Thread.Sleep(500); //wait a bit

            if (Properties.Settings.Default.A5Username != "" &&
                Properties.Settings.Default.A5Password != "")
            {
                SpiffyStuff.writeLog(SpiffyText.String00012 + " " + AC5.AccountName + "...", rtbLog);
                checkforunreadMail(
                    AC5,
                    Properties.Settings.Default.A5Username,
                    getPwd(5),
                    Properties.Settings.Default.A5GoogleAppsDomain,
                    Properties.Settings.Default.A5Label,
                    Properties.Settings.Default.A5CheckLabel,
                    Properties.Settings.Default.A5GoogleApps, true
                    );
            }
            else
            {
                //SpiffyStuff.writeLog("No account info (Account 5)", rtbLog);
            }

            //Enable buttons
            enableButtonsAfterNewMailCheck();

            //Cursor back to default
            this.Cursor = Cursors.Default;

            //Check unread count in tray text
            checkTraytext();

            //Say we are done
            SpiffyStuff.writeLog(SpiffyText.String00027, rtbLog);
        }
        #endregion

        #region Save function
        public void saveNow()
        {
            //Log save to file
            SpiffyStuff.writeErrorLog("saveNow()");

            //This prevents saving Location as -32000,-32000 when app is minimized
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.AppWindowLocation = this.Location;
                Properties.Settings.Default.AppWindowSize = this.Size;
            }
            else
            {
                Properties.Settings.Default.AppWindowLocation = this.RestoreBounds.Location;
                Properties.Settings.Default.AppWindowSize = this.RestoreBounds.Size;
            }

            //Save
            Properties.Settings.Default.Save();
        }
        #endregion

        #region Misc Methods
        
        //Sets real mem usage in taskman (call every 15 seconds (timer))
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            try
            {
                NativeMethods.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch (Exception mem)
            {
                SpiffyStuff.LogExceptionInfo(mem, "FM()", true);
            }
        }

        //Builds timestamp
        public static DateTime BuildTime()
        {
            string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            byte[] b = new byte[2048];
            System.IO.Stream s = null;

            try
            {
                s = new System.IO.FileStream
                    (filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }
            
            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
            dt = dt.AddSeconds(secondsSince1970);
            //dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
            return dt;
        }

        /// <summary>
        //Gets decrypted password from account nr
        /// </summary>
        public static SecureString getPwd(int account)
        {
            switch (account)
            {
                case 1:
                    return SpiffyStuff.DecryptString(Properties.Settings.Default.A1Password);
                case 2:
                    return SpiffyStuff.DecryptString(Properties.Settings.Default.A2Password);
                case 3:
                    return SpiffyStuff.DecryptString(Properties.Settings.Default.A3Password);
                case 4:
                    return SpiffyStuff.DecryptString(Properties.Settings.Default.A4Password);
                case 5:
                    return SpiffyStuff.DecryptString(Properties.Settings.Default.A5Password);

                default:
                    return null;
            }
        }
      
        //Sync account timers method
        public void syncAccountTimer(SpiffyAccount account, System.Windows.Forms.Timer timer,
            Decimal interval, Boolean enabled, Boolean logactiontoLog)
        {
            timer.Interval = (Int32.Parse(interval.ToString()) * 60000);
            switch (enabled)
            {
                case true:
                    timer.Stop();
                    timer.Enabled = false; //off and on again
                    timer.Enabled = true;
                    timer.Start();
                    if (logactiontoLog)
                    {
                        SpiffyStuff.writeLog
                            (SpiffyText.String00012 + " \"" + account.AccountName + "\" " +
                            SpiffyText.String00013 + " " + interval + " " +
                            SpiffyText.String00014, //checking [account] every [x] minutes
                            rtbLog);
                    }
                    break;

                case false:
                    timer.Stop();
                    timer.Enabled = false;
                    break;
            }
        }

        //Syncs account timers etc
        public void syncAccounts(Boolean logtoLog)
        {
            //Re initialize accounts
            InitializeAccounts();

            //Reset tray text
            notifyIcon1.Text = Properties.Settings.Default.AppWindowTitleText;

            //Check timers
            syncAccountTimer(
                AC1, timer1,
                Properties.Settings.Default.A1Interval,
                Properties.Settings.Default.A1EnableInterval, logtoLog);

            syncAccountTimer(
                AC2, timer2,
                Properties.Settings.Default.A2Interval,
                Properties.Settings.Default.A2EnableInterval, logtoLog);

            syncAccountTimer(
                AC3, timer3,
                Properties.Settings.Default.A3Interval,
                Properties.Settings.Default.A3EnableInterval, logtoLog);

            syncAccountTimer(
                AC4, timer4,
                Properties.Settings.Default.A4Interval,
                Properties.Settings.Default.A4EnableInterval, logtoLog);

            syncAccountTimer(
                AC5, timer5,
                Properties.Settings.Default.A5Interval,
                Properties.Settings.Default.A5EnableInterval, logtoLog);

            //Check if any timers are running and set toolstrip item text and image
            if (timer1.Enabled || timer2.Enabled || timer3.Enabled || timer4.Enabled || timer5.Enabled)
            {
                enableTimersToolStripMenuItem.Checked = true;
                enableTimersToolStripMenuItem1.Checked = true;
                enableTimersToolStripMenuItem.Enabled = true;
                enableTimersToolStripMenuItem1.Enabled = true;
                toolStripTimerLabel.Visible = false;
                timersRunning = true;
            }
            else
            {
                enableTimersToolStripMenuItem.Checked = false;
                enableTimersToolStripMenuItem1.Checked = false;
                enableTimersToolStripMenuItem.Enabled = false;
                enableTimersToolStripMenuItem1.Enabled = false;
                toolStripTimerLabel.Visible = true;
                timersRunning = false;
            }
        }

        //Syncs settings after Save
        public void syncSettings()
        {
            //GENERAL
            // RUN AT LOGON
            RegistryKey rkRun = Registry.CurrentUser.OpenSubKey(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            switch (Properties.Settings.Default.AppRunAtLogon)
            {
                case true:
                    rkRun.SetValue("Spiffy", "\"" + Application.ExecutablePath + "\"");
                    break;

                case false:
                    rkRun.DeleteValue("Spiffy", false);
                    break;

            }
            rkRun.Close();

            // TRAY ICON CHECK (SET TO NEW MAIL ICON IF NEEDED, ELSE JUST RESET)
            if (Properties.Settings.Default.AppTrayIconChange)
            {
                if (AC1.AccountHasNewMail
                    || AC2.AccountHasNewMail
                    || AC3.AccountHasNewMail
                    || AC4.AccountHasNewMail
                    || AC5.AccountHasNewMail)
                {
                    SpiffyStuff.changeTrayicon(notifyIcon1, true);
                }
                else //if no newmails
                {
                    //reset new mail trayicon, no matter what
                    SpiffyStuff.changeTrayicon(notifyIcon1, false);
                }
            }
            else //JUST RESET
            {
                SpiffyStuff.changeTrayicon(notifyIcon1);
            }

            //GENERAL - PAUSE TIMER RE-SET
            pauseTimer.Interval =
                (Int32.Parse(Properties.Settings.Default.AppPauseInterval.ToString()) * 3600000);

            //GUI
            //Size
            this.Size = Properties.Settings.Default.AppWindowSize;

            //Opacity
            this.Opacity = (Double.Parse(Properties.Settings.Default.AppOpacity.ToString()) / 100);

            //Set Window Title & Tray Text
            this.Text = Properties.Settings.Default.AppWindowTitleText;
            notifyIcon1.Text = Properties.Settings.Default.AppWindowTitleText;

            //SET CHECKBOX IN TRAY OPTIONS - PROXY
            //And set toolstrip menu item text and toolbar image
            if (Properties.Settings.Default.proxyEnabled)
            {
                useProxyToolStripMenuItem.Checked = true;
                enableProxyFromTrayToolStripMenuItem.Checked = true;
                toolStripProxyLabel.Visible = true;
            }
            else //if disabled
            {
                useProxyToolStripMenuItem.Checked = false;
                enableProxyFromTrayToolStripMenuItem.Checked = false;
                toolStripProxyLabel.Visible = false;
            }

            //SET CHECKBOX IN TRAY OPTIONS - ALERTS
            if (Properties.Settings.Default.AppAlertEnabled)
            {
                enableAlertsToolStripMenuItem.Checked = true;
            }
            else
            {
                enableAlertsToolStripMenuItem.Checked = false;
            }

            //SET CHECKBOX IN TRAY OPTIONS - SOUNDS
            if (Properties.Settings.Default.AppAlertSoundEnabled)
            {
                enableSoundsToolStripMenuItem.Checked = true;
            }
            else
            {
                enableSoundsToolStripMenuItem.Checked = false;
            }

            //Log Window Font
            rtbLog.Font = new System.Drawing.Font(
                Properties.Settings.Default.AppLogDefaultFontName,
                float.Parse(Properties.Settings.Default.AppLogDefaultFontSize));

            this.Refresh();
        }

        //Tell me again
        public void tellMeAgain()
        {
            foreach (String[] s in TMA)
            {
                //Check if any account name is in TMA array and show that alert
                if (s.GetValue(0).ToString() == AC1.AccountName)
                {
                    showTrayAlert(
                                AC1,
                                s.GetValue(1).ToString(),
                                s.GetValue(2).ToString(),
                                s.GetValue(3).ToString(),
                                s.GetValue(4).ToString(),
                                s.GetValue(5).ToString());
                }
                if (s.GetValue(0).ToString() == AC2.AccountName)
                {
                    showTrayAlert(
                                AC2,
                                s.GetValue(1).ToString(),
                                s.GetValue(2).ToString(),
                                s.GetValue(3).ToString(),
                                s.GetValue(4).ToString(),
                                s.GetValue(5).ToString());
                }
                if (s.GetValue(0).ToString() == AC3.AccountName)
                {
                    showTrayAlert(
                                AC3,
                                s.GetValue(1).ToString(),
                                s.GetValue(2).ToString(),
                                s.GetValue(3).ToString(),
                                s.GetValue(4).ToString(),
                                s.GetValue(5).ToString());
                }
                if (s.GetValue(0).ToString() == AC4.AccountName)
                {
                    showTrayAlert(
                                AC4,
                                s.GetValue(1).ToString(),
                                s.GetValue(2).ToString(),
                                s.GetValue(3).ToString(),
                                s.GetValue(4).ToString(),
                                s.GetValue(5).ToString());
                }
                if (s.GetValue(0).ToString() == AC5.AccountName)
                {
                    showTrayAlert(
                                AC5,
                                s.GetValue(1).ToString(),
                                s.GetValue(2).ToString(),
                                s.GetValue(3).ToString(),
                                s.GetValue(4).ToString(),
                                s.GetValue(5).ToString());
                }
            }
        }

        //Returns notifier instance with options - When changing this also change options_customize_popup.InitSpiffyPopup
        public static SpiffyPopup InitSpiffyPopup(SpiffyPopup notifier)
        {
            //Check if custom notifier is enabled
            if (Properties.Settings.Default.AppEnableCustomAlerts)
            {
                if(!String.IsNullOrEmpty(Properties.Settings.Default.AppCustomAlertBackgroundPath) && 
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

                #region Rectangles (check if enabled and create)
                //Close
                notifier.CloseRectangle = new Rectangle(
                    Int32.Parse(Properties.Settings.Default.AppAlertCloseAreaX.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertCloseAreaY.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertCloseAreaW.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertCloseAreaH.ToString())
                    );
                //Title
                if(Properties.Settings.Default.AppAlertTitleEnabled)
                notifier.TitleRectangle = new Rectangle(
                    Int32.Parse(Properties.Settings.Default.AppAlertTitleX.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertTitleY.ToString()), 
                    Int32.Parse(Properties.Settings.Default.AppAlertTitleW.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertTitleH.ToString())
                    );
                //Time
                if(Properties.Settings.Default.AppAlertTimeEnabled)
                notifier.TimeRectangle = new Rectangle(
                    Int32.Parse(Properties.Settings.Default.AppAlertTimeX.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertTimeY.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertTimeW.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertTimeH.ToString())
                    );
                //Name / From
                if(Properties.Settings.Default.AppAlertFromEnabled)
                notifier.NameRectangle = new Rectangle(
                    Int32.Parse(Properties.Settings.Default.AppAlertFromX.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertFromY.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertFromW.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertFromH.ToString())
                    );
                //Subject
                if(Properties.Settings.Default.AppAlertSubjectEnabled)
                notifier.SubjectRectangle = new Rectangle(
                    Int32.Parse(Properties.Settings.Default.AppAlertSubjectX.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertSubjectY.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertSubjectW.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertSubjectH.ToString())
                    );
                //Message / Content
                if(Properties.Settings.Default.AppAlertMessageEnabled)
                notifier.ContentRectangle = new Rectangle(
                    Int32.Parse(Properties.Settings.Default.AppAlertMessageX.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertMessageY.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertMessageW.ToString()),
                    Int32.Parse(Properties.Settings.Default.AppAlertMessageH.ToString())
                    );
                #endregion

                //Change font
                notifier.CustomFont = new Font(Properties.Settings.Default.AppAlertCustomFont,
                    float.Parse(Properties.Settings.Default.AppAlertCustomFontSize), GraphicsUnit.Pixel);

            }
            else //Else show default skin and settings 352*72
            {
                notifier.SetBackgroundBitmap(
                    Properties.Resources.skin_default,
                    Color.FromArgb(255, 0, 255));

                notifier.CloseRectangle = new Rectangle(338, 3, 12, 15);
                notifier.TitleRectangle = new Rectangle(47, 4, 160, 14);
                notifier.TimeRectangle = new Rectangle(216, 4, 120, 14);             
                notifier.NameRectangle = new Rectangle(47, 20, 310, 14);
                notifier.SubjectRectangle = new Rectangle(47, 37, 310, 14);
                notifier.ContentRectangle = new Rectangle(47, 54, 310, 14);
            }

            //Set misc options
            notifier.CloseClickable = Properties.Settings.Default.AppAlertCloseClickable;
            notifier.ContentClickable = Properties.Settings.Default.AppAlertMessageLineClickable;
            notifier.KeepVisibleOnMousOver = Properties.Settings.Default.AppAlertKeepVisibleOnMouseOver;
            notifier.ReShowOnMouseOver = Properties.Settings.Default.AppAlertReShowOnMouseOver;
            notifier.AppearBySliding = Properties.Settings.Default.AppAlertSliding;            
            notifier.Padding = 2;

            //Return created notifier
            return notifier;
        }

        //Returns Spiffy account instance with options
        public static SpiffyAccount InitSpiffyAccount(SpiffyAccount account)
        {
            account.AccountHasNewMail = false;
            account.AccountUnread = 0;
            account.AccountTotalUnread = 0;
            return account;
        }

        //Creates Google Apps account url if needed, used in InitAccounts
        private static string createAccountUrl(bool isApps, string domain)
        {
            if (isApps)
            {
                return Properties.Resources.AppStringGmailAppsURL + domain;
            }
            else
            {
                return Properties.Resources.AppStringGmailURL;
            }
        }

        //Clear Log Window
        public void clearLogWindow()
        {
            rtbLog.Clear();
            //Startup messages
            SpiffyStuff.writeLog("Spiffy " + appVersion, rtbLog);
            try
            {
                SpiffyStuff.writeLog(SpiffyText.String00003 + " " + //build
                    AppBuild, rtbLog);
            }
            catch (Exception buildStringClearLog)
            {
                SpiffyStuff.LogExceptionInfo(buildStringClearLog, "clearLogWindow", true);
            }
        }

        //Checks if tray text need update or not (for unread counts)
        public void checkTraytext()
        {
            //Set tray text (if enabled)
            if (Properties.Settings.Default.AppShowUnreadInTray)
            {
                switch (Properties.Settings.Default.AppShowUnreadInTrayAccountNr)
                {
                    case 1:
                        SpiffyStuff.UpdateUnreadCountInTray(notifyIcon1, AC1, 0);
                        break;

                    case 2:
                        SpiffyStuff.UpdateUnreadCountInTray(notifyIcon1, AC2, 0);
                        break;

                    case 3:
                        SpiffyStuff.UpdateUnreadCountInTray(notifyIcon1, AC3, 0);
                        break;

                    case 4:
                        SpiffyStuff.UpdateUnreadCountInTray(notifyIcon1, AC4, 0);
                        break;

                    case 5:
                        SpiffyStuff.UpdateUnreadCountInTray(notifyIcon1, AC5, 0);
                        break;

                    case 6:
                        int totalunread = AC1.AccountTotalUnread +
                            AC2.AccountTotalUnread +
                            AC3.AccountTotalUnread +
                            AC4.AccountTotalUnread +
                            AC5.AccountTotalUnread;
                        SpiffyStuff.UpdateUnreadCountInTray(notifyIcon1, null, totalunread);
                        break;

                                            
                }
            }
        }

        //Check Open Gmail location (default, custom or mail client)
        private static void openGmail(string option)
        {
            switch(option)
            {
                case "":
                    SpiffyStuff.openURL(Properties.Resources.AppStringGmailURL);
                    break;

                case "custom":
                    //new in 0.5.2 (hidden feature)
                    if (Properties.Settings.Default.AppCustomGmailLocation.StartsWith("@"))
                    {
                        //split the command with * and remove the @
                        string[] cmd = Properties.Settings.Default.AppCustomGmailLocation.Remove(0, 1).Split('*');
                        Process p = new Process();
                        if (cmd.Length > 1)
                        {
                            p.StartInfo = new ProcessStartInfo(cmd[0], cmd[1]);
                        }
                        else
                        {
                            p.StartInfo = new ProcessStartInfo(cmd[0]);
                        }
                        p.Start();

                        //clean
                        p.Dispose();
                    }
                    else //act normal
                    {
                        SpiffyStuff.openURL(Properties.Settings.Default.AppCustomGmailLocation);
                    }
                    break;

                case "client": //not used now
                    startMailClient();
                    break;
            }
        }

        //Starts application read from pathToMailClient()
        public static void startMailClient()
        {
            string client = SpiffyStuff.pathToMailClient();
            
            //stand back! filtering out specific mail clients...
            
            try
            {
                //Microsoft Outlook
                if ((client.Contains("Office") || client.Contains("OFFICE")) &&
                    (client.Contains("outlook.exe") || client.Contains("OUTLOOK.EXE"))
                    )
                {
                    if (client.Contains("recycle")) //if it has /recylce argument split it
                    {
                        string tmp = client.Replace(" /recycle", "");
                        Process.Start(tmp, "/recycle"); //adding recycle tries to open existing window
                    } 
                    else //no args just run it
                    {
                        Process.Start(client);
                    }
                }
                //Mozilla Thunderbird
                if (client.Contains("thunderbird") || client.Contains("Thunderbird"))
                {
                    if (client.Contains("-mail")) //if it has the -mail argument split it
                    {
                        string tmp = client.Replace(" -mail", "");
                        Process.Start(tmp, "-mail");
                    }
                    else //no args just run it
                    {
                        Process.Start(client);                        
                    }
                }
                else //other client, fingers crossed
                {
                    SpiffyStuff.writeErrorLog("Other mail client: " + client);
                    Process.Start(client);
                }
            }
            catch (Exception E13) //No mail client or unknown client
            {
                SpiffyStuff.LogExceptionInfo(E13, "startMailClient (E13)", true);
            }
        }
        #endregion

        #region Menu click methods -> IMPORTANT =)
        public void showOptions()
        {
            SpiffyOptions so = new SpiffyOptions();
            so.mainForm = this; //form 1 reference for options form (access controls)
            so.Show();
        }

        public void showAccounts()
        {
            SpiffyAccountsForm saf = new SpiffyAccountsForm();
            saf.mainForm = this; //form 1 reference for accounts form (access controls)
            saf.Show();
        }

        public static void showAbout()
        {
            SpiffyAbout sa = new SpiffyAbout();
            sa.ShowDialog();
            sa.Dispose();
        }

        //public static void reportProblem() //disabled in 0.5.10
        //{
        //    //clicking ok opens spiffy help etc
        //    DialogResult dr = MessageBox.Show
        //        (SpiffyText.String00031 + "\n" +
        //         SpiffyText.String00032 + "\n\n" +
        //         SpiffyText.String00033 + " spiffyhq@gmail.com",
        //         "Spiffy", 
        //        MessageBoxButtons.OKCancel);
        //    if (dr == DialogResult.OK)
        //    {
        //        SpiffyStuff.openURL(Properties.Resources.AppStringReportProblemURL);
        //    }
        //}

        public void toggleTimers()
        {
            switch (timersRunning)
            {
                case true: 
                    SpiffyStuff.stopTimers(timer1, timer2, timer3, timer4, timer5, rtbLog);
                    timersRunning = false;
                    enableTimersToolStripMenuItem.Checked = false;
                    enableTimersToolStripMenuItem1.Checked = false;
                    toolStripTimerLabel.Visible = true;

                    if (this.WindowState == FormWindowState.Minimized)
                        notifyIcon1.ShowBalloonTip(3,
                            "Spiffy",
                            SpiffyText.String00036, ToolTipIcon.Info); //stopped checking for new mail

                    if (Properties.Settings.Default.AppPauseIntervalEnabled)
                    {
                        //start pausetimer
                        pauseTimer.Interval =
                            ((Int32.Parse(Properties.Settings.Default.AppPauseInterval.ToString()) * 3600000));
                        pauseTimer.Enabled = true;
                        pauseTimer.Start();
                        SpiffyStuff.writeLog(SpiffyText.String00039 + " " + SpiffyText.String00040 + //restarting timers in
                            " " + Properties.Settings.Default.AppPauseInterval + " " +
                            SpiffyText.String00041, rtbLog); //hours
                    }

                    break;

                case false:
                    SpiffyStuff.startTimers(timer1, timer2, timer3, timer4, timer5, rtbLog);
                    timersRunning = true;

                    enableTimersToolStripMenuItem.Checked = true;
                    enableTimersToolStripMenuItem1.Checked = true;
                    toolStripTimerLabel.Visible = false;

                    //Show ballontip of minimized
                    if(this.WindowState == FormWindowState.Minimized)
                        notifyIcon1.ShowBalloonTip(3,
                            "Spiffy",
                            SpiffyText.String00037, ToolTipIcon.Info); //started checking for new mail

                    //stop pausetimer
                    pauseTimer.Stop();
                    pauseTimer.Enabled = false;                    

                    break;
            }
        }

        public void toggleProxy()
        {
            string server = Properties.Settings.Default.proxyServerName;
            string port = Properties.Settings.Default.proxyServerPort;

            if (!String.IsNullOrEmpty(server) || !String.IsNullOrEmpty(port))
            {
                //if proxy is enabled, disable it
                if (Properties.Settings.Default.proxyEnabled)
                {
                    Properties.Settings.Default.proxyEnabled = false;
                    useProxyToolStripMenuItem.Checked = false;
                    enableProxyFromTrayToolStripMenuItem.Checked = false;
                    toolStripProxyLabel.Visible = false;
                    SpiffyStuff.writeLog(SpiffyText.String00017, rtbLog); //proxy disabled
                    saveNow();
                }
                //if proxy is disabled, enable it
                else
                {
                    Properties.Settings.Default.proxyEnabled = true;
                    useProxyToolStripMenuItem.Checked = true;
                    enableProxyFromTrayToolStripMenuItem.Checked = true;
                    toolStripProxyLabel.Visible = true;
                    SpiffyStuff.writeLog(SpiffyText.String00018 + " (" + server + ":" + port + ")", rtbLog); //proxy enabled
                    saveNow();
                }
            }
            else
            {
                SpiffyStuff.writeLog(SpiffyText.String00333, rtbLog); //warning no proxy server or port entered
            }
        }

        public void toggleView()
        {
            if (Properties.Settings.Default.AppShowLog) //if true show static (or hide rtb)
            {
                Properties.Settings.Default.AppShowLog = false;
                hideLogToolStripMenuItem.Image = Properties.Resources.application_get;
                hideLogToolStripMenuItem.Text = SpiffyText.String00105; //reverse text -> show log
                hideLogToolStripMenuItem1.Image = Properties.Resources.application_get;
                hideLogToolStripMenuItem1.Text = SpiffyText.String00105; //show log
                rtbLog.Visible = false;
                saveNow();
            }
            else //if false hide static (or show rtb)
            {
                Properties.Settings.Default.AppShowLog = true;
                hideLogToolStripMenuItem.Image = Properties.Resources.application_put;
                hideLogToolStripMenuItem.Text = SpiffyText.String00104; //reverse text -> hide log
                hideLogToolStripMenuItem1.Image = Properties.Resources.application_put;
                hideLogToolStripMenuItem1.Text = SpiffyText.String00104; //hide log
                rtbLog.Visible = true;
                rtbLog.ScrollToCaret();
                saveNow();
            }
        }

        public void exitSpiffy()
        {
            //Log exit to file
            SpiffyStuff.writeErrorLog("exitSpiffy()");

            //This prevents saving Location as -32000,-32000 when app is minimized
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.AppWindowLocation = this.Location;
                Properties.Settings.Default.AppWindowSize = this.Size;
            }
            else
            {
                Properties.Settings.Default.AppWindowLocation = this.RestoreBounds.Location;
                Properties.Settings.Default.AppWindowSize = this.RestoreBounds.Size;
            }

            //Save
            Properties.Settings.Default.Save();
            Application.Exit();
        }        

        private void toggleMainWindow()
        {
            //if enabled, disable it
            if (Properties.Settings.Default.AlwaysHideMainWindow)
            {
                alwaysHideWindowToolStripMenuItem.Checked = false;
                Properties.Settings.Default.AlwaysHideMainWindow = false;
                SpiffyStuff.writeErrorLog("toggleMainWindow(disable)");
                saveNow();
            }
            //if disabled, enable it
            else
            {
                alwaysHideWindowToolStripMenuItem.Checked = true;
                Properties.Settings.Default.AlwaysHideMainWindow = true;
                SpiffyStuff.writeErrorLog("toggleMainWindow(enable)");
                saveNow();
                //And hide
                SpiffyStuff.HideApp(this); 
            }
        }

        public void toggleSound()
        {
            //if sound is enabled, disable it
            if (Properties.Settings.Default.AppAlertSoundEnabled)
            {
                Properties.Settings.Default.AppAlertSoundEnabled = false; //disable
                enableSoundsToolStripMenuItem.Checked = false;
                SpiffyStuff.writeLog(SpiffyText.String00020, rtbLog); //sound disabled
                saveNow();
            }
            //if sound is disabled, enable it
            else
            {
                Properties.Settings.Default.AppAlertSoundEnabled = true; //enable
                enableSoundsToolStripMenuItem.Checked = true;
                SpiffyStuff.writeLog(SpiffyText.String00019, rtbLog); //sound enabled
                saveNow();
            }
        }

        public void toggleAlert()
        {
            //if alert is enabled, disable it
            if (Properties.Settings.Default.AppAlertEnabled)
            {
                Properties.Settings.Default.AppAlertEnabled = false; //disable
                enableAlertsToolStripMenuItem.Checked = false;
                SpiffyStuff.writeLog(SpiffyText.String00038, rtbLog); //alert disabled
                saveNow();
            }
            //if alert is disabled, enable it
            else
            {
                Properties.Settings.Default.AppAlertEnabled = true; //enable
                enableAlertsToolStripMenuItem.Checked = true;
                SpiffyStuff.writeLog(SpiffyText.String00026, rtbLog); //alert enabled
                saveNow();
            }
        }

        #endregion

        #region Menu clicks
        //FILE MENU
        //Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitSpiffy();
        }
        //Hide Log window
        private void hideLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleView();
        }
        //Clear log
        private void clearLogToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            clearLogWindow();
        }

        //TOOLS MENU
        //Accounts
        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showAccounts();
        }
        //Options
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showOptions();
        }        
        //Check now
        private void checkNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNow();
        }      
        //Proxy from Tools (saves proxy enabled setting)
        private void useProxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleProxy();
        }
        //Toggle timers
        private void enableTimersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toggleTimers();
        }
        //website
        private void spiffyWebsiteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SpiffyStuff.openURL(Properties.Resources.AppStringWebsiteURL);
        }
        //Check for Update
        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpiffyStuff.checkVersion(appVersion, rtbLog);
        }
        //About 
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showAbout();
        }
        //Donate
        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpiffyStuff.openURL(Properties.Resources.AppStringDonateURL);
        }
        
        //TOOLSTRIP
        //Check
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            checkNow();
        }
        //Gmail
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AppCustomGmailLocationEnabled)
            {
                openGmail("custom");
            }
            else
            {
                openGmail("");
            }
        }
        //tell me again
        private void toolStripButtonTellMeAgain_Click(object sender, EventArgs e)
        {
            tellMeAgain();
        }
        
        //LOGWINDOW CONTEXTMENU
        //check
        private void checkNowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            checkNow();
        }
        //clear
        private void clearLogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clearLogWindow();
        }
        //accounts
        private void accountsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showAccounts();
        }
        //options
        private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showOptions();
        }
        //exit
        private void quitSpiffyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            exitSpiffy();
        }
        //Hide - show log
        private void hideLogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toggleView();
        }

        //TRAY
        #region Trayicon Click Single and Doubleclick Actions !!!

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.AppTraySingleClick == true)
            {
                clickTrayAction();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.AppTraySingleClick == false)
            {
                clickTrayAction();
            }
            //int action = Properties.Settings.Default.AppTrayIconBehaviourNr;
            //switch (action)
            //{
            //    case 1: //1 Restore Window (default)
            //        SpiffyStuff.ShowApp(this, rtbLog);
            //        break;

            //    case 2: //2 Check for New Mail
            //        checkNow();
            //        break;

            //    case 3: //3 Open Gmail in Browser
            //        if (Properties.Settings.Default.AppCustomGmailLocationEnabled)
            //        {
            //            openGmail("custom");
            //        }
            //        else
            //        {
            //            openGmail("");
            //        }
            //        break;

            //    case 4: //4 Tell Me Again
            //        tellMeAgain();
            //        break;

            //    case 5: //5 Start Default Mail Client
            //        startMailClient();
            //        break;

            //    case 0: //only happens at first startup
            //        SpiffyStuff.ShowApp(this, rtbLog);
            //        break;
            //}

        }

        public void clickTrayAction()
        {
            int action = Properties.Settings.Default.AppTrayIconBehaviourNr;
            switch (action)
            {
                case 1: //1 Restore Window (default)
                    SpiffyStuff.ShowApp(this, rtbLog);
                    break;

                case 2: //2 Check for New Mail
                    checkNow();
                    break;

                case 3: //3 Open Gmail in Browser
                    if (Properties.Settings.Default.AppCustomGmailLocationEnabled)
                    {
                        openGmail("custom");
                    }
                    else
                    {
                        openGmail("");
                    }
                    break;

                case 4: //4 Tell Me Again
                    tellMeAgain();
                    break;

                case 5: //5 Start Default Mail Client
                    startMailClient();
                    break;

                case 0: //only happens at first startup
                    SpiffyStuff.ShowApp(this, rtbLog);
                    break;
            }
        }

        #endregion
        //Check
        private void checkNowToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            checkNow();
        }
        //Quit
        private void quitSpiffyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitSpiffy();
        }
        //Gmail
        private void gmailInboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AppCustomGmailLocationEnabled)
            {
                openGmail("custom");
            }
            else
            {
                openGmail("");
            }
        }
        //Restore
        private void restoreWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpiffyStuff.ShowApp(this, rtbLog);
        }        
        //Tell Me Again
        private void tellMeAgainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tellMeAgain();
        }
        //Accounts
        private void accountsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            showAccounts();
        }
        //Configuration
        private void configurationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showOptions();
        }
        //Restore Window
        private void restoreWindowToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SpiffyStuff.ShowApp(this, rtbLog);
        }

        
        //HELP
        //about
        private void aboutSpiffyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showAbout();
        }
        //donate
        private void donateWithPaypalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpiffyStuff.openURL(Properties.Resources.AppStringDonateURL);
        }
        //website
        private void spiffyWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpiffyStuff.openURL(Properties.Resources.AppStringWebsiteURL);
        }

        //OPTIONS
        //Proxy from Tray(saves proxy enabled setting)
        private void enableProxyFromTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleProxy();
        }
        //Timers toggle
        private void enableTimersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleTimers();
        }
        //Toggle sound
        private void enableSoundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleSound();
        }
        //Toggle Alerts
        private void enableAlertsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleAlert();
        }
        //Toggle Hide Main Window
        private void alwaysHideWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleMainWindow();
        }
        #endregion

        #region Timers

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.A1EnableInterval)
            {
                disableButtonsBeforeNewMailCheck();

                checkforunreadMail(
                    AC1,
                    Properties.Settings.Default.A1Username,
                    getPwd(1),
                    Properties.Settings.Default.A1GoogleAppsDomain,
                    Properties.Settings.Default.A1Label,
                    Properties.Settings.Default.A1CheckLabel,
                    Properties.Settings.Default.A1GoogleApps, false
                    );
                //Check if unread count must be added in tray text
                checkTraytext();

                enableButtonsAfterNewMailCheck();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.A2EnableInterval)
            {
                disableButtonsBeforeNewMailCheck();

                checkforunreadMail(
                    AC2,
                    Properties.Settings.Default.A2Username,
                    getPwd(2),
                    Properties.Settings.Default.A2GoogleAppsDomain,
                    Properties.Settings.Default.A2Label,
                    Properties.Settings.Default.A2CheckLabel,
                    Properties.Settings.Default.A2GoogleApps, false
                    );
                //Check if unread count must be added in tray text
                checkTraytext();

                enableButtonsAfterNewMailCheck();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.A3EnableInterval)
            {
                disableButtonsBeforeNewMailCheck();

                checkforunreadMail(
                    AC3,
                    Properties.Settings.Default.A3Username,
                    getPwd(3),
                    Properties.Settings.Default.A3GoogleAppsDomain,
                    Properties.Settings.Default.A3Label,
                    Properties.Settings.Default.A3CheckLabel,
                    Properties.Settings.Default.A3GoogleApps, false
                    );
                //Check if unread count must be added in tray text
                checkTraytext();

                enableButtonsAfterNewMailCheck();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.A4EnableInterval)
            {
                disableButtonsBeforeNewMailCheck();

                checkforunreadMail(
                    AC4,
                    Properties.Settings.Default.A4Username,
                    getPwd(4),
                    Properties.Settings.Default.A4GoogleAppsDomain,
                    Properties.Settings.Default.A4Label,
                    Properties.Settings.Default.A4CheckLabel,
                    Properties.Settings.Default.A4GoogleApps, false
                    );
                //Check if unread count must be added in tray text
                checkTraytext();

                enableButtonsAfterNewMailCheck();
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.A5EnableInterval)
            {
                disableButtonsBeforeNewMailCheck();

                checkforunreadMail(
                    AC5,
                    Properties.Settings.Default.A5Username,
                    getPwd(5),
                    Properties.Settings.Default.A5GoogleAppsDomain,
                    Properties.Settings.Default.A5Label,
                    Properties.Settings.Default.A5CheckLabel,
                    Properties.Settings.Default.A5GoogleApps, false
                    );
                //Check if unread count must be added in tray text
                checkTraytext();

                enableButtonsAfterNewMailCheck();
            }
        }

        private void pauseTimer_Tick(object sender, EventArgs e)
        {
            toggleTimers();
        }        

        private void flushTimer_Tick(object sender, EventArgs e)
        {
            FlushMemory();
        }

        #endregion


    }
}
