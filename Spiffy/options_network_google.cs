using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Spiffy
{
    public partial class options_network_google : UserControl
    {

        public options_network_google()
        {
            InitializeComponent();
        }

        private void options_network_google_Load(object sender, EventArgs e)
        {
            InitializeLocale();
        }

        private void InitializeLocale()
        {
            label3.Text = SpiffyText.String00295;
            groupBox2.Text = SpiffyText.String00296;
            label2.Text = SpiffyText.String00297;
            
            groupBox1.Text = SpiffyText.String00298;
            checkBox1.Text = SpiffyText.String00299;
            optionsNetworkGoogleTooltip.SetToolTip(checkBox1, SpiffyText.String00300);

        }
    }
}
