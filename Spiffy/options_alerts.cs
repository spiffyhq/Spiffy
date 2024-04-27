using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Spiffy
{
    public partial class options_alerts : UserControl
    {
        public options_alerts()
        {

            InitializeComponent();

            //set default alert icon combobox (if empty)
            switch (Properties.Settings.Default.AppTrayIconAlertImageNr)
            {
                case 1:
                    Properties.Settings.Default.AppTrayIconAlertImage = SpiffyText.String00059; //star (default)
                    break;
                case 2:
                    Properties.Settings.Default.AppTrayIconAlertImage = SpiffyText.String00060; //green
                    break;
                case 3:
                    Properties.Settings.Default.AppTrayIconAlertImage = SpiffyText.String00061; //gray
                    break;
                case 4:
                    Properties.Settings.Default.AppTrayIconAlertImage = SpiffyText.String00062; //blue
                    break;
                case 5:
                    Properties.Settings.Default.AppTrayIconAlertImage = SpiffyText.String00063; //purple
                    break;
                case 6:
                    Properties.Settings.Default.AppTrayIconAlertImage = SpiffyText.String00064; //red
                    break;
            } 
        }

        private void options_alerts_Load(object sender, EventArgs e)
        {
            InitializeLocale();
            cmbTrayIcon.SelectedItem = Properties.Settings.Default.AppTrayIconAlertImage;
        }

        private void btnBrowseForSound_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = SpiffyText.String00051 + " (*.wav;*.mp3)|*.wav;*.mp3"; //audio files
            dialog.Title = SpiffyText.String00048; //select a sound alert
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbAlertSound.Text = dialog.FileName;
            }
            dialog.Dispose();
        }

        private void InitializeLocale()
        {
            //title
            label3.Text = SpiffyText.String00172;

            groupBox1.Text = SpiffyText.String00173;
            cbShowAlert.Text = SpiffyText.String00174;
            label4.Text = SpiffyText.String00175;
            cbShowUntilRead.Text = SpiffyText.String00176;
            label6.Text = SpiffyText.String00177;
            label5.Text = SpiffyText.String00188;

            groupBox3.Text = SpiffyText.String00178;
            checkBox2.Text = SpiffyText.String00179;
            cbAlertSliding.Text = SpiffyText.String00180;
            label9.Text = SpiffyText.String00181;
            label1.Text = SpiffyText.String00182;
            label10.Text = SpiffyText.String00183;
            label2.Text = SpiffyText.String00182;

            groupBox6.Text = SpiffyText.String00184;
            cbAppTrayIconChangeEnabled.Text = SpiffyText.String00185;

            groupBox2.Text = SpiffyText.String00186;
            checkBox3.Text = SpiffyText.String00187;

            //Alert icon combobox
            cmbTrayIcon.Items.Add(SpiffyText.String00059);
            cmbTrayIcon.Items.Add(SpiffyText.String00062);
            cmbTrayIcon.Items.Add(SpiffyText.String00061);
            cmbTrayIcon.Items.Add(SpiffyText.String00060);            
            cmbTrayIcon.Items.Add(SpiffyText.String00063);
            cmbTrayIcon.Items.Add(SpiffyText.String00064);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpiffyStuff.playNewMailSound(tbAlertSound.Text);
        }
        
     }
}
