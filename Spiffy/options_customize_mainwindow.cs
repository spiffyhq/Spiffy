using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Spiffy
{
    public partial class options_customize_mainwindow : UserControl
    {
        public options_customize_mainwindow()
        {
            InitializeComponent();
        }

        private void options_customize_mainwindow_Load(object sender, EventArgs e)
        {
            InitializeLocale();
            label5.Text = Properties.Settings.Default.AppOpacity + " %";
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label5.Text = trackBar1.Value.ToString() + " %";
        }

        private void InitializeLocale()
        {
            label2.Text = SpiffyText.String00208;
            groupBox2.Text = SpiffyText.String00209;
            label3.Text = SpiffyText.String00210;

            groupBox5.Text = SpiffyText.String00211;

            cbAlwaysOnTop.Text = SpiffyText.String00212;
            cbAppShowMenuBar.Text = SpiffyText.String00213;
            cbAppShowToolBar.Text = SpiffyText.String00214;
            label1.Text = SpiffyText.String00215;
        }
    }
}
