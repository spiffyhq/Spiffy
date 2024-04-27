using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Spiffy
{
    public partial class options_network_proxy : UserControl
    {

        public options_network_proxy()
        {
            InitializeComponent();
        }

        private void options_network_proxy_Load(object sender, EventArgs e)
        {
            InitializeLocale();
        }

        private void InitializeLocale()
        {
            label3.Text = SpiffyText.String00306;

            groupBox3.Text = SpiffyText.String00307;
            cbProxyEnabled.Text = SpiffyText.String00308;
            label6.Text = SpiffyText.String00309;
            label7.Text = SpiffyText.String00310;

            cbProxyAuthReq.Text = SpiffyText.String00311;
            label8.Text = SpiffyText.String00312;
            label9.Text = SpiffyText.String00313;
            toolTipProxy.SetToolTip(pictureBox1, SpiffyText.String00314);

        }

        //only allow numbers in port field
        private void tbProxyServerPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            } 
        }
    }
}
