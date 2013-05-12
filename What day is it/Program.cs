/************************************************************************************************
 *                                                                                              *
 *                                        What day is it?                                       *
 *                                                                                              *
 *                    This program was made to help people with relations to                    *
 *                         make people able to answer a silly question                          *
 *                                       "What day is it?"                                      *
 *                                                                                              *
 *                                                                                              *
 *          Author:         Timur Iskhakov                                                      *
 *          E-mail:         iskhakovt@gmail.com                                                 *
 *          VK:             https://vk.com/iskhakovt                                            *
 *          Facebook:       https://www.facebook.com/iskhakovt                                  *
 *                                                                                              *
 *          Web site:       https://code.google.com/p/what-day-is-it-iskhakovt/                 *
 *                                                                                              *
 *          Release date:   13th of May 2013                                                    *
 *          Version:        1.16.23                                                             *
 *                                                                                              *
 *                                                                                              *
 *   Permission is hereby granted, free of charge, to any person obtaining a copy of this       *
 *   software and associated documentation files (the "Software"), to deal in the Software      *
 *   without restriction,including without limitation the rights to use, copy, modify, merge,   *
 *   publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons *
 *   to whom the Software is furnished to do so, subject to the following conditions:           *
 *                                                                                              *
 *   The above copyright notice and this permission notice shall be included in all copies or   *
 *   substantial portions of the Software.                                                      *
 *                                                                                              *
 *   The Software shall be used for Good, not Evil.                                             *
 *                                                                                              *
 *   The software is provided "as is", without warranty of any kind, express or implied,        *
 *   including but not limited to the warranties of merchantability, fitness for a particular   *
 *   purpose and non infringement. In no event shall the authors or copyright holders be liable *
 *   for any claim, damages or other liability, whether in an action of contract, tort or       *
 *   otherwise, arising from, out of or in connection with the software or the use or other     *
 *   dealings in the software.                                                                  *
 *                                                                                              *
 ************************************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Reflection;

namespace What_day_is_it
{
    static class Program
    {
        [STAThread]
        static void Main(String[] Args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Process process = RunningInstance();

                if (process != null)
                {
                    Log.LogAgain();

                    return;
                }
                
                Default.checkDate();                

                if ((Args.Length == 1 && Args[0] != Default.StartTray) || Args.Length > 1)
                {
                    String Arguments = String.Empty;

                    for (Int32 i = 0; i < Args.Length; ++i)
                    {
                        Arguments += Args[i] + Environment.NewLine;
                    }

                    throw new Exception(Default.BadArgs + Arguments);
                }

                Default.checkDirectory();
                Default.LoadSettings();

                if (Args.Length > 0 && !Default.StartUpEnabled)
                {
                    Log.LogInTrayAborted();
                    Log.LogOut();

                    return;
                }

                if (Default.checkFile())
                {
                    if (Args.Length > 0)
                    {
                        Log.LogInTray();

                        mainWindow = new Window();
                        mainWindow.Closed += (o, e) => Application.Exit();

                        Application.Run();
                    }
                    else
                    {
                        Log.LogIn();

                        mainWindow = new Window();
                        mainWindow.Closed += (o, e) => Application.Exit();
                        mainWindow.Show();

                        Application.Run();
                    }
                }
                else
                {
                    Log.LogIn();
                    Log.FirstSettingsOpened();

                    Default.FirstStart = true;

                    mainWindow = new Window();
                    mainWindow.Closed += (o, e) => Application.Exit();

                    FirstStart Start = new FirstStart();
                    Start.Show();

                    Application.Run();
                }

                Log.LogOut();
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.ToString());

                MessageBox.Show(ex.Message, Vocabulary.CriticalError(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                Log.LogOut();
            }
        }

        private static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        return process;
                    }
                }
            }

            return null;
        }

        private static Window mainWindow;

        public static void ShowMainWindow()
        {
            Default.FirstStart = false;

            mainWindow.settingsOpened = false;
            mainWindow.newDay();

            mainWindow.showForm();
        }
    }
}
