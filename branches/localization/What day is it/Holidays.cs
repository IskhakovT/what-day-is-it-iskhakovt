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

namespace What_day_is_it
{
    static class Holidays
    {
        public enum HolidayType { NewYear, ValentineDay, MenDay, WomenDay, FirstOfMay, DayOfVictory, DayOfRussia, NationalUnity, None };

        public class HolidayEvent
        {
            private HolidayType _Holiday;
            private Boolean _Today;

            public HolidayEvent(HolidayType Holiday, Boolean Today)
            {
                _Holiday = Holiday;
                _Today = Today;
            }

            public HolidayType Holiday
            {
                get { return _Holiday; }
            }

            public Boolean Today
            {
                get { return _Today; }
            }
        }

        public static HolidayEvent findHoliday(DateTime Date)
        {
            Int32 month = Date.Month;
            Int32 day = Date.Day;

            if (month == 1)
            {
                if (day == 1)
                {
                    return new HolidayEvent(HolidayType.NewYear, true);
                }
            }

            if (month == 2)
            {
                if (day == 13)
                {
                    return new HolidayEvent(HolidayType.ValentineDay, false);
                }

                if (day == 14)
                {
                    return new HolidayEvent(HolidayType.ValentineDay, true);
                }

                if (day == 22)
                {
                    return new HolidayEvent(HolidayType.MenDay, false);
                }

                if (day == 23)
                {
                    return new HolidayEvent(HolidayType.MenDay, true);
                }
            }

            if (month == 3)
            {
                if (day == 7)
                {
                    return new HolidayEvent(HolidayType.WomenDay, false);
                }

                if (day == 8)
                {
                    return new HolidayEvent(HolidayType.WomenDay, true); 
                }
            }

            if (month == 4)
            {
                if (day == 30)
                {
                    return new HolidayEvent(HolidayType.FirstOfMay, false); 
                }
            }

            if (month == 5)
            {
                if (day == 1)
                {
                    return new HolidayEvent(HolidayType.FirstOfMay, true); 
                }

                if (day == 8)
                {
                    return new HolidayEvent(HolidayType.DayOfVictory, false); 
                }

                if (day == 9)
                {
                    return new HolidayEvent(HolidayType.DayOfVictory, true); 
                }
            }

            if (month == 6)
            {
                if (day == 11)
                {
                    return new HolidayEvent(HolidayType.DayOfRussia, false); 
                }

                if (day == 12)
                {
                    return new HolidayEvent(HolidayType.DayOfRussia, true); 
                }
            }

            if (month == 11)
            {
                if (day == 3)
                {
                    return new HolidayEvent(HolidayType.NationalUnity, false); 
                }

                if (day == 4)
                {
                    return new HolidayEvent(HolidayType.NationalUnity, true); 
                }
            }

            if (month == 12)
            {
                if (day == 31)
                {
                    return new HolidayEvent(HolidayType.NewYear, false);
                }
            }

            return new HolidayEvent(HolidayType.None, false);
        }
    }
}
