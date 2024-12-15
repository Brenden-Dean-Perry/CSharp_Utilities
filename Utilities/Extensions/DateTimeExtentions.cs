using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class DateTimeExtentions
    {
        private static string _dateStringFormat { get; } = "MM-dd-yyyy 'T 'HH-mm-ss";

        /// <summary>
        /// Returns date as a formated string safe for inclusion in file names.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToStringFileFormat(this DateTime date)
        {
            return date.ToString(_dateStringFormat);
        }

        /// <summary>
        /// Returns bool confirming a date is weekday.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekday(this DateTime date)
        {
            return(date.DayOfWeek != DayOfWeek.Saturday & date.DayOfWeek != DayOfWeek.Sunday);
        }

        /// <summary>
        /// Returns bool confirming a date is weekend.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime date)
        {
            return (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday);
        }

        /// <summary>
        /// Returns the date of the previous weekday.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime PreviousWeekday(this DateTime date)
        {
            return date.AddWeekdays(-1);
        }

        /// <summary>
        /// Returns the date of the following weekday.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime NextWeekday(this DateTime date)
        {
            return date.AddWeekdays(1);
        }

        /// <summary>
        /// Returns a new date after adding a specified number of weekdays to a starting date.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="Days"></param>
        /// <returns></returns>
        public static DateTime AddWeekdays(this DateTime date, int count_of_weekdays_to_add)
        {
            int AbsoluteValueOfDaysToAdd = Math.Abs(count_of_weekdays_to_add);
            int DaysToAdd = count_of_weekdays_to_add / AbsoluteValueOfDaysToAdd;
            for (int i = 0; i < AbsoluteValueOfDaysToAdd; i++)
            {
                do
                {
                    date = date.AddDays(DaysToAdd);
                }
                while (date.IsWeekday() == true);
                i++;
            }
            return date;
        }
        /// <summary>
        /// Returns the date of the next day of week specified. For example, if it is Monday and you are looking for the date of Friday, the function will return Friday's date.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime NextDayOfWeekSpecified(this DateTime date, DayOfWeek day_of_week)
        {
            for(int i = 0; i < 8; i++) //8 ensure we can reach any day of the week
            {
                date = date.AddDays(1);

                if (date.DayOfWeek == day_of_week)
                {
                    return date;
                }
            }
            return default(DateTime);
        }

        /// <summary>
        /// Returns start of a month from a date.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="months_to_add"></param>
        /// <param name="is_weekday"></param>
        /// <returns></returns>
        public static DateTime StartOfMonth(this DateTime date, int months_to_add = 0, bool is_weekday = false)
        {
            date = date.AddMonths(months_to_add);
            DateTime start_of_month = new DateTime(date.Year, date.Month, day: 1);

            if(is_weekday == true && start_of_month.IsWeekday() == false)
            {
                start_of_month.AddWeekdays(1);
            }
            return start_of_month;
        }

        /// <summary>
        /// Returns start of a month from a date.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="months_to_add"></param>
        /// <param name="is_weekday"></param>
        /// <returns></returns>
        public static DateTime EndOfMonth(this DateTime date, int months_to_add = 0, bool is_weekday = false)
        {
            date = date.AddMonths(months_to_add);
            DateTime end_of_month = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));

            if(is_weekday == true && end_of_month.IsWeekday() == false)
            {
                end_of_month = end_of_month.PreviousWeekday();
            }
            return end_of_month;
        }


        /// <summary>
        /// Counts the number of weekdays to another date.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="Date"></param>
        /// <returns></returns>
        public static int CountWeekdaysToDate(this DateTime date, DateTime Date)
        {
            int day_difference = (int)Date.Subtract(date).TotalDays;
            return Enumerable
                .Range(1, day_difference)
                .Select(x => date.AddDays(x))
                .Count(x => x.IsWeekday());
        }
    }
}
