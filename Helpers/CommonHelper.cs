using Carrington_Service.BusinessExpert;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public static DateTime GetFormatedDateTime(string dateTime)
        {
            try
            {
                var parsedDate = DateTime.ParseExact(dateTime, "yyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                var formattedDate = parsedDate.ToString("MM-dd-yy", System.Globalization.CultureInfo.InvariantCulture);
                return Convert.ToDateTime(formattedDate);
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// This method will be used to check if the PM account exists in Supplimental and Econcent file
        /// </summary>
        /// <param name="accountToMatch"></param>
        /// <returns></returns>
        public static bool CheckAccountExistInSupplimentalFile(string accountToMatch)
        {
            bool recordFound = false;
            try
            {

                if (WorkFlowExpert.detModels.Any(df => df.LoanNumber == accountToMatch) || WorkFlowExpert.transModels.Any(df => df.LoanNumber == accountToMatch))
                {
                    recordFound = true;
                }
            }
            catch (Exception)
            {
                recordFound = false;
            }
            return recordFound;
        }
        public static string GetFormatedDateTimeWithAmPm(DateTime dateTime)
        {
            try
            {
                string dateTimeAmPm = dateTime.ToString("MM-dd-yy HH:mm:ss").Replace("PM", "").Replace("AM", "");
                return dateTimeAmPm;
            }
            catch (Exception ex)
            {
                return Convert.ToString(DateTime.MinValue);
            }
        }
    }
}
