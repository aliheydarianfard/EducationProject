using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Eduction.Core.Extension
{
    public static class PersianDateExtension
    {
        public static string ToPersian(this string str)
        {
            DateTime date = Convert.ToDateTime(str);
            PersianCalendar persian = new PersianCalendar();
            int year = persian.GetYear(date);
            int day = persian.GetDayOfMonth(date);
            int month = persian.GetMonth(date);

            return year + "/" + month + "/" + day;
        }
        public static string ToPersian(this DateTime date)
        {
   
            PersianCalendar persian = new PersianCalendar();
            int year = persian.GetYear(date);
            int day = persian.GetDayOfMonth(date);
            int month = persian.GetMonth(date);

            return year + "/" + month + "/" + day;
        }
        public static DateTime PersianToDateTime(this string date)
        {
            if (date.Length != 10)
            {
                throw new ArgumentException(nameof(date));
            }
            PersianCalendar persian = new PersianCalendar();
            int year = Convert.ToInt32(date.Substring(0, 4));
            var convertDate = persian.ToDateTime(year, Convert.ToInt32(date.Substring(5, 2)), Convert.ToInt32(date.Substring(8, 2)), 0, 0, 0, 0); ;

            return convertDate;
        }
    }
}
