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

using System.IO;

namespace What_day_is_it
{
    static class Log
    {
        public static void WriteLog(String message)
        {
            StreamWriter writeLog = new StreamWriter(Data.LogFile, true);
            writeLog.Write(DateTime.Now.ToString() + Space + message);
            writeLog.WriteLine();
            writeLog.Close();
        }

        #region Logs

        public static void LogIn()
        {
            WriteLog("Log in");
        }

        public static void LogInTray()
        {
            WriteLog("Log in tray");
        }

        public static void LogInTrayAborted()
        {
            WriteLog("Log in tray aborted -- it is disabled");
        }

        public static void LogAgain()
        {
            WriteLog("Tried to log in again");
        }

        public static void FirstSettingsOpened()
        {
            WriteLog("First start master opened");
        }

        public static void SettingsOpened()
        {
            WriteLog("Settings opened");
        }

        public static void SaveButton()
        {
            WriteLog("Saving settings");
        }

        public static void ApplicationOpened()
        {
            WriteLog("Opened from tray");
        }

        public static void ApplicationClosed()
        {
            WriteLog("Closed in tray");
        }

        public static void ApplicationExit()
        {
            WriteLog("Closed in tray to exit");
        }

        public static void LogOut()
        {
            WriteLog("Log out\n");
        }

        #endregion

        private static String Space = " ";
    }
}
