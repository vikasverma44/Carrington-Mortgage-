using System;
using System.Text.RegularExpressions;

namespace CarringtonMortgage.Helpers
{
    public static class CommonHelper
    {
        public static string IncludeCenturyDate(this DateTime sourceDate, bool replace)
        {
            var source = String.Format("{0}/{1}", sourceDate.Year / 100 + 1, sourceDate);
            if (replace)
                return Regex.Replace(source, "[^0-9]", "");
            else
                return source;
        }

        /// <summary>
        /// This method is used to convert string date time to formated date time.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static  DateTime GetFormatedDateTime(string dateTime)
        {
            try
            {
                var parsedDate = DateTime.ParseExact(dateTime, "yyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                var formattedDate = parsedDate.ToString("MM-dd-yy", System.Globalization.CultureInfo.InvariantCulture);
                return Convert.ToDateTime(formattedDate);
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }
    }
}
