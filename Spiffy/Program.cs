using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;

namespace Spiffy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //catch command line arguments
            try
            {
                PortableSettingsProvider.customAppSettingsPath = args[0];
                if (!System.IO.Directory.Exists(args[0]))
                {
                    MessageBox.Show("Cannot find directory " + args[0] +
                        "\n\nClick OK to Quit.", "Spiffy",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception e)
            {
                //no args, other stuff is handled in PortableSettingsProvider.GetAppSettingsPath()
            }

            Application.Run(new Form1());          
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                SpiffyStuff.LogExceptionInfo(ex, "CurrentDomain", true);
                MessageBox.Show(SpiffyText.String00094 + "...\n" +
                                SpiffyText.String00095 + "\n\n" +
                                SpiffyText.String00096 + " " +
                                SpiffyText.String00097 + "\n\n" + ex.Message + ex.StackTrace,
                      SpiffyText.String00098, MessageBoxButtons.OK, MessageBoxIcon.Stop); //fatal error
            }
            finally
            {
                Application.Exit();
            }
        }
    }
}