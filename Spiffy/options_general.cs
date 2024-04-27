using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
//
using System.IO;
using System.Globalization;

namespace Spiffy
{
    public partial class options_general : UserControl
    {
        //LANGUAGES ARRAY, must be sorted to search properly (done in Load with Array.Sort())
        string[] languages = { "nl-NL", "it-IT", "es-ES", "pt-PT", "he", "sv-SE", "ru", "pl", "zh-Hant", "fr-FR", "ro" };

        public RegistryKey rkRun = Registry.CurrentUser.OpenSubKey(
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

        public options_general()
        {
            InitializeComponent();  
        }

        private void InitializeLocale()
        {
            label3.Text = SpiffyText.String00192;
            groupBox3.Text = SpiffyText.String00193;
            cbRunAtLogon.Text = SpiffyText.String00194;
            cbMinimizeStartup.Text = SpiffyText.String00195;
            checkBox3.Text = SpiffyText.String00196;
            optionsGeneralTooltip.SetToolTip(checkBox3, SpiffyText.String00197);

            groupBox1.Text = SpiffyText.String00198;
            checkBox2.Text = SpiffyText.String00199;
            label1.Text = SpiffyText.String00200; //hour(s)

            groupBox9.Text = SpiffyText.String00201;
            cbMinimizeToTray.Text = SpiffyText.String00202;
            cbCloseToTray.Text = SpiffyText.String00203;

            groupBox4.Text = SpiffyText.String00204;
            label2.Text = SpiffyText.String00205; //restart when changing lang!

            groupBox2.Text = SpiffyText.String00206; //updates
            cbCheckVersionAtStartup.Text = SpiffyText.String00207;

            //Add languages to combobox by scanning current folder for language folders           
            //First add English as default
            comboBox1.Items.Add("English");
            
            //Then add the rest (look for dirs)
            try
            {
                String[] dirs = Directory.GetDirectories(Application.StartupPath);
                foreach(string dir in dirs)
                {
                    //awesome binarysearch to find the dirs
                    string tempDirname = dir.Replace(Application.StartupPath + "\\", "");
                    //if temp dir is not found in languages array then i is -1 and won't be added
                    int i = Array.BinarySearch(languages, tempDirname); //languages array is on line 20
                    if (i >= 0)
                    {
                        //Get the English name from Culture (nl-NL) to fill dropdownbox with languages
                        CultureInfo tempCulture = new CultureInfo(tempDirname);
                        //comboBox1.Items.Add(tempCulture.EnglishName); //0.5.11
                        comboBox1.Items.Add(tempCulture.DisplayName); //0.5.12
                    }

                }
            }
            catch (Exception io1)
            {
                //no dirs?
            }
        }

        private void options_general_Load(object sender, EventArgs e)
        {
            //Run at logon check (for checkbox, checks if run value is available)
            if (rkRun.GetValue("Spiffy") == null)
            {
                Properties.Settings.Default.AppRunAtLogon = false;
            }
            else
            {
                Properties.Settings.Default.AppRunAtLogon = true;
            }

            //SORT THE LANG ARRAY - IMPORTANT or search @InitializeLocale() wont work
            Array.Sort(languages);

            //SET ALL TEXTBOXES ETC
            InitializeLocale();

            //sets language combobox to current language
            //by checking current ui
            comboBox1.SelectedItem = System.Threading.Thread.CurrentThread.CurrentUICulture.DisplayName;
            if (comboBox1.Items.Count == 1) groupBox4.Enabled = false;
            
        }
    }
}
