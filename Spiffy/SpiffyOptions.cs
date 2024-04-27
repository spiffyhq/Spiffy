using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.Win32;

namespace Spiffy
{
    public partial class SpiffyOptions : Form
    {
        //Form references
        public Form1 mainForm;

        public SpiffyOptions()
        {
            InitializeComponent();

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
            }
        }

        private void SpiffyOptions_Load(object sender, EventArgs e)
        {
            InitializeLocale();

            //add panels
            splitContainer1.Panel2.Controls.Add(new options_general()); //0
            splitContainer1.Panel2.Controls.Add(new options_alerts()); //1

            splitContainer1.Panel2.Controls.Add(new options_customize_mainwindow()); //2a
            splitContainer1.Panel2.Controls.Add(new options_customize_text()); //2b
            splitContainer1.Panel2.Controls.Add(new options_customize_popup()); //2c
            splitContainer1.Panel2.Controls.Add(new options_customize_tray()); //2d
            splitContainer1.Panel2.Controls.Add(new options_customize_mouse()); //2e

            splitContainer1.Panel2.Controls.Add(new options_network_proxy()); //3a
            splitContainer1.Panel2.Controls.Add(new options_network_google()); //3b

            splitContainer1.Panel2.Controls.Add(new options_advanced()); //4

            //expand treeview
            treeView1.ExpandAll();
        }

        public void saveSettings()
        {
            // ######### DO BEFORE SAVE ######### //

            //CHECK IF PROXY IS ENABLED AND SERVER IS CONFIGURED

            if (Properties.Settings.Default.proxyEnabled)
            {
                //Check if server is configured if not turn off proxy
                if (String.IsNullOrEmpty(Properties.Settings.Default.proxyServerName) ||
                     String.IsNullOrEmpty(Properties.Settings.Default.proxyServerPort))
                {
                    SpiffyStuff.writeLog(SpiffyText.String00333, mainForm.rtbLog); //warning no proxy server or port entered
                    Properties.Settings.Default.proxyEnabled = false;
                }
            }

            //ENCRYPT PROXY PASSWORD IF ENTERED
            if (Properties.Settings.Default.proxyServerUsername != "" &&
                Properties.Settings.Default.proxyServerPassword != "")
            {
                //Encrypt pass
                Properties.Settings.Default.proxyServerPasswordEncrypted =
                    SpiffyStuff.EncryptString(SpiffyStuff.ToSecureString(Properties.Settings.Default.proxyServerPassword));
                //Clear 'real' or visible password (we cant clear the textbox so we use an extra setting field to bypass)
                Properties.Settings.Default.proxyServerPassword = String.Empty;
            }

            // ######### PRE SAVE ############ //
            saveNow();
            SpiffyStuff.writeLog(SpiffyText.String00055 + "...", mainForm.rtbLog); //saving settings...

            // ######### CHECKS ########## /
            //Check if Log Window Font is not empty
            if (Properties.Settings.Default.AppLogDefaultFontName == "")
                Properties.Settings.Default.AppLogDefaultFontName = mainForm.rtbLog.Font.Name;
            if (Properties.Settings.Default.AppLogDefaultFontSize == "")
                Properties.Settings.Default.AppLogDefaultFontSize = mainForm.rtbLog.Font.Size.ToString();

            //Check before sync and reset if needed
            if (Properties.Settings.Default.AppAlertDelay == 0) //alert delay
            {
                Properties.Settings.Default.AppAlertDelay = 5;
                saveNow();
                SpiffyStuff.writeLog(SpiffyText.String00056, mainForm.rtbLog); //Warning: alert delay 0, reset to default             
            }

            //Check feed address before sync and reset if needed
            if (Properties.Settings.Default.AppFeedAddress == "") //feed url
            {
                Properties.Settings.Default.AppFeedAddress = "https://mail.google.com/mail/feed/atom";
                saveNow();
                SpiffyStuff.writeLog(SpiffyText.String00057, mainForm.rtbLog); //Warning: feed url empty, reset to default
            }

            //Convert alert icon (if used) to nr <- localize support
            if (Properties.Settings.Default.AppTrayIconAlertImage == SpiffyText.String00059) //star (default)
            {
                Properties.Settings.Default.AppTrayIconAlertImageNr = 1;
            }
            if (Properties.Settings.Default.AppTrayIconAlertImage == SpiffyText.String00060) //green
            {
                Properties.Settings.Default.AppTrayIconAlertImageNr = 2;
            }
            if (Properties.Settings.Default.AppTrayIconAlertImage == SpiffyText.String00061) //gray
            {
                Properties.Settings.Default.AppTrayIconAlertImageNr = 3;
            }
            if (Properties.Settings.Default.AppTrayIconAlertImage == SpiffyText.String00062) //blue
            {
                Properties.Settings.Default.AppTrayIconAlertImageNr = 4;
            }
            if (Properties.Settings.Default.AppTrayIconAlertImage == SpiffyText.String00063) //purple
            {
                Properties.Settings.Default.AppTrayIconAlertImageNr = 5;
            }
            if (Properties.Settings.Default.AppTrayIconAlertImage == SpiffyText.String00064) //red
            {
                Properties.Settings.Default.AppTrayIconAlertImageNr = 6;
            }

            //Convert 'default tray icon' to number <- localize support
            if (Properties.Settings.Default.AppDefaultTrayIcon == SpiffyText.String00058) //green (default)
            {
                Properties.Settings.Default.AppDefaultTrayIconNr = 1;
            }
            if (Properties.Settings.Default.AppDefaultTrayIcon == SpiffyText.String00061) //gray
            {
                Properties.Settings.Default.AppDefaultTrayIconNr = 2;
            }
            if (Properties.Settings.Default.AppDefaultTrayIcon == SpiffyText.String00062) //blue
            {
                Properties.Settings.Default.AppDefaultTrayIconNr = 3;
            }
            if (Properties.Settings.Default.AppDefaultTrayIcon == SpiffyText.String00063) //purple
            {
                Properties.Settings.Default.AppDefaultTrayIconNr = 4;
            }
            if (Properties.Settings.Default.AppDefaultTrayIcon == SpiffyText.String00064) //red
            {
                Properties.Settings.Default.AppDefaultTrayIconNr = 5;
            }

            //Convert 'tray doubleclick options' to number <- localize support
            if (Properties.Settings.Default.AppTrayIconBehaviour == SpiffyText.String00043) //restore window (default)
            {
                Properties.Settings.Default.AppTrayIconBehaviourNr = 1;
            }
            if (Properties.Settings.Default.AppTrayIconBehaviour == SpiffyText.String00044) //check for new mail
            {
                Properties.Settings.Default.AppTrayIconBehaviourNr = 2;
            }
            if (Properties.Settings.Default.AppTrayIconBehaviour == SpiffyText.String00045) //open gmail
            {
                Properties.Settings.Default.AppTrayIconBehaviourNr = 3;
            }
            if (Properties.Settings.Default.AppTrayIconBehaviour == SpiffyText.String00046) //tell me again
            {
                Properties.Settings.Default.AppTrayIconBehaviourNr = 4;
            }
            if (Properties.Settings.Default.AppTrayIconBehaviour == SpiffyText.String00047) //start mail client
            {
                Properties.Settings.Default.AppTrayIconBehaviourNr = 5;
            }

            //CONVERT 'mail in tray' TO NR 
            if (Properties.Settings.Default.AppShowUnreadInTrayAccount == Form1.AC1.AccountName) //ac1
            {
                Properties.Settings.Default.AppShowUnreadInTrayAccountNr = 1;
            }
            if (Properties.Settings.Default.AppShowUnreadInTrayAccount == Form1.AC2.AccountName) //ac2
            {
                Properties.Settings.Default.AppShowUnreadInTrayAccountNr = 2;
            }
            if (Properties.Settings.Default.AppShowUnreadInTrayAccount == Form1.AC3.AccountName) //ac3
            {
                Properties.Settings.Default.AppShowUnreadInTrayAccountNr = 3;
            }
            if (Properties.Settings.Default.AppShowUnreadInTrayAccount == Form1.AC4.AccountName) //ac4
            {
                Properties.Settings.Default.AppShowUnreadInTrayAccountNr = 4;
            }
            if (Properties.Settings.Default.AppShowUnreadInTrayAccount == Form1.AC5.AccountName) //ac5
            {
                Properties.Settings.Default.AppShowUnreadInTrayAccountNr = 5;
            }
            if (Properties.Settings.Default.AppShowUnreadInTrayAccount == SpiffyText.String00021) //All accounts
            {
                Properties.Settings.Default.AppShowUnreadInTrayAccountNr = 6;
            }

            // ####### FINAL SAVE ####### //
            saveNow();
            SpiffyStuff.writeLog(SpiffyText.String00027, mainForm.rtbLog); //done!

            // ####### SYNC SETTINGS ####### //
            mainForm.syncSettings();
            mainForm.syncAccounts(false);
        }

        private void InitializeLocale()
        {
            //Window title
            this.Text = SpiffyText.String00151;

            //Buttons
            button1.Text = SpiffyText.String00152; //ok
            button2.Text = SpiffyText.String00153; //cancel
            button3.Text = SpiffyText.String00154; //apply   

            label1.Text = SpiffyText.String00161 + "...";
            
            //Tree
            treeView1.Nodes[0].Text = SpiffyText.String00155; //general
            treeView1.Nodes[1].Text = SpiffyText.String00156; //alerts

            treeView1.Nodes[2].Text = SpiffyText.String00157; //customize
            treeView1.Nodes[2].Nodes[0].Text = SpiffyText.String00162;
            treeView1.Nodes[2].Nodes[1].Text = SpiffyText.String00163;
            treeView1.Nodes[2].Nodes[2].Text = SpiffyText.String00164;
            treeView1.Nodes[2].Nodes[3].Text = SpiffyText.String00165;
            treeView1.Nodes[2].Nodes[4].Text = SpiffyText.String00166;

            treeView1.Nodes[3].Text = SpiffyText.String00158; //network
            treeView1.Nodes[3].Nodes[0].Text = SpiffyText.String00167;
            treeView1.Nodes[3].Nodes[1].Text = SpiffyText.String00168;

            treeView1.Nodes[4].Text = SpiffyText.String00169;
        }

        public void saveNow()
        {
            //Log save to file
            SpiffyStuff.writeErrorLog("saveNow(options)");

            //This prevents saving Location as -32000,-32000 when app is minimized
            if (mainForm.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.AppWindowLocation = mainForm.Location;
                Properties.Settings.Default.AppWindowSize = mainForm.Size;
            }
            else
            {
                Properties.Settings.Default.AppWindowLocation = mainForm.RestoreBounds.Location;
                Properties.Settings.Default.AppWindowSize = mainForm.RestoreBounds.Size;
            }

            //Save
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //save and sync before closing
            saveSettings();
            //close
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Properties.Settings.Default.Reload();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveSettings();
        }

        #region TREEVIEW ACTIONS
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            //hide all added controls
            foreach (Control x in splitContainer1.Panel2.Controls)
            {
                x.Hide();
            }
        }        

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //get options pane associated with node from getPanelForNode 
            string settingsPanel = getPanelForNode(e.Node.Name); 
            string tempControlName;

            //look in controls for control with name off settingsPanel with tempControlName
            foreach (Control x in splitContainer1.Panel2.Controls)
            {
                tempControlName = x.Name;

                //if control is found then show it
                if (settingsPanel == tempControlName)
                {
                    x.Show();
                    break;
                }
            }
        }

        //Returns options panel name for selected treeview node
        static string getPanelForNode(string NodeName)
        {
            //Lookup nodename and return panel name, if node is not used panel1 is returned by default
            switch (NodeName)
            {
                //GENERAL
                case "Node0": //General
                    return "options_general";

                //ALERTS
                case "Node1": //Alerts
                    return "options_alerts";

                //CUSTOMIZE
                case "Node2a": //Main Window
                    return "options_customize_mainwindow";

                case "Node2b": //Text
                    return "options_customize_text";

                case "Node2c": //Tray Alert
                    return "options_customize_popup";

                case "Node2d": //Tray Icon
                    return "options_customize_tray";

                case "Node2e": //Mouse
                    return "options_customize_mouse";

                //NETWORK
                case "Node3a": //Proxy
                    return "options_network_proxy";

                case "Node3b": //Google
                    return "options_network_google";

                //ADVANCED
                case "Node4": //Advanced
                    return "options_advanced";

                //PANEL 1 with select category text
                default:
                    return "panel1";
            }
        }
        #endregion
    }
}
