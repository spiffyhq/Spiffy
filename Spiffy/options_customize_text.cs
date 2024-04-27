using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace Spiffy
{
    public partial class options_customize_text : UserControl
    {
        public options_customize_text()
        {
            InitializeComponent();
        }

        private void options_customize_logging_Load(object sender, EventArgs e)
        {
            InitializeLocale();
        }

        private void InitializeLocale()
        {
            label3.Text = SpiffyText.String00255;
            groupBox1.Text = SpiffyText.String00256;
            label10.Text = SpiffyText.String00257; //font
            label11.Text = SpiffyText.String00258; //pt
            label4.Text = SpiffyText.String00259;
            label2.Text = SpiffyText.String00260;

            cbWordWrap.Text = SpiffyText.String00261;
            cbLogDateTimeEnabled.Text = SpiffyText.String00262;
            label1.Text = SpiffyText.String00263;
            toolTipCustomLogging.SetToolTip(pictureBox1, SpiffyText.String00264);

            groupBox2.Text = SpiffyText.String00265;
            checkBox21.Text = SpiffyText.String00266;
            toolTipCustomLogging.SetToolTip(checkBox21, SpiffyText.String00267);

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SpiffyStuff.openHelpURL("datetime");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog2.Color;
            }
            else
            {
                button1.BackColor = Color.Black;
            }
            colorDialog2.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                button2.BackColor = colorDialog2.Color;
            }
            else
            {
                button2.BackColor = Color.White;
            }
            colorDialog2.Dispose();
        }


    }
}
