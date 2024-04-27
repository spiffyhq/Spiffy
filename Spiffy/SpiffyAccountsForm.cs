using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System.Security.Cryptography;
//using System.IO;

namespace Spiffy
{
    public partial class SpiffyAccountsForm : Form
    {
        //Form 1 reference
        public Form1 mainForm;

        public SpiffyAccountsForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();

            SetStyles();

            //SET RTL LAYOUT FOR HEBREW
            if (Properties.Settings.Default.AppLocale == "Hebrew")
            {
                //ALWAYS SET
                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;
            }

        }

        private void SpiffyAccountsForm_Load(object sender, EventArgs e)
        {
            InitializeLocale();

            //SET TAB PAGE TEXT
            setTabPageText(tabPage1, 1);
            setTabPageText(tabPage2, 2);
            setTabPageText(tabPage3, 3);
            setTabPageText(tabPage4, 4);
            setTabPageText(tabPage5, 5);           
        }

        void SetStyles()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        static void clearAccount(TextBox accountname, TextBox username, TextBox password,
            TextBox domain, CheckBox isApps, CheckBox enableInterval, NumericUpDown timer, CheckBox checkLabel,
            TextBox label, CheckBox checkCustomSound, TextBox customSound)
        {
            //Account details
            accountname.Clear();
            username.Clear();
            password.Clear();
            domain.Clear();
            isApps.Checked = false;

            //interval settings
            enableInterval.Checked = false;
            timer.Value = 10;

            //label
            checkLabel.Checked = false;
            label.Clear();

            //custom sound
            checkCustomSound.Checked = false;
            customSound.Clear();
        }

        private void InitializeLocale()
        {
            //title
            this.Text = SpiffyText.String00133;

            //tabs
            tabPage1.Text = SpiffyText.String00134 + " 1";
            tabPage2.Text = SpiffyText.String00134 + " 2";
            tabPage3.Text = SpiffyText.String00134 + " 3";
            tabPage4.Text = SpiffyText.String00134 + " 4";
            tabPage5.Text = SpiffyText.String00134 + " 5";

            //acc name
            label1.Text = SpiffyText.String00135;
            label9.Text = SpiffyText.String00135;
            label15.Text = SpiffyText.String00135;
            label20.Text = SpiffyText.String00135;
            label25.Text = SpiffyText.String00135;

            //username
            label2.Text = SpiffyText.String00137;
            label8.Text = SpiffyText.String00137;
            label14.Text = SpiffyText.String00137;
            label19.Text = SpiffyText.String00137;
            label24.Text = SpiffyText.String00137;

            //password
            label3.Text = SpiffyText.String00138;
            label7.Text = SpiffyText.String00138;
            label13.Text = SpiffyText.String00138;
            label18.Text = SpiffyText.String00138;
            label23.Text = SpiffyText.String00138;

            //pw info tooltip
            toolTipAccounts.SetToolTip(label3, SpiffyText.String00139);
            toolTipAccounts.SetToolTip(label7, SpiffyText.String00139);
            toolTipAccounts.SetToolTip(label13, SpiffyText.String00139);
            toolTipAccounts.SetToolTip(label18, SpiffyText.String00139);
            toolTipAccounts.SetToolTip(label23, SpiffyText.String00139);

            //domain
            label4.Text = SpiffyText.String00140;
            label6.Text = SpiffyText.String00140;
            label11.Text = SpiffyText.String00140;
            label16.Text = SpiffyText.String00140;
            label21.Text = SpiffyText.String00140;

            //google apps
            checkBox3.Text = SpiffyText.String00141;
            checkBox4.Text = SpiffyText.String00141;
            checkBox5.Text = SpiffyText.String00141;
            checkBox8.Text = SpiffyText.String00141;
            checkBox11.Text = SpiffyText.String00141;

            //Options boxes
            groupBox1.Text = SpiffyText.String00146;
            groupBox2.Text = SpiffyText.String00146;
            groupBox3.Text = SpiffyText.String00146;
            groupBox4.Text = SpiffyText.String00146;
            groupBox5.Text = SpiffyText.String00146;

            //checkbox timer 1
            cbA1IntervalEnabled.Text = SpiffyText.String00142;
            cbA2IntervalEnabled.Text = SpiffyText.String00142;
            checkBox7.Text = SpiffyText.String00142;
            checkBox10.Text = SpiffyText.String00142;
            checkBox13.Text = SpiffyText.String00142;

            //checkbox timer 2 (minutes)
            label5.Text = SpiffyText.String00143;
            label10.Text = SpiffyText.String00143;
            label12.Text = SpiffyText.String00143;
            label17.Text = SpiffyText.String00143;
            label22.Text = SpiffyText.String00143;

            //Checkbox label  
            checkBox1.Text = SpiffyText.String00144;
            checkBox2.Text = SpiffyText.String00144;
            checkBox6.Text = SpiffyText.String00144;
            checkBox9.Text = SpiffyText.String00144;
            checkBox12.Text = SpiffyText.String00144;
      
            //Checkbox custom sound
            checkBox14.Text = SpiffyText.String00145;
            checkBox15.Text = SpiffyText.String00145;
            checkBox16.Text = SpiffyText.String00145;
            checkBox17.Text = SpiffyText.String00145;
            checkBox18.Text = SpiffyText.String00145;

            //buttons
            button1.Text = SpiffyText.String00152;
            button2.Text = SpiffyText.String00153;
            button3.Text = SpiffyText.String00154;
            button4.Text = SpiffyText.String00147; //reset

        }

        public void saveAccounts()
        {
            //Encrypt passwords BEFORE SAVE if username and password is entered
            //Password textfields are NOT linked to settings only changed by code (below)

            //Account 1
            if (String.IsNullOrEmpty(tbA1Name.Text)) tbA1Name.Text = SpiffyText.String00134 + " 1";
            if (tbA1Username.Text != "" && tbA1Password.Text != "")
            {
                Properties.Settings.Default.A1Password =
                    SpiffyStuff.EncryptString(SpiffyStuff.ToSecureString(tbA1Password.Text));
                tbA1Password.Clear(); //clear so it wont be saved again
            }

            //Account 2
            if (String.IsNullOrEmpty(tbA2Name.Text)) tbA2Name.Text = SpiffyText.String00134 + " 2";
            if (tbA2Username.Text != "" && tbA2Password.Text != "")
            {
                Properties.Settings.Default.A2Password =
                    SpiffyStuff.EncryptString(SpiffyStuff.ToSecureString(tbA2Password.Text));
                tbA2Password.Clear(); //clear so it wont be saved again
            }

            //Account 3
            if (String.IsNullOrEmpty(tbA3Name.Text)) tbA3Name.Text = SpiffyText.String00134 + " 3";
            if (tbA3Username.Text != "" && tbA3Password.Text != "")
            {
                Properties.Settings.Default.A3Password =
                    SpiffyStuff.EncryptString(SpiffyStuff.ToSecureString(tbA3Password.Text));
                tbA3Password.Clear(); //clear so it wont be saved again
            }

            //Account 4
            if (String.IsNullOrEmpty(tbA4Name.Text)) tbA4Name.Text = SpiffyText.String00134 + " 4";
            if (tbA4Username.Text != "" && tbA4Password.Text != "")
            {
                Properties.Settings.Default.A4Password =
                    SpiffyStuff.EncryptString(SpiffyStuff.ToSecureString(tbA4Password.Text));
                tbA4Password.Clear(); //clear so it wont be saved again
            }

            //Account 5
            if (String.IsNullOrEmpty(tbA5Name.Text)) tbA5Name.Text = SpiffyText.String00134 + " 5";
            if (tbA5Username.Text != "" && tbA5Password.Text != "")
            {
                Properties.Settings.Default.A5Password =
                    SpiffyStuff.EncryptString(SpiffyStuff.ToSecureString(tbA5Password.Text));
                tbA5Password.Clear(); //clear so it wont be saved again
            }     
            
            //PRE SAVE CHECK (empty accounts with timer enabled)
            if ((Properties.Settings.Default.A1Username == "" || Properties.Settings.Default.A1Password == null)
                    && Properties.Settings.Default.A1EnableInterval)
            {
                SpiffyStuff.writeLog(SpiffyText.String00008 + ", " + //empty user or pass detected
                                     Form1.AC1.AccountName + " " +  //acc name
                                     SpiffyText.String00011 + "...", mainForm.rtbLog); //disabled
                Properties.Settings.Default.A1EnableInterval = false;
            }
            if ((Properties.Settings.Default.A2Username == "" || Properties.Settings.Default.A2Password == null)
                && Properties.Settings.Default.A2EnableInterval)
            {
                SpiffyStuff.writeLog(SpiffyText.String00008 + ", " + //empty user or pass detected
                                     Form1.AC2.AccountName + " " +  //acc name
                                     SpiffyText.String00011 + "...", mainForm.rtbLog); //disabled                Properties.Settings.Default.A2EnableInterval = false;
            }
            if ((Properties.Settings.Default.A3Username == "" || Properties.Settings.Default.A3Password == null)
                && Properties.Settings.Default.A3EnableInterval)
            {
                SpiffyStuff.writeLog(SpiffyText.String00008 + ", " + //empty user or pass detected
                                     Form1.AC3.AccountName + " " +  //acc name
                                     SpiffyText.String00011 + "...", mainForm.rtbLog); //disabled                Properties.Settings.Default.A3EnableInterval = false;
            }
            if ((Properties.Settings.Default.A4Username == "" || Properties.Settings.Default.A4Password == null)
                && Properties.Settings.Default.A4EnableInterval)
            {
                SpiffyStuff.writeLog(SpiffyText.String00008 + ", " + //empty user or pass detected
                                     Form1.AC4.AccountName + " " +  //acc name
                                     SpiffyText.String00011 + "...", mainForm.rtbLog); //disabled                Properties.Settings.Default.A4EnableInterval = false;
            }
            if ((Properties.Settings.Default.A5Username == "" || Properties.Settings.Default.A5Password == null) 
                && Properties.Settings.Default.A5EnableInterval)
            {
                SpiffyStuff.writeLog(SpiffyText.String00008 + ", " + //empty user or pass detected
                                     Form1.AC5.AccountName + " " +  //acc name
                                     SpiffyText.String00011 + "...", mainForm.rtbLog); //disabled                Properties.Settings.Default.A5EnableInterval = false;
            }

            // ###### FINAL SAVE ###### //
            SpiffyStuff.writeLog(SpiffyText.String00009 + "...", mainForm.rtbLog); //saving accounts
            saveNow();

            //SET TAB PAGE TEXT
            setTabPageText(tabPage1, 1);
            setTabPageText(tabPage2, 2);
            setTabPageText(tabPage3, 3);
            setTabPageText(tabPage4, 4);
            setTabPageText(tabPage5, 5);

            //Log done
            SpiffyStuff.writeLog(SpiffyText.String00010, mainForm.rtbLog);

            // ###### SYNC ACCOUNTS ###### //
            mainForm.syncAccounts(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //save and sync before closing
            saveAccounts();
            //close
            this.Close();
        }

        void setTabPageText(TabPage tab, int account)
        {
            switch (account)
            {
                case 1:
                    if (Properties.Settings.Default.A1Name != SpiffyText.String00134 + " 1")
                    {
                        tab.Text = Properties.Settings.Default.A1Name;
                    }
                    break;
                case 2:
                    if(Properties.Settings.Default.A2Name != SpiffyText.String00134 + " 2")
                    {
                        tab.Text = Properties.Settings.Default.A2Name;
                    }
                    break;
                case 3:
                    if (Properties.Settings.Default.A3Name != SpiffyText.String00134 + " 3")
                    {
                        tab.Text = Properties.Settings.Default.A3Name;
                    }
                    break;
                case 4:
                    if (Properties.Settings.Default.A4Name != SpiffyText.String00134 + " 4")
                    {
                        tab.Text = Properties.Settings.Default.A4Name;
                    }
                    break;
                case 5:
                    if (Properties.Settings.Default.A5Name != SpiffyText.String00134 + " 5")
                    {
                        tab.Text = Properties.Settings.Default.A5Name;
                    }
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Properties.Settings.Default.Reload();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveAccounts();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show
                (SpiffyText.String00148 + " (" + tabControl1.SelectedTab.Text + ")", "Spiffy",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //Log reset to file
                SpiffyStuff.writeErrorLog("resetAccount: " + tabControl1.SelectedTab.Name);

                #region reset account switches
                switch (tabControl1.SelectedTab.Name)
                {
                    case "tabPage1":
                        Properties.Settings.Default.A1Password = String.Empty;
                        clearAccount(
                            tbA1Name,
                            tbA1Username,
                            tbA1Password,
                            textBox1,
                            checkBox3,
                            cbA1IntervalEnabled,
                            numericUpDown1,
                            checkBox1,
                            tbA1Label,
                            checkBox14,
                            textBox5);
                        break;

                    case "tabPage2":
                        Properties.Settings.Default.A2Password = String.Empty;
                        clearAccount(
                            tbA2Name,
                            tbA2Username,
                            tbA2Password,
                            textBox2,
                            checkBox4,
                            cbA2IntervalEnabled,
                            numericUpDown2,
                            checkBox2,
                            tbA2Label,
                            checkBox15,
                            textBox6);
                        break;

                    case "tabPage3":
                        Properties.Settings.Default.A3Password = String.Empty;
                        clearAccount(
                            tbA3Name,
                            tbA3Username,
                            tbA3Password,
                            textBox3,
                            checkBox5,
                            checkBox7,
                            numericUpDown3,
                            checkBox6,
                            textBox4,
                            checkBox16,
                            textBox7);
                        break;

                    case "tabPage4":
                        Properties.Settings.Default.A4Password = String.Empty;
                        clearAccount(
                            tbA4Name,
                            tbA4Username,
                            tbA4Password,
                            textBox8,
                            checkBox8,
                            checkBox10,
                            numericUpDown4,
                            checkBox9,
                            textBox9,
                            checkBox17,
                            textBox10);
                        break;

                    case "tabPage5":
                        Properties.Settings.Default.A5Password = String.Empty;
                        clearAccount(
                            tbA5Name,
                            tbA5Username,
                            tbA5Password,
                            textBox13,
                            checkBox11,
                            checkBox13,
                            numericUpDown5,
                            checkBox12,
                            textBox14,
                            checkBox18,
                            textBox11);
                        break;
                }
                #endregion
            }
            
        }

        public void saveNow()
        {
            //Log save to file
            SpiffyStuff.writeErrorLog("saveNow(accounts)");

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

        #region account browse clicks

        static void openBrowseWindow(TextBox tb)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = SpiffyText.String00051 + " (*.wav;*.mp3)|*.wav;*.mp3"; //audio files
            dialog.Title = SpiffyText.String00048; //select a sound alert
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tb.Text = dialog.FileName;
            }
            dialog.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openBrowseWindow(textBox5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openBrowseWindow(textBox6);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openBrowseWindow(textBox7);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openBrowseWindow(textBox10);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            openBrowseWindow(textBox11);
        }

        #endregion

        #region alert test sound clicks
        private void button6_Click(object sender, EventArgs e)
        {
            SpiffyStuff.playNewMailSound(textBox5.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SpiffyStuff.playNewMailSound(textBox6.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SpiffyStuff.playNewMailSound(textBox7.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SpiffyStuff.playNewMailSound(textBox10.Text);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SpiffyStuff.playNewMailSound(textBox11.Text);
        }

        #endregion

    }
}
