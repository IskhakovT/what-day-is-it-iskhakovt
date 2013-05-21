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
using System.Windows.Forms;

namespace What_day_is_it
{
    static class Core
    {
        #region ApplicationWindow

        private static CoreWindow _ApplicationWindow;

        public static CoreWindow ApplicationWindow
        {
            get { return _ApplicationWindow; }
        }

        #endregion

        #region Today

        private static DateTime _Today;

        public static DateTime Today
        {
            get { return _Today; }
        }

        public static void setToday()
        {
            if (DateTime.Today.Year > maxTodayYear)
            {
                throw new Exception("Today is too big date");
            }

            _Today = DateTime.Today;
        }

        #endregion

        public static void initialize()
        {
            setToday();

            Data.checkDirectory();
            Data.loadSettings();

            _ApplicationWindow = new CoreWindow();
            Windows.initializeTimer();
        }

        public static Process runningInstance()
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

        #region Constants

        private static String BadArgs = "Bad arguments:\n";
        private static String StartTray = "startup";

        private static Int32 maxTodayYear = 2199;

        #endregion
    }
}
