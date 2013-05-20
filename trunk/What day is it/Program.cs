/************************************************************************************************
 *                                                                                              *
 *                                        What day is it?                                       *
 *                                                                                              *
 *                     This program was made to help people with relations                      *
 *                                 able to answer a silly question                              *
 *                                       "What day is it?"                                      *
 *                                                                                              *
 *                                                                                              *
 *          Author:         Timur Iskhakov                                                      *
 *          E-mail:         iskhakovt@gmail.com                                                 *
 *          VK:             https://vk.com/iskhakovt                                            *
 *          Facebook:       https://facebook.com/iskhakovt                                      *
 *                                                                                              *
 *          Web site:       https://code.google.com/p/what-day-is-it-iskhakovt/                 *
 *                                                                                              *
 *          Release date:   21st of May 2013                                                    *
 *          Version:        1.19.35                                                             *
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

                #region Initialization

                Process process = Core.runningInstance();

                if (process != null)
                {
                    Log.LogAgain();

                    return;
                }

                Core.setToday();

                Data.checkDirectory();
                Data.loadSettings();

                ApplicationWindow = new CoreWindow();
                Windows.initializeTimer();

                Boolean normalLog = Core.checkArgs(Args);

                if (!normalLog && !Data.StartUpEnabled)
                {
                    Log.LogInTrayAborted();
                    Log.LogOut();

                    return;
                }

                #endregion

                if (Data.loadData())
                {
                    if (normalLog)
                    {
                        Log.LogIn();

                        ApplicationWindow.Start();
                        Application.Run(ApplicationWindow);
                    }
                    else
                    {
                        Log.LogInTray();

                        ApplicationWindow.Start(CoreWindow.StartParameter.InTray);
                        Application.Run(ApplicationWindow);
                    }
                }
                else
                {
                    Log.LogIn();
                    Log.FirstSettingsOpened();

                    ApplicationWindow.Start(CoreWindow.StartParameter.FirstStart);
                    Application.Run(ApplicationWindow);
                }

                Log.LogOut();
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.ToString());
                MessageBox.Show(ex.Message, Vocabulary.criticalError(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.LogOut();
            }
        }

        #region ApplicationWindow

        private static CoreWindow _ApplicationWindow;

        public static CoreWindow ApplicationWindow
        {
            get { return _ApplicationWindow; }
            set { _ApplicationWindow = value; }
        }

        #endregion
    }
}
