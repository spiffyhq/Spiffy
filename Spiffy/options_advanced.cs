using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Spiffy
{
    public partial class options_advanced : UserControl
    {
        public options_advanced()
        {
            InitializeComponent();
        }

        private void InitializeLocale()
        {
            //title
            label2.Text = SpiffyText.String00320;

            //custom browser
            groupBox4.Text = SpiffyText.String00323;
            checkBox2.Text = SpiffyText.String00324;

            //Gmail location
            groupBox2.Text = SpiffyText.String00325;
            checkBox4.Text = SpiffyText.String00278;
            settingsAdvancedTooltip.SetToolTip(checkBox4, SpiffyText.String00279);

            //Debug
            groupBox1.Text = SpiffyText.String00321;
            checkBox1.Text = SpiffyText.String00322;
        }

        private void options_advanced_Load(object sender, EventArgs e)
        {
            InitializeLocale();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = SpiffyText.String00326 + " (*.exe)|*.exe"; //programs
            dialog.Title = SpiffyText.String00327; //select a program
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
            }
            dialog.Dispose();
        }
    }
}
