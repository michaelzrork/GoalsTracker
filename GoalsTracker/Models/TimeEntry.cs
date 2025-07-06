// === Models/TimeEntry.cs ===
namespace GoalsTracker.Models
{
    public class TimeEntry
    {
        public int Id { get; set; }
        public DateTime LogDate { get; set; }
        public int MinutesWorked { get; set; }
    }
}