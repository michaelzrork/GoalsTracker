namespace GoalsTracker.Helpers
{
    public class MathUtilities
    {
        public static decimal GetAverage(decimal totalcount, decimal dayscount, int digits)
        {
            if (totalcount == 0)
            {
                return 0;
            }
            else
            {
                return Math.Round(totalcount / dayscount, digits);
            }
        }
        
    }
}
