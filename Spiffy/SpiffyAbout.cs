using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;


namespace Spiffy
{
    public partial class SpiffyAbout : Form
    {
        public SpiffyAbout()
        {
            InitializeComponent();
            this.Text = SpiffyText.String00120.Replace("&","");
            label1.Text = "Spiffy v" + Form1.appVersion;

            try
            {
                label3.Text = "Build " + Form1.AppBuild;
            }
            catch (Exception sa1)
            {
                label3.Text = "Build unknown";
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SpiffyStuff.openURL(Properties.Resources.AppStringWebsiteURL);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
