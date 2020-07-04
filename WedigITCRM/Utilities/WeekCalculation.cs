using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Utilities
{
    public class WeekCalculation
    {

        public static int getWeekNumberBydate(DateTime dateTime)
        {
            CultureInfo danishCulture = CultureInfo.GetCultureInfo("da-DK");
            Calendar danishCalendar = danishCulture.Calendar;
            CalendarWeekRule calendarWeekRule = danishCulture.DateTimeFormat.CalendarWeekRule;
            DayOfWeek firstDayInWeek = danishCulture.DateTimeFormat.FirstDayOfWeek;

            return danishCalendar.GetWeekOfYear(dateTime, calendarWeekRule, firstDayInWeek);            
        }

        public static DateTime getDateOffFirstDayInWeek(DateTime dateTime)
        {
            CultureInfo danishCulture = CultureInfo.GetCultureInfo("da-DK");
            DayOfWeek firstDayInWeek = danishCulture.DateTimeFormat.FirstDayOfWeek;

            int diff = (7 + (dateTime.DayOfWeek - firstDayInWeek)) % 7;
            return dateTime.AddDays(-1 * diff).Date;
        }

    }
}
