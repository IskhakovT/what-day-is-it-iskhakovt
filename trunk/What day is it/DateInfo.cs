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

namespace What_day_is_it
{
    public static class DateInfo
    {
        public static String getInformation(DateTime Date)
        {
            if (!Default.ImportantDateExists && !Default.AnoterBirthdayExists && !Default.YourBirthdayExists)
            {
                String shortResult = Vocabulary.noInfo() + Environment.NewLine;

                Holidays.HolidayEvent shortHolyday = Holidays.analyzeHolyday(Date);

                if (shortHolyday.Holyday != Holidays.HolidayType.None)
                {
                    shortResult += Vocabulary.HolydayText(shortHolyday) + Environment.NewLine;
                }

                if (Date.Month == monthFebruary)
                {
                    if (Date.Day > (dayMen - daysToAlert) && Date.Day < (dayMen - 1))
                    {
                        shortResult += Vocabulary.MenDay(dayMen - Date.Day) + Environment.NewLine;
                    }

                    if (Date.Day > (dayValentine - daysToAlert) && Date.Day < (dayValentine - 1))
                    {
                        shortResult += Vocabulary.Valentine(dayValentine - Date.Day) + Environment.NewLine;
                    }
                }

                if (Date.Month == monthMarch)
                {
                    if (Date.Day > (dayWomen - daysToAlert) && Date.Day < (dayWomen - 1))
                    {
                        shortResult += Vocabulary.WomenDay(dayWomen - Date.Day) + Environment.NewLine;
                    }
                }


                return shortResult;
            }

            String result = String.Empty;

            if (Default.ImportantDateExists)
            {
                result += getDateInfo(Date);

                Warning dayInfo = analyzeNum(Diff(Default.ImportantDate, Date));

                if (dayInfo != Warning.None)
                {
                    result += Vocabulary.Analize(dayInfo) + Environment.NewLine;
                }

                /*

                TimeSpan Difference = Date - Default.ImportantDate;

                Int32 hoursDiff = Difference.Hours;
                Warning hoursInfo = analyzeNum(hoursDiff);

                if (hoursInfo != Warning.None)
                {
                    result += Vocabulary.countHoursTime(hoursDiff) + Environment.NewLine + Vocabulary.Analize(hoursInfo) + Environment.NewLine;
                }

                Int32 minutesDiff = Difference.Minutes;
                Warning minutesInfo = analyzeNum(minutesDiff);

                if (minutesInfo != Warning.None)
                {
                    result += Vocabulary.countMinutesTime(minutesDiff) + Environment.NewLine + Vocabulary.Analize(minutesInfo) + Environment.NewLine;
                }

                Int32 secondsDiff = Difference.Seconds;
                Warning secondsInfo = analyzeNum(secondsDiff);

                if (secondsInfo != Warning.None)
                {
                    result += Vocabulary.countSecondsTime(secondsDiff) + Environment.NewLine + Vocabulary.Analize(secondsInfo) + Environment.NewLine;
                }
                
                */

                if (Date != Default.ImportantDate && (Date - Default.ImportantDate).Days < maxDaysInMonth)
                {
                    if (Date.Month == Default.ImportantDate.Month || (Date.Day < Default.ImportantDate.Day))
                    {
                        result += Vocabulary.LessMonth + Environment.NewLine;
                    }
                }
            }

            if (Default.AnoterBirthdayExists)
            {
                if (Diff(Date, Default.AnoterBirthday) > 0)
                {
                    result += Vocabulary.NoPartnerYet() + Environment.NewLine;
                }
                else
                {
                    DateTime toBirthday = Default.AnoterBirthday;

                    while (toBirthday.Year != Date.Year)
                    {
                        toBirthday = toBirthday.AddYears(1);
                    }

                    Int32 diff = Diff(Date, toBirthday);

                    if (diff > daysToAlertBirthday && diff < daysToAlert)
                    {
                        result += Vocabulary.Birthday(diff) + Environment.NewLine;
                    }
                }
            }

            Holidays.HolidayEvent Holyday = Holidays.analyzeHolyday(Date);

            if (Holyday.Holyday != Holidays.HolidayType.None)
            {
                result += Vocabulary.HolydayText(Holyday) + Environment.NewLine;
            }

            if (Date.Month == monthFebruary)
            {
                if (Date.Day > (dayMen - daysToAlert) && Date.Day < (dayMen - 1))
                {
                    result += Vocabulary.MenDay(dayMen - Date.Day) + Environment.NewLine;
                }

                if (Date.Day > (dayValentine - daysToAlert) && Date.Day < (dayValentine - 1))
                {
                    result += Vocabulary.Valentine(dayValentine - Date.Day) + Environment.NewLine;
                }
            }

            if (Date.Month == monthMarch)
            {
                if (Date.Day > (dayWomen - daysToAlert) && Date.Day < (dayWomen - 1))
                {
                    result += Vocabulary.WomenDay(dayWomen - Date.Day) + Environment.NewLine;
                }
            }

            if (Default.YourBirthdayExists)
            {
                if (Diff(Date, Default.YourBirthday) > 0)
                {
                    result += Vocabulary.NoYouYet() + Environment.NewLine;
                }
                else
                {
                    DateTime toBirthday = Default.YourBirthday;

                    while (toBirthday.Year != Date.Year)
                    {
                        toBirthday = toBirthday.AddYears(1);
                    }

                    Int32 diff = Diff(Date, toBirthday);

                    if (Math.Abs(diff) < daysToYourAlert)
                    {
                        result += Vocabulary.yourBirthday(diff) + Environment.NewLine;
                    }
                }
            }

            return result;
        }

        private static String getDateInfo(DateTime Date)
        {
            if (!Default.ImportantDateExists)
            {
                throw new Exception("getDateInfo was called, but ImportantDate doesn't exist");
            }

            String result = String.Empty;

            Int32 days = Diff(Default.ImportantDate, Date);

            if (days == 0)
            {
                return Vocabulary.Appears() + Environment.NewLine;
            }
            else if (days < 0)
            {
                return Vocabulary.noPartner() + Environment.NewLine;
            }

            result += Vocabulary.countDaysTime(days) + Environment.NewLine;

            if (days < daysEnough)
            {
                return result;
            }

            if (Date.Day == Default.ImportantDate.Day)
            {
                Int32 yearDiff = Date.Year - Default.ImportantDate.Year;

                if (Date.Month == Default.ImportantDate.Month)
                {
                    result += Vocabulary.exactYears(yearDiff) + Environment.NewLine;
                }
                else
                {
                    Int32 monthDiff = (Date.Month - Default.ImportantDate.Month) + yearDiff * monthInYear;
                    result += Vocabulary.exactMonth(monthDiff) + Environment.NewLine;
                }
            }

            return result;
        }

        public static Int32 Diff(DateTime First, DateTime Second)
        {
            return (Second - First).Days;
        }

        public enum Warning { DivTenThousand, DivThousand, DivHundred, EqualSymbols, Symmetric, EqualDiff, None };

        public static Warning analyzeNum(Int32 num)
        {
            if (!Default.ImportantDateExists || num < daysEnough)
            {
                return Warning.None;
            }

            if (num % hundred == 0)
            {
                if (num % thousand == 0)
                {
                    if (num % tenThousand == 0)
                    {
                        return Warning.DivTenThousand;
                    }

                    return Warning.DivThousand;
                }

                return Warning.DivHundred;
            }

            String str = num.ToString();
            Int32 Length = str.Length;

            Boolean equal = true;
            for (Int32 i = 1; i < Length && equal; ++i)
            {
                if (str[i] != str[i - 1])
                {
                    equal = false;
                }
            }

            if (equal)
            {
                return Warning.EqualSymbols;
            }

            Boolean sym = true;
            for (Int32 i = 0; i < Length / 2 && sym; ++i)
            {
                if (str[i] != str[Length - i - 1])
                {
                    sym = false;
                }
            }

            if (sym)
            {
                return Warning.Symmetric;
            }

            if (str.Length > 2)
            {
                Boolean equalDiff = true;
                Int32 diff = str[1] - str[0];

                for (Int32 i = 2; i < Length && equalDiff; ++i)
                {
                    if (str[i] - str[i - 1] != diff)
                    {
                        equalDiff = false;
                    }
                }

                if (equalDiff)
                {
                    return Warning.EqualDiff;
                }
            }

            return Warning.None;
        }

        public static Int32 monthFebruary = 2;
        public static Int32 monthMarch = 3;
        public static Int32 dayValentine = 14;
        public static Int32 dayMen = 23;
        public static Int32 dayWomen = 8;
        public static Int32 daysToAlert = 6;
        public static Int32 daysToAlertBirthday = -2;
        public static Int32 daysToYourAlert = 2;
        public static Int32 maxDaysInMonth = 31;
        public static Int32 daysEnough = 11;
        public static Int32 monthInYear = 12;

        public static Int32 hundred = 100;
        public static Int32 thousand = 1000;
        public static Int32 tenThousand = 1000;
    }
}
