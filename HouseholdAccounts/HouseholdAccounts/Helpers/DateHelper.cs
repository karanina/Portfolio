using System.Globalization;

namespace HouseholdAccounts.Helpers
{
    public static class DateHelper
    {
        public static string GetDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static DateTime SetDate(string date)
        {
            return DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public static bool TryDateParse(string date)
        {
           return DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);
        }
    }
}
