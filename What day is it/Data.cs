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
    static class Data
    {
        #region Paths

        private static String AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static String CommonFolder = AppData + "/iskhakovt/What day is it/";

        private static String SettingsFile = CommonFolder + "settings";
        private static String DataFile = CommonFolder + "data";
        private static String _LogFile = CommonFolder + "log";

        public static String LogFile
        {
            get { return _LogFile; }
        }

        #endregion

        #region Data

        private static Boolean _ImportantDateExists;
        private static Boolean _AnoterBirthdayExists;
        private static Boolean _YourBirthdayExists;

        public static Boolean ImportantDateExists
        {
            get { return _ImportantDateExists; }
        }

        public static Boolean AnoterBirthdayExists
        {
            get { return _AnoterBirthdayExists; }
        }

        public static Boolean YourBirthdayExists
        {
            get { return _YourBirthdayExists; }
        }

        private static DateTime _ImportantDate;
        private static DateTime _AnoterBirthday;
        private static DateTime _YourBirthday;

        public static DateTime ImportantDate
        {
            get { return _ImportantDate; }
        }

        public static DateTime AnoterBirthday
        {
            get { return _AnoterBirthday; }
        }

        public static DateTime YourBirthday
        {
            get { return _YourBirthday; }
        }

        private static Boolean _Sex;

        public static Boolean Sex
        {
            get { return _Sex; }
        }

        #endregion

        #region Settings

        private static Boolean _ShowNotifications;
        private static Boolean _StartUpEnabled;

        public static Boolean ShowNotifications
        {
            get { return _ShowNotifications; }
        }

        public static Boolean StartUpEnabled
        {
            get { return _StartUpEnabled; }
        }

        #endregion

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

        #region Settings IO

        public static void loadSettings()
        {
            if (File.Exists(SettingsFile))
            {
                try
                {
                    StreamReader readData = new StreamReader(SettingsFile);

                    String notifications = readData.ReadLine();

                    if (notifications == NotificationsOn)
                    {
                        _ShowNotifications = true;
                    }
                    else if (notifications == NotificationsOff)
                    {
                        _ShowNotifications = false;
                    }
                    else
                    {
                        readData.Close();
                        throw new Exception(LogResources.FileNotificationsError + notifications);
                    }

                    String startUp = readData.ReadLine();

                    if (startUp == StartUpOn)
                    {
                        _StartUpEnabled = true;
                    }
                    else if (startUp == StartUpOff)
                    {
                        _StartUpEnabled = false;
                    }
                    else
                    {
                        readData.Close();
                        throw new Exception(LogResources.FileStartUpError + startUp);
                    }

                    readData.Close();
                }
                catch (Exception ex)
                {
                    Log.errorIO(ex.Message);

                    resetSettings();
                }
            }
            else
            {
                Log.SettingsFileNotFound();

                resetSettings();
            }
        }

        public static void saveSettings()
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

        private static void resetSettings()
        {
            _ShowNotifications = true;
            _StartUpEnabled = true;

            saveSettings();
        }

        public static void invertNotifications()
        {
            _ShowNotifications = !_ShowNotifications;
            saveSettings();
        }

        public static void invertStartUp()
        {
            _StartUpEnabled = !_StartUpEnabled;
            saveSettings();
        }

        #endregion

        #region Data IO

        private class InDate
        {
            private Boolean _Exists;
            private DateTime _Date;

            public InDate()
            {
                _Exists = false;
                _Date = Core.Today;
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

        public static Boolean loadData()
        {
            if (File.Exists(DataFile))
            {
                try
                {
                    StreamReader readData = new StreamReader(DataFile);

                    String sex = readData.ReadLine();

                    if (sex == BoyString)
                    {
                        _Sex = true;
                    }
                    else if (sex == GirtString)
                    {
                        _Sex = false;
                    }
                    else
                    {
                        readData.Close();
                        throw new Exception(LogResources.FileSexError + sex);
                    }

                    InDate GetDate;

                    GetDate = getDate(readData);
                    _ImportantDateExists = GetDate.Exists;
                    _ImportantDate = GetDate.Date;

                    GetDate = getDate(readData);
                    _AnoterBirthdayExists = GetDate.Exists;
                    _AnoterBirthday = GetDate.Date;

                    GetDate = getDate(readData);
                    _YourBirthdayExists = GetDate.Exists;
                    _YourBirthday = GetDate.Date;

                    readData.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    Log.errorIO(ex.Message);

                    File.Delete(DataFile);
                    return false;
                }
            }
            else
            {
                Log.DataFileNotFound();

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

                if (year < minYear || year > maxYear)
                {
                    readData.Close();
                    throw new Exception(LogResources.FileYearError + year.ToString());
                }

                Int32 month = Convert.ToInt32(readData.ReadLine());
                Int32 day = Convert.ToInt32(readData.ReadLine());

                DateTime input = new DateTime(year, month, day);

                if ((Core.Today - input).Days < 0)
                {
                    readData.Close();
                    throw new Exception(LogResources.FileDateError);
                }

                return new InDate(input);
            }
            else
            {
                readData.Close();
                throw new Exception(LogResources.FileExistsError + exists);
            }
        }

        public static void saveData(StringCollection toWrite)
        {
            File.Create(DataFile).Close();
            StreamWriter writeData = new StreamWriter(Data.DataFile);

            for (Int32 i = 0; i < toWrite.Count; ++i)
            {
                writeData.WriteLine(toWrite[i]);
            }

            writeData.Close();
            loadData();
        }

        #endregion

        #region Common constants

        private static String NotificationsOn =     "NOTIFICATIONS ON";
        private static String NotificationsOff =    "NOTIFICATIONS OFF";
        private static String StartUpOn =           "STARTUP ON";
        private static String StartUpOff =          "STARTUP OFF";

        private static String _BoyString =          "BOY";
        private static String _GirtString =         "GIRL";
        private static String _TrueString =         "TRUE";
        private static String _FalseString =        "FALSE";

        public static String BoyString
        {
            get { return _BoyString; }
        }

        public static String GirtString
        {
            get { return _GirtString; }
        }

        public static String TrueString
        {
            get { return _TrueString; }
        }

        public static String FalseString
        {
            get { return _FalseString; }
        }

        private static Int32 minYear = 1900;
        private static Int32 maxYear = 2199;

        #endregion
    }
}
