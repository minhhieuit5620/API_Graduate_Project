using System;

namespace ISCommon.Utility
{
    public static class ISDatetime
    {
        public static DateTime? ConvertTimeZone(DateTime time, string timeZoneId)
        {
            TimeZoneInfo est;
            try
            {
                est = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            }
            catch (TimeZoneNotFoundException)
            {
               // Console.WriteLine("Unable to retrieve the Eastern Standard time zone.");
                return null;
            }
            catch (InvalidTimeZoneException)
            {
                // Console.WriteLine("Unable to retrieve the Eastern Standard time zone.");
                return null;
            }
            return TimeZoneInfo.ConvertTime(time, est);
        }

        public static DateTime? ConvertTimeZone(DateTime time, string sourceTimeZoneId, string destinationTimeZoneId)
        {
            TimeZoneInfo sourceTimeZone;
            TimeZoneInfo destinationTimeZone;
            try
            {
                sourceTimeZone = TimeZoneInfo.FindSystemTimeZoneById(sourceTimeZoneId);
                destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(destinationTimeZoneId);
            }
            catch (TimeZoneNotFoundException)
            {
                // Console.WriteLine("Unable to retrieve the Eastern Standard time zone.");
                return null;
            }
            catch (InvalidTimeZoneException)
            {
                // Console.WriteLine("Unable to retrieve the Eastern Standard time zone.");
                return null;
            }
            return TimeZoneInfo.ConvertTime(time, sourceTimeZone, destinationTimeZone);
        }
    
        public static string ConvertDateTimeToDayOfWeekJapanese(DateTime? dt)
        {
            var result = "";
            if (dt == null)
                return result;
            if (Convert.ToDateTime(dt).DayOfWeek == DayOfWeek.Sunday)
                result = "日";
            else if (Convert.ToDateTime(dt).DayOfWeek == DayOfWeek.Monday)
                result = "月";
            else if (Convert.ToDateTime(dt).DayOfWeek == DayOfWeek.Tuesday)
                result = "火";
            else if (Convert.ToDateTime(dt).DayOfWeek == DayOfWeek.Wednesday)
                result = "水";
            else if (Convert.ToDateTime(dt).DayOfWeek == DayOfWeek.Thursday)
                result = "木";
            else if (Convert.ToDateTime(dt).DayOfWeek == DayOfWeek.Friday)
                result = "金";
            else
                result = "土";
            return result;
        }
    }
}
