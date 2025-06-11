namespace GoalsTracker.Helpers
{
    public static class FormatUtilities
    {
        public static string GetHoursAndMinutes(int totalMinutes)
        {
            int hours = totalMinutes / 60;
            int minutes = totalMinutes % 60;

            string hourLabel = hours == 1 ? "hour" : "hours";
            string minuteLabel = minutes == 1 ? "minute" : "minutes";

            return $"{hours} {hourLabel} and {minutes} {minuteLabel}";
        }
    }
}