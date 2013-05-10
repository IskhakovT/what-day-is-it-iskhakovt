using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace What_day_is_it
{
    static class Log
    {
        public static void WriteLog(String message)
        {
            StreamWriter writeLog = new StreamWriter(Default.LogFile, true);
            writeLog.Write(message);
            writeLog.WriteLine();
            writeLog.Close();
        }

        public static void WriteLogIn()
        {
            WriteLog(DateTime.Now.ToString() + " Log in");
        }

        public static void LogInTray()
        {
            WriteLog(DateTime.Now.ToString() + " Log in tray");
        }

        public static void LogAgain()
        {
            WriteLog(DateTime.Now.ToString() + " Tried to log in again");
        }

        public static void FirstSettingsOpened()
        {
            WriteLog(DateTime.Now.ToString() + " First start master opened");
        }

        public static void SettingsOpened()
        {
            WriteLog(DateTime.Now.ToString() + " Settings opened");
        }

        public static void SaveButton()
        {
            WriteLog(DateTime.Now.ToString() + " Saving settings");
        }

        public static void ApplicationClosed()
        {
            WriteLog(DateTime.Now.ToString() + " Closed in tray");
        }

        public static void ApplicationOpened()
        {
            WriteLog(DateTime.Now.ToString() + " Opened from tray");
        }

        public static void WriteLogOut()
        {
            WriteLog(DateTime.Now.ToString() + " Log out\n");
        }
    }


}
