/*************************************************
 *                                               *
 *     What day is it?                           *
 *                                               *
 *     Author: Timur Iskhakov                    *
 *     E-mail: iskhakovt@gmail.com               *
 *                                               *
 *************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Timers;
using System.Windows.Forms;

namespace What_day_is_it
{
    static class Windows
    {
        private static MainWindow Window = new MainWindow();

        private static Boolean settingOpened = false;

        public static void LogInTray()
        {
            Window.updateData();
        }

        public static void settingsClosed()
        {
            settingOpened = false;

            showMainWindow();
        }

        public static void showMainWindow()
        {
            if (!settingOpened)
            {
                Log.ApplicationOpened();

                Program.ApplicationWindow.deleteBalloonInfo();

                Window.updateData();
                Window.Show();
                Window.WindowState = FormWindowState.Normal;
            }
        }

        public static void showSettings(CoreWindow.SettingsParametr Parametr)
        {
            Log.SettingsOpened();

            settingOpened = true;
            Window.Visible = false;

            FirstStart Settings;

            if (Parametr == CoreWindow.SettingsParametr.First)
            {
                Settings = new FirstStart(true);
            }
            else
            {
                Settings = new FirstStart();
            }

            Settings.Show();
        }

        #region Timer

        private static Int32 timerTime = 750;
        private static System.Timers.Timer Timer = new System.Timers.Timer(timerTime);

        public static void initializeTimer()
        {
            Timer.Elapsed += new ElapsedEventHandler(timerTick);
            Timer.Start();
        }

        private static void timerTick(object sender, EventArgs e)
        {
            if (DateTime.Today != Core.Today && !settingOpened)
            {
                Program.ApplicationWindow.deleteBalloonInfo();
                Window.updateData();
            }
        }

        #endregion
    }
}
