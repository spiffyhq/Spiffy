using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Diagnostics;
using Microsoft.Win32;
using System.Runtime.InteropServices;
//
using System.Security;
using System.Security.Cryptography;
using System.Security.Permissions;

namespace Spiffy
{
    public static class SpiffyStuff
    {      
        [DllImport("winmm.DLL")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        //Playsound
        public static void playNewMailSound(string sound)
        {
            if (File.Exists(sound))
            {
                try
                {
                    mciSendString("close MediaFile", null, 0, IntPtr.Zero);
                    mciSendString("open \"" + sound + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
                    mciSendString("play MediaFile", null, 0, IntPtr.Zero);
                }
                catch (Exception e)
                {
                    SpiffyStuff.LogExceptionInfo(e, "playnewmailsound", true);
                }
            }
            else
            {
                SpiffyStuff.writeErrorLog("ERROR: Cannot find file: " + sound);
            }
        }

        //logging to richtextbox
        public static void writeLog(string text, RichTextBox rtb)
        {
            switch (Properties.Settings.Default.AppLogTimeEnabled)
            {
                case true:                    
                    rtb.AppendText(currentTime(Properties.Settings.Default.AppLogDateTimeFormat) + " - " + text + "\n");
                break;

                case false:
                    rtb.AppendText(text + "\n");
                break;
            }

            //Also log to error log if debug is enabled
            if (Properties.Settings.Default.DebugLoggingEnabled)
            {
                writeErrorLog("LOG: " + text);
            }
            
            rtb.ScrollToCaret();
            rtb.Refresh();
        } 

        //log errors to file
        public static void writeErrorLog(string message)
        {
            //ONLY LOG IF DEBUG LOGGING IS ENABLED
            if (Properties.Settings.Default.DebugLoggingEnabled)
            {
                string strLogMessage = string.Empty;
                string strWriteMode = string.Empty;     //used to set path in creating log file below  
                string strLogFileUSB = Application.StartupPath + "\\spiffy.log";
                string strLogFileWIN = Path.GetTempPath() + "\\spiffy.log";
                         
                //Check if Spiffy is running in Program Files folder (== no write access)
                if (Application.StartupPath.Contains(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)))
                {
                    strWriteMode = strLogFileWIN;
                }
                else
                {
                    strWriteMode = strLogFileUSB;
                }

                //Create writer
                StreamWriter swLog;

                //ADD DATE AND TIME TO MESSAGE
                strLogMessage = string.Format("[{0}] {1}", DateTime.Now, message);

                //IF NO LOG IS FOUND CREATE IT
                if (!File.Exists(strWriteMode))
                {
                    swLog = new StreamWriter(strWriteMode);
                    //Add System info to file
                    swLog.WriteLine(string.Format("[{0}] {1}", DateTime.Now, "************************************************************"));
                    swLog.WriteLine(string.Format("[{0}] Windows version: {1}", DateTime.Now, Environment.OSVersion));
                    swLog.WriteLine(string.Format("[{0}] ProductName: {1}", DateTime.Now, Application.ProductName));
                    swLog.WriteLine(string.Format("[{0}] ProductVersion: {1}", DateTime.Now, Application.ProductVersion));
                    swLog.WriteLine(string.Format("[{0}] StartupPath: {1}", DateTime.Now, Application.StartupPath));
                }
                else //ELSE APPEND TO CURRENT
                {
                    swLog = File.AppendText(strWriteMode);
                }

                //LOG THE ACTUAL MESSAGE
                try
                {
                    swLog.WriteLine(strLogMessage);
                }
                catch (Exception e2)
                {
                    //cannot write
                }

                //CLOSE THE STREAM
                swLog.Close();
            }
        }

        //used to get info from exception and optional comments (problem string for example)
        public static void LogExceptionInfo(Exception exception, string comments, bool stacktrace)
        {
            writeErrorLog("************************************************************");
            writeErrorLog("Method: " + exception.TargetSite);
            writeErrorLog("Source: " + exception.Source);
            writeErrorLog("Message: " + exception.Message);
            writeErrorLog("Comments: " + comments);
            if (stacktrace) writeErrorLog("Stacktrace: " + exception.StackTrace);
        }
        
        //used for logging
        public static string currentTime(String format)
        {
            try
            {
                DateTime dt = DateTime.Now;
                if (String.IsNullOrEmpty(format))
                {
                    return dt.ToLocalTime().ToString();
                }
                else
                {
                    return dt.ToString(format, DateTimeFormatInfo.CurrentInfo);
                }
            }
            catch (FormatException c1)
            {
                LogExceptionInfo(c1, "Format error, string used; " + format, false);                
                return "ERROR";
            }
        } 
        
        //used in alert
        public static string convertGTime(DateTime dt, String format)
        {
            DateTime today = DateTime.Today.Date;
            DateTime yesterday = today.AddDays(-1);
            try
            {
                switch (Properties.Settings.Default.AppSpiffyDateFormat)
                {
                    case true:
                        if (dt.Date == today)
                        {
                            return SpiffyText.String00075 + " " + dt.ToShortTimeString(); //today at
                        }
                        else if (dt.Date == yesterday)
                        {
                            return SpiffyText.String00076 + " " + dt.ToShortTimeString(); //yesterday at
                        }
                        else
                        {
                            return dt.ToLocalTime().ToString();
                        }

                    case false:
                        if (String.IsNullOrEmpty(format))
                        {
                            return dt.ToLocalTime().ToString();
                        }
                        else
                        {
                            return dt.ToString(format, DateTimeFormatInfo.CurrentInfo);
                        }
                }

                return "ERROR";
            }
            catch (FormatException cg1)
            {
                LogExceptionInfo(cg1, "Format error, string used; " + format, false);
                return "ERROR";
            }
        }

        //Show and Hide (for clicking trayicon)
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public static void HideApp(Form mainForm)
        {
            mainForm.WindowState = FormWindowState.Minimized;
            mainForm.ShowInTaskbar = false;
            mainForm.Hide();
            Form1.FlushMemory();
        }

        public static void ShowApp(Form mainForm, RichTextBox rtb)
        {   
            mainForm.WindowState = FormWindowState.Normal;
            mainForm.ShowInTaskbar = true;
            mainForm.TopMost = true;
            mainForm.BringToFront();
            mainForm.Show();
            //Scroll to bottem
            rtb.SelectionStart = rtb.Text.Length; //count length 
            rtb.SelectionLength = 0; //select nothing
            rtb.ScrollToCaret(); //scroll down
        }
        
        //Program Version checks (LOG AND POPUP)
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public static void checkVersion(String currentversion, RichTextBox rtb)
        {
            /*
             * latest.txt looks like this
             * 
             * line 1 [0]: version build nr (ie 0.3.0)            (required)
             * 
             */
            string hasConnection = connectionStatus("http://example.com");
            if (hasConnection == "OK")
            {
                //SpiffyStuff.writeLog("Found internet connection...", rtb);
                try
                {
                    WebClient wcl = new WebClient();
                    switch (Properties.Settings.Default.proxyEnabled)
                    {
                        case true:
                            wcl.Proxy = SpiffyStuff.userProxy();
                            break;

                        case false:
                            wcl.Proxy = null;
                            break;
                    }
                    Stream versionFile = wcl.OpenRead(
                                  "http://latest.txt");
                    StreamReader sr = new StreamReader(versionFile);
                    string latestversion = sr.ReadLine();
                    //Check the version number (compare latest.txt with hardcoded version in Form1)
                    if (Regex.Match(latestversion, Form1.appVersion).Success)
                    {
                        MessageBox.Show(SpiffyText.String00077,     //you have the latest version
                            "Spiffy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (DialogResult.OK == MessageBox.Show(SpiffyText.String00078 + "\n\n" + //new ver available
                            SpiffyText.String00079 + ": " + currentversion + "\n" +
                            SpiffyText.String00080 + ": " + latestversion + "\n\n" +
                            SpiffyText.String00081, //go to website now?
                            "Spiffy", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                        {
                            openURL(Properties.Resources.AppStringWebsiteURL);
                        }
                    }

                    //close
                    versionFile.Close();
                    sr.Close();
                    wcl.Dispose();
                }
                catch (WebException e)
                {
                    LogExceptionInfo(e, "check version (menu)", true);
                    SpiffyStuff.writeLog(SpiffyText.String00082 + " (" + e.Message + ")", rtb); //error
                }
            }
            else
            {
                SpiffyStuff.writeErrorLog("checkVersion() from menu");
                SpiffyStuff.writeLog(SpiffyText.String00082 + " (" + hasConnection + ")", rtb); //error
            }
        }

        //Program Version check at startup (LOG ONLY)
        public static void checkVersionStartup(NotifyIcon trayicon, RichTextBox rtb)
        {
            /*
             * latest.txt looks like this
             * 
             * line 1 [0]: version build nr (ie 0.3.0)            (required)
             * 
             */
            string hasConnection = connectionStatus("http://www.google.com");
            if (hasConnection == "OK")
            {
                //SpiffyStuff.writeLog("Found internet connection...", rtb);
                try
                {
                    WebClient wcl = new WebClient();
                    switch (Properties.Settings.Default.proxyEnabled)
                    {
                        case true:
                            wcl.Proxy = SpiffyStuff.userProxy();
                            break;

                        case false:
                            wcl.Proxy = null;
                            break;
                    }
                    Stream versionFile = wcl.OpenRead(
                                  "http://latest.txt");
                    StreamReader sr = new StreamReader(versionFile);
                    string latestversion = sr.ReadLine();
                    //Check the version number
                    if (Regex.Match(latestversion, Form1.appVersion).Success)
                    {
                        //SpiffyStuff.writeLog("Running latest version...", rtb);
                    }
                    else
                    {
                        trayicon.ShowBalloonTip(5,
                            "Spiffy",
                            SpiffyText.String00083, //new version click here to download
                            ToolTipIcon.Info);
                        trayicon.BalloonTipClicked += new EventHandler(trayicon_BalloonTipClicked);
                        SpiffyStuff.writeLog(SpiffyText.String00084 + ": " + latestversion, rtb); //new version found
                        SpiffyStuff.writeLog(SpiffyText.String00085, rtb); //visit website to download
                    }

                    //close
                    versionFile.Close();
                    sr.Close();
                    wcl.Dispose();
                }
                catch (WebException e)
                {
                    LogExceptionInfo(e, "check version (startup)", true);
                    SpiffyStuff.writeLog(SpiffyText.String00082 + " (" + e.Message + ")", rtb); //error checking for update
                }
            }
            else
            {
                SpiffyStuff.writeErrorLog("checkVersionStartup()");
                SpiffyStuff.writeLog(SpiffyText.String00082 + " (" + hasConnection + ")", rtb); //error checking for update
            }

        }

        //Balloontip clicked from checkVersionStartup()
        static void trayicon_BalloonTipClicked(object sender, EventArgs e)
        {
            SpiffyStuff.openURL(Properties.Resources.AppStringWebsiteURL);
        }

        //Changes tray icon for newmail
        public static void changeTrayicon(NotifyIcon n, bool newmail)
        {
            if (newmail)
            {
                if (Properties.Settings.Default.AppEnableCustomTrayIcons == false) //use spiffy icons
                {
                    switch (Properties.Settings.Default.AppTrayIconAlertImageNr) //check which new mail icon
                    {
                        case 1: //star (default)
                            n.Icon = Properties.Resources.spiffy32x32_starbig;
                            break;

                        case 2: //green
                            n.Icon = Properties.Resources.spiffy32x32;
                            break;

                        case 3: //gray
                            n.Icon = Properties.Resources.spiffy32x32_gray;
                            break;

                        case 4: //blue
                            n.Icon = Properties.Resources.spiffy32x32_blue;
                            break;

                        case 5: //purple
                            n.Icon = Properties.Resources.spiffy32x32_purple;
                            break;

                        case 6: //red
                            n.Icon = Properties.Resources.spiffy32x32_red;
                            break;
                    }
                }
                else //custom icons enabled
                {
                    if (File.Exists(Properties.Settings.Default.AppCustomTrayIconNewmailIconPath))
                    {
                        n.Icon =
                            new System.Drawing.Icon(Properties.Settings.Default.AppCustomTrayIconNewmailIconPath);
                    }
                    else //not found -> use default
                    {
                        n.Icon = Properties.Resources.spiffy32x32_starbig;
                    }
                }
            } //no new mail or icon new mail icon disabled
            else
            {
                changeTrayicon(n);
            }
        }

        //Changes tray icon to default (from settings)
        public static void changeTrayicon(NotifyIcon n)
        {
            if (Properties.Settings.Default.AppEnableCustomTrayIcons == false) //use spiffy icons
            {
                switch (Properties.Settings.Default.AppDefaultTrayIconNr) //check default tray icon
                {
                    case 1: //"Green (default)"
                        n.Icon = Properties.Resources.spiffy32x32;
                        break;

                    case 2: //gray
                        n.Icon = Properties.Resources.spiffy32x32_gray;
                        break;

                    case 3: //blue
                        n.Icon = Properties.Resources.spiffy32x32_blue;
                        break;

                    case 4: //purple
                        n.Icon = Properties.Resources.spiffy32x32_purple;
                        break;

                    case 5: //red 
                        n.Icon = Properties.Resources.spiffy32x32_red;
                        break;
                }
            }
            else //custom icons enabled
            {
                if (File.Exists(Properties.Settings.Default.AppCustomTrayIconDefaultPath))
                {
                    n.Icon = 
                        new System.Drawing.Icon(Properties.Settings.Default.AppCustomTrayIconDefaultPath);
                }
                else //not found -> use default
                {
                    n.Icon = Properties.Resources.spiffy32x32;
                }
            }
        }

        public static void UpdateUnreadCountInTray(NotifyIcon n, SpiffyAccount account, int AllAccounts)
        {
            //string windowText = Properties.Settings.Default.AppWindowTitleText;

            if (account == null) //only null when All Accounts is chosen from dropdown
            {
                //check if also account name must be shown
                if (Properties.Settings.Default.AppShowUnreadAccountInTray)
                {
                    n.Text =
                        Properties.Settings.Default.AppWindowTitleText + "\n" +
                        SpiffyText.String00021 + " - " + AllAccounts + " " + SpiffyText.String00086; //unread
                }
                else //show only unread nr (int AllAccounts)
                {
                    n.Text =
                        Properties.Settings.Default.AppWindowTitleText + "\n" +
                        AllAccounts + " " + SpiffyText.String00086; //unread
                }
            }
            else //if a single account is chosen 
            {
                //check if also account name must be shown
                if (Properties.Settings.Default.AppShowUnreadAccountInTray)
                {
                    n.Text =
                        Properties.Settings.Default.AppWindowTitleText + "\n" +
                        account.AccountName + " - " + account.AccountTotalUnread + " " + SpiffyText.String00086; //unread
                }
                else //show only unread nr
                {
                    n.Text =
                        Properties.Settings.Default.AppWindowTitleText + "\n" +
                        account.AccountTotalUnread + " " + SpiffyText.String00086; //unread
                }
            }

        }

        public static string connectionStatus(string url)
        {
            try
            {
                HttpWebRequest request =
                    (HttpWebRequest)HttpWebRequest.Create(new Uri(url));

                switch (Properties.Settings.Default.proxyEnabled)
                {
                    case true:
                        request.Proxy = SpiffyStuff.userProxy();
                        break;

                    case false:
                        request.Proxy = null;
                        break;
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (HttpStatusCode.OK == response.StatusCode)
                {
                    response.Close();
                    return response.StatusCode.ToString();
                }
                else
                {
                    response.Close();
                    return response.StatusCode.ToString();
                }

            }
            catch (WebException w1)
            {
                LogExceptionInfo(w1, "gmailStatus", true);
                return w1.Message;
            }

        }

        public static void startTimers(Timer t1, Timer t2, Timer t3, Timer t4, Timer t5, RichTextBox rtb)
        {
            if (t1.Enabled == false && Properties.Settings.Default.A1EnableInterval)
            {
                t1.Enabled = true;
                SpiffyStuff.writeLog(SpiffyText.String00074 + " \"" + Form1.AC1.AccountName + "\"", rtb); //started checking [accountname]
            }
            if (t2.Enabled == false && Properties.Settings.Default.A2EnableInterval)
            {
                t2.Enabled = true;
                SpiffyStuff.writeLog(SpiffyText.String00074 + " \"" + Form1.AC2.AccountName + "\"", rtb);
            }
            if (t3.Enabled == false && Properties.Settings.Default.A3EnableInterval)
            {
                t3.Enabled = true;
                SpiffyStuff.writeLog(SpiffyText.String00074 + " \"" + Form1.AC3.AccountName + "\"", rtb);
            }
            if (t4.Enabled == false && Properties.Settings.Default.A4EnableInterval)
            {
                t4.Enabled = true;
                SpiffyStuff.writeLog(SpiffyText.String00074 + " \"" + Form1.AC4.AccountName + "\"", rtb);
            }
            if (t5.Enabled == false && Properties.Settings.Default.A5EnableInterval)
            {
                t5.Enabled = true;
                SpiffyStuff.writeLog(SpiffyText.String00074 + " \"" + Form1.AC5.AccountName + "\"", rtb);
            }
        }

        public static void stopTimers(Timer t1, Timer t2, Timer t3, Timer t4, Timer t5, RichTextBox rtb)
        {
            if (t1.Enabled == true && Properties.Settings.Default.A1EnableInterval)
            {
                t1.Enabled = false;
                SpiffyStuff.writeLog(SpiffyText.String00073 + " \"" + Form1.AC1.AccountName + "\"", rtb); //stopped checking accountname
            }
            if (t2.Enabled == true && Properties.Settings.Default.A2EnableInterval)
            {
                t2.Enabled = false;
                SpiffyStuff.writeLog(SpiffyText.String00073 + " \"" + Form1.AC2.AccountName + "\"", rtb);
            }
            if (t3.Enabled == true && Properties.Settings.Default.A3EnableInterval)
            {
                t3.Enabled = false;
                SpiffyStuff.writeLog(SpiffyText.String00073 + " \"" + Form1.AC3.AccountName + "\"", rtb);
            }
            if (t4.Enabled == true && Properties.Settings.Default.A4EnableInterval)
            {
                t4.Enabled = false;
                SpiffyStuff.writeLog(SpiffyText.String00073 + " \"" + Form1.AC4.AccountName + "\"", rtb);
            }
            if (t5.Enabled == true && Properties.Settings.Default.A5EnableInterval)
            {
                t5.Enabled = false;
                SpiffyStuff.writeLog(SpiffyText.String00073 + " \"" + Form1.AC5.AccountName + "\"", rtb);
            }

        }

        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public static void openHelpURL(String anchor)
        {
            DialogResult dr = MessageBox.Show
                (SpiffyText.String00087, "Spiffy", //more info?
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                openURL(Properties.Resources.AppStringWebsiteURL + "help.html#" + anchor);               
            }
        }

        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]    
        public static void openURL(String sUrl)
        {
            try
            {
                if(Properties.Settings.Default.AppCustomBrowserEnable)
                {
                    Process.Start(
                        Properties.Settings.Default.AppCustomBrowserPath,
                        sUrl);
                }
                else
                {
                    Process.Start(sUrl);
                }
            }
            catch (Exception E12)
            {
                LogExceptionInfo(E12, "openUrl() " + sUrl, true);
            }
        }
        
        //Get culturename from language
        public static string getCulture(String language)
        {
            switch (language)
            {
                case "Dutch (Netherlands)":
                    return "nl-NL";

                case "Hebrew":
                    return "he";

                case "Russian":
                    return "ru";

                case "Polish":
                    return "pl";

                case "Portuguese (Portugal)":
                    return "pt-PT";

                case "Chinese (Traditional)":
                    return "zh-Hant";

                case "French (France)":
                    return "fr-FR";

                default:
                    return "en";
            }
        }

        #region getDefaultMailClientNameAndPath
        private static string getMailClientName()
        {
            try
            {
                RegistryKey appName = Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\Clients\Mail", false);
                string name = (string)appName.GetValue("", "0");
                return name;
            }
            catch (Exception ss01)
            {
                LogExceptionInfo(ss01, "ss01", false); 
                return "NA (1)";
            }
        }

        public static string pathToMailClient()
        {
            try
            {
                RegistryKey appExe = Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\Clients\Mail\" + getMailClientName() + @"\shell\open\command", false);
                string exe = (string)appExe.GetValue("", "0");
                return exe;
            }
            catch (Exception ss02)
            {
                LogExceptionInfo(ss02, "ss02", false); 
                return "NA (2)";
            }
        }
        #endregion

        #region Proxy
        //get machine domain
        public static string GetDomainName()
        {
            string domain = String.Empty;
            try
            {
                domain = Environment.UserDomainName;
                string machineName = Environment.MachineName;

                if (machineName.Equals(domain, StringComparison.OrdinalIgnoreCase))
                {
                    domain = String.Empty;
                }
            }
            catch
            {
                // Handle exception if desired, otherwise returns null
            }
            return domain;
        }

        //Get's the custom proxy and credentials
        public static WebProxy userProxy()
        {
            if (Properties.Settings.Default.proxyEnabled == true)
            {
                try
                {
                    //create proxy
                    System.Net.WebProxy proxy = 
                        new System.Net.WebProxy(Properties.Settings.Default.proxyServerName,
                            Int32.Parse(Properties.Settings.Default.proxyServerPort));

                    //set auth if needed
                    if (Properties.Settings.Default.proxyServerAuthReq == true)
                    {
                        proxy.Credentials = new NetworkCredential(
                            Properties.Settings.Default.proxyServerUsername,
                            SpiffyStuff.DecryptString(Properties.Settings.Default.proxyServerPasswordEncrypted));
                    }
                    else
                    {
                        proxy.Credentials = CredentialCache.DefaultCredentials;
                    }
                    //set and return
                    WebRequest.DefaultWebProxy = proxy;
                    return proxy;

                }
                catch (UriFormatException ufe3)
                {
                    LogExceptionInfo(ufe3, "getProxy()", true);
                }
            }
            return null;
        }
        #endregion

        # region Encrypt/Decrypt (new in 060)
        static byte[] entropy = System.Text.Encoding.Unicode.GetBytes("THISISNOTSECURECHANGETHIS");

        public static string EncryptString(System.Security.SecureString input)
        {
            byte[] encryptedData = System.Security.Cryptography.ProtectedData.Protect(
                System.Text.Encoding.Unicode.GetBytes(ToInsecureString(input)),
                entropy,
                System.Security.Cryptography.DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encryptedData);
        }

        public static SecureString DecryptString(string encryptedData)
        {
            try
            {
                byte[] decryptedData = System.Security.Cryptography.ProtectedData.Unprotect(
                    Convert.FromBase64String(encryptedData),
                    entropy, 
                    System.Security.Cryptography.DataProtectionScope.CurrentUser);
                return ToSecureString(System.Text.Encoding.Unicode.GetString(decryptedData));
            }
            catch
            {
                return new SecureString();
            }
        }

        public static SecureString ToSecureString(string input)
        {
            SecureString secure = new SecureString();
            foreach (char c in input)
            {
                secure.AppendChar(c);
            }
            secure.MakeReadOnly();
            return secure;
        }

        public static string ToInsecureString(SecureString input)
        {
            string returnValue = string.Empty;
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(input);
            try
            {
                returnValue = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }
            return returnValue;
        }
        # endregion
    }
}
