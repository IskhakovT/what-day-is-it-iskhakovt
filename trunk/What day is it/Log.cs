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
        private static void WriteLog(String message)
        {
            StreamWriter writeLog = new StreamWriter(Data.LogFile, true);
            writeLog.Write(DateTime.Now.ToString() + LogResources.Space + message);
            writeLog.WriteLine();
            writeLog.Close();
        }

        #region Logs

        public static void WriteException(Exception ex)
        {
            WriteLog(ex.ToString());
        }

        public static void Launch()
        {
            WriteLog(LogResources.applicationLaunch);
        }

        public static void LogIn()
        {
            WriteLog(LogResources.logIn);
        }

        public static void LogInTray()
        {
            WriteLog(LogResources.logInTray);
        }

        public static void LogInTrayAborted()
        {
            WriteLog(LogResources.logInTrayAborted);
        }

        public static void LogAgain()
        {
            WriteLog(LogResources.tryLogAgain);
        }

        public static void FirstSettingsOpened()
        {
            WriteLog(LogResources.firstSettingsOpened);
        }

        public static void SettingsFileNotFound()
        {
            WriteLog(LogResources.settingsNotFound);
        }

        public static void DataFileNotFound()
        {
            WriteLog(LogResources.dataNotFound);
        }

        public static void errorIO(String error)
        {
            WriteLog(LogResources.stringIO + LogResources.Colon + LogResources.Colon + error);
        }

        public static void SettingsOpened()
        {
            WriteLog(LogResources.settingsOpened);
        }

        public static void SaveButton()
        {
            WriteLog(LogResources.saveSettings);
        }

        public static void ApplicationOpened()
        {
            WriteLog(LogResources.applicationOpened);
        }

        public static void ApplicationClosed()
        {
            WriteLog(LogResources.applicationClosed);
        }

        public static void ApplicationExit()
        {
            WriteLog(LogResources.applicationExit);
        }

        public static void LogOut()
        {
            WriteLog(LogResources.logOut + Environment.NewLine);
        }

        #endregion
    }
}
