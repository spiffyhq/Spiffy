using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Spiffy
{
    public partial class options_customize_tray : UserControl
    {
        public options_customize_tray()
        {
            InitializeComponent();

            //set default tray icon combobox
            switch (Properties.Settings.Default.AppDefaultTrayIconNr)
            {
                case 1:
                    Properties.Settings.Default.AppDefaultTrayIcon = SpiffyText.String00058; //green (default)
                    break;
                case 2:
                    Properties.Settings.Default.AppDefaultTrayIcon = SpiffyText.String00061; //gray
                    break;
                case 3:
                    Properties.Settings.Default.AppDefaultTrayIcon = SpiffyText.String00062; //blue
                    break;
                case 4:
                    Properties.Settings.Default.AppDefaultTrayIcon = SpiffyText.String00063; //purple
                    break;
                case 5:
                    Properties.Settings.Default.AppDefaultTrayIcon = SpiffyText.String00064; //red
                    break;
            }               

            //set tray action combobox
            switch (Properties.Settings.Default.AppTrayIconBehaviourNr)
            {
                case 1:
                    Properties.Settings.Default.AppTrayIconBehaviour = SpiffyText.String00043; //restore window (default)
                    break;
                case 2:
                    Properties.Settings.Default.AppTrayIconBehaviour = SpiffyText.String00044; //check for new mail
                    break;
                case 3:
                    Properties.Settings.Default.AppTrayIconBehaviour = SpiffyText.String00045; //open gmail
                    break;
                case 4:
                    Properties.Settings.Default.AppTrayIconBehaviour = SpiffyText.String00046; //tell me again
                    break;
                case 5:
                    Properties.Settings.Default.AppTrayIconBehaviour = SpiffyText.String00047; //start mail client
                    break;
            } 

            //set unread account combobox
            switch (Properties.Settings.Default.AppShowUnreadInTrayAccountNr)
            {
                case 1:
                    Properties.Settings.Default.AppShowUnreadInTrayAccount = Form1.AC1.AccountName;
                    break;
                case 2:
                    Properties.Settings.Default.AppShowUnreadInTrayAccount = Form1.AC2.AccountName;
                    break;
                case 3:
                    Properties.Settings.Default.AppShowUnreadInTrayAccount = Form1.AC3.AccountName;
                    break;
                case 4:
                    Properties.Settings.Default.AppShowUnreadInTrayAccount = Form1.AC4.AccountName;
                    break;
                case 5:
                    Properties.Settings.Default.AppShowUnreadInTrayAccount = Form1.AC5.AccountName;
                    break;
                case 6:
                    Properties.Settings.Default.AppShowUnreadInTrayAccount = SpiffyText.String00021;
                    break;
            }
                            
        }

        private void options_customize_tray_Load(object sender, EventArgs e)
        {
            InitializeLocale(); //do this before settings comboboxes

            //set saved action
            comboBox1.SelectedItem = Properties.Settings.Default.AppDefaultTrayIcon;
            comboBox2.SelectedItem = Properties.Settings.Default.AppTrayIconBehaviour;
            comboBox3.SelectedItem = Properties.Settings.Default.AppShowUnreadInTrayAccount;    
        }

        private void InitializeLocale()
        {
            //Form title
            label2.Text = SpiffyText.String00273;
            
            //options
            groupBox1.Text = SpiffyText.String00274;
            label1.Text = SpiffyText.String00275;

            //Icon combobox
            comboBox1.Items.Add(SpiffyText.String00058);
            comboBox1.Items.Add(SpiffyText.String00061);
            comboBox1.Items.Add(SpiffyText.String00062);
            comboBox1.Items.Add(SpiffyText.String00063);
            comboBox1.Items.Add(SpiffyText.String00064);
            
            //Tray doubleclick action combobox
            label3.Text = SpiffyText.String00277;
            comboBox2.Items.Add(SpiffyText.String00043);
            comboBox2.Items.Add(SpiffyText.String00044);
            comboBox2.Items.Add(SpiffyText.String00045);
            comboBox2.Items.Add(SpiffyText.String00046);
            comboBox2.Items.Add(SpiffyText.String00047);

            //single click option
            checkBox4.Text = SpiffyText.String00287;
            
            //account in tray
            groupBox3.Text = SpiffyText.String00280;
            checkBox1.Text = SpiffyText.String00281;

            //Account combobox
            comboBox3.Items.Add(Form1.AC1.AccountName);
            comboBox3.Items.Add(Form1.AC2.AccountName);
            comboBox3.Items.Add(Form1.AC3.AccountName);
            comboBox3.Items.Add(Form1.AC4.AccountName);
            comboBox3.Items.Add(Form1.AC5.AccountName);
            comboBox3.Items.Add(SpiffyText.String00021); //all accounts

            //show account name checkbox
            checkBox2.Text = SpiffyText.String00282;

            //custom icons
            groupBox2.Text = SpiffyText.String00283;
            checkBox3.Text = SpiffyText.String00284;
            settingsTrayIconTooltip.SetToolTip(checkBox3, SpiffyText.String00289);

            //default and new mail label
            label4.Text = SpiffyText.String00285;
            label5.Text = SpiffyText.String00286;
            settingsTrayIconTooltip.SetToolTip(label5, SpiffyText.String00290);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenBrowseToFileDialog(textBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenBrowseToFileDialog(textBox2);
        }

        public static void OpenBrowseToFileDialog(TextBox Tb)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = SpiffyText.String00053 + " (*.ico)|*.ico"; //icon files
            dialog.Title = SpiffyText.String00050; //select a tray icon
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Tb.Text = dialog.FileName;
            }
            dialog.Dispose();
        }

    }
}
