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
using System.Collections.Specialized;

namespace What_day_is_it
{
    static class Default
    {
        private static String AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static String CommonFolder = AppData + "/iskhakovt/What day is it/";

        public static String SettingsFile = CommonFolder + "settings";
        public static String DataFile = CommonFolder + "data";
        public static String LogFile = CommonFolder + "log";

        public static DateTime Today = DateTime.Today;

        public static Boolean ImportantDateExists;
        public static Boolean AnoterBirthdayExists;
        public static Boolean YourBirthdayExists;

        public static DateTime ImportantDate;
        public static DateTime AnoterBirthday;
        public static DateTime YourBirthday;

        public static Boolean Sex;

        public static Boolean FirstStart = false;

        public static Boolean ShowNotifications;
        public static Boolean StartUpEnabled;

        public static void checkDirectory()
        {
            if (!Directory.Exists(AppData))
            {
                Directory.CreateDirectory(AppData);
            }

            if (!Directory.Exists(CommonFolder))
            {
                Directory.CreateDirectory(CommonFolder);
            }
        }

        public static void LoadSettings()
        {
            if (File.Exists(SettingsFile))
            {
                try
                {
                    StreamReader readData = new StreamReader(SettingsFile);

                    String notifications = readData.ReadLine();

                    if (notifications == NotificationsOn)
                    {
                        ShowNotifications = true;
                    }
                    else if (notifications == NotificationsOff)
                    {
                        ShowNotifications = false;
                    }
                    else
                    {
                        readData.Close();
                        throw new Exception("Bad input in settings file (notifications): " + notifications);
                    }

                    String startUp = readData.ReadLine();

                    if (startUp == StartUpOn)
                    {
                        StartUpEnabled = true;
                    }
                    else if (startUp == StartUpOff)
                    {
                        StartUpEnabled = false;
                    }
                    else
                    {
                        readData.Close();
                        throw new Exception("Bad input in settings file (startUp): " + startUp);
                    }

                    readData.Close();
                }
                catch (Exception ex)
                {
                    Log.WriteLog(ex.ToString());

                    ShowNotifications = true;
                    StartUpEnabled = true;

                    SaveSettings();
                }
            }
            else
            {
                ShowNotifications = true;
                StartUpEnabled = true;

                SaveSettings();
            }
        }

        public static void SaveSettings()
        {
            StreamWriter writeData = new StreamWriter(SettingsFile);

            if (ShowNotifications)
            {
                writeData.WriteLine(NotificationsOn);
            }
            else
            {
                writeData.WriteLine(NotificationsOff);
            }

            if (StartUpEnabled)
            {
                writeData.WriteLine(StartUpOn);
            }
            else
            {
                writeData.WriteLine(StartUpOff);
            }

            writeData.Close();
        }

        private class InDate
        {
            private Boolean _Exists;
            private DateTime _Date;

            public InDate()
            {
                _Exists = false;
                _Date = Today;
            }

            public InDate(DateTime Date)
            {
                _Exists = true;
                _Date = Date;
            }

            public Boolean Exists
            {
                get { return _Exists; }
            }

            public DateTime Date
            {
                get { return _Date; }
            }
        }

        public static Boolean checkFile()
        {
            if (File.Exists(DataFile))
            {
                try
                {
                    StreamReader readData = new StreamReader(DataFile);

                    String sex = readData.ReadLine();

                    if (sex == BoyString)
                    {
                        Sex = true;
                    }
                    else if (sex == GirtString)
                    {
                        Sex = false;
                    }
                    else
                    {
                        readData.Close();
                        throw new Exception("Bad input in data file (sex): " + sex);
                    }

                    InDate GetDate;

                    GetDate = getDate(readData);
                    ImportantDateExists = GetDate.Exists;
                    ImportantDate = GetDate.Date;

                    GetDate = getDate(readData);
                    AnoterBirthdayExists = GetDate.Exists;
                    AnoterBirthday = GetDate.Date;

                    GetDate = getDate(readData);
                    YourBirthdayExists = GetDate.Exists;
                    YourBirthday = GetDate.Date;

                    readData.Close();

                    FirstStart = false;
                    return true;
                }
                catch (Exception ex)
                {
                    Log.WriteLog(ex.ToString());

                    File.Delete(DataFile);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private static InDate getDate(StreamReader readData)
        {
            String exists = readData.ReadLine();

            if (exists == FalseString)
            {
                return new InDate();
            }
            else if (exists == TrueString)
            {
                Int32 year = Convert.ToInt32(readData.ReadLine());

                if (year < 1900 || year > 2199)
                {
                    readData.Close();
                    throw new Exception("Bad input in data file: bad input year " + year.ToString());
                }

                Int32 month = Convert.ToInt32(readData.ReadLine());
                Int32 day = Convert.ToInt32(readData.ReadLine());

                DateTime input = new DateTime(year, month, day);

                if ((Default.Today - input).Days < 0)
                {
                    readData.Close();
                    throw new Exception("Bad input in data file: input date is after today");
                }

                return new InDate(input);
            }
            else
            {
                readData.Close();
                throw new Exception("Bad input in data file (exists): " + exists);
            }
        }

        public static void WriteSettings(StringCollection toWrite)
        {
            File.Create(DataFile).Close();
            StreamWriter writeData = new StreamWriter(Default.DataFile);

            for (Int32 i = 0; i < toWrite.Count; ++i)
            {
                writeData.WriteLine(toWrite[i]);
            }

            writeData.Close();
            checkFile();
        }

        public static void checkDate()
        {
            if (Default.Today.Year > maxYear)
            {
                throw new Exception("Today is too big date");
            }
        }

        private static String NotificationsOn =     "NOTIFICATIONS ON";
        private static String NotificationsOff =    "NOTIFICATIONS OFF";
        private static String StartUpOn =           "STARTUP ON";
        private static String StartUpOff =          "STARTUP OFF";

        public static String BoyString =            "BOY";
        public static String GirtString =           "GIRL";
        public static String TrueString =           "TRUE";
        public static String FalseString =          "FALSE";

        public static String BadArgs = "Bad arguments:\n";
        public static String StartTray = "startup";

        private static Int32 maxYear = 2199;
    }
}
