using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Spiffy
{
    public partial class options_customize_mouse : UserControl
    {
        public options_customize_mouse()
        {
            InitializeComponent();
        }

        private void InitializeLocale()
        {
            label2.Text = SpiffyText.String00220;
            groupBox4.Text = SpiffyText.String00221;

            checkBox3.Text = SpiffyText.String00222;
            checkBox4.Text = SpiffyText.String00223;
            checkBox6.Text = SpiffyText.String00224;
            checkBox5.Text = SpiffyText.String00225;
        }

        private void options_customize_mouse_Load(object sender, EventArgs e)
        {
            InitializeLocale();
        }
    }
}
