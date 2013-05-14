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

using System.Diagnostics;

namespace What_day_is_it
{
    static class Core
    {
        private static Window _MainWindow;

        private static Boolean _FirstStart = false;

        private static DateTime _Today;

        public static Window mainWindow
        {
            get { return _MainWindow; }
        }

        public static void Initialize()
        {
            _MainWindow = new Window();
        }

        public static Boolean FirstStart
        {
            get { return _FirstStart; }
            set { _FirstStart = value; }
        }

        public static DateTime Today
        {
            get { return _Today; }
        }

        public static void ShowMainWindow()
        {
            FirstStart = false;

            mainWindow.settingsOpened = false;
            mainWindow.newDay();

            mainWindow.showForm();
        }

        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    return process;
                }
            }

            return null;
        }

        public static Boolean checkArgs(String[] Args)
        {
            if (Args.Length == 1 && Args[0] == StartTray)
            {
                return false;
            }
            else if (Args.Length == 0)
            {
                return true;
            }
            else
            {
                String Arguments = String.Empty;

                for (Int32 i = 0; i < Args.Length; ++i)
                {
                    Arguments += Args[i] + Environment.NewLine;
                }

                throw new Exception(BadArgs + Arguments);
            }
        }

        public static void setToday()
        {
            if (DateTime.Today.Year > maxTodayYear)
            {
                throw new Exception("Today is too big date");
            }

            _Today = DateTime.Today;
        }

        private static String BadArgs = "Bad arguments:\n";
        private static String StartTray = "startup";

        private static Int32 maxTodayYear = 2199;
    }
}
