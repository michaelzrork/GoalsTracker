// === Models/TimeEntry.cs ===
namespace GoalsTracker.Models
{
    public class TimeEntry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int MinutesWorked { get; set; }
    }
}