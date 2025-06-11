namespace GoalsTracker.Helpers
{
    public class DateUtilities
    {
        public static int GetCurrentQuarter()
        {
            return ((DateTime.Today.Month - 1) / 3) + 1;
        }

        public static int GetQuarterNumber(DateTime date)
        {
            return ((date.Month - 1) / 3) + 1;
        }
        
        public static int GetQuarterStartMonth(DateTime date)
        {
            return (GetQuarterNumber(date) - 1) * 3 + 1;
        }
        
        public static DateTime GetQuarterStartDate(DateTime date)
        {
            return new DateTime(date.Year, GetQuarterStartMonth(date), 1);
        }

        public static DateTime GetQuarterEndDate(DateTime date)
        {
            return GetQuarterStartDate(date).AddMonths(3).AddDays(-1);
        }

        public static string GetLongDate(DateTime date)
        {
            return date.ToString("MMMM") + " " + date.Day + ", " + date.Year;
        }
   
    }
}