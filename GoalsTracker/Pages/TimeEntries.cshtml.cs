using GoalsTracker.Data;
using GoalsTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoalsTracker.Pages
{
    public class TimeEntriesModel : PageModel
    {
        private readonly AppDbContext _db;

        public TimeEntriesModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public string QuarterOption { get; set; }  // e.g., "This", "Last", "Custom"

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<TimeEntry> Entries { get; set; }

        public int TotalMinutesWorked { get; set; }

        public bool HasSearched { get; set; }

        public void OnGet()
        {
            if (StartDate != default)
            {
                HasSearched = true;

                Entries = _db.TimeEntries
                    .Where(e => e.LogDate >= StartDate)
                    .OrderBy(e => e.LogDate)
                    .ThenBy(e => e.MinutesWorked)
                    .ToList();

                TotalMinutesWorked = Entries.Sum(e => e.MinutesWorked);
            }
            else
            {
                StartDate = DateTime.Today.AddDays(-7); // default only if not set
            }
        }


        public void OnPost()
        {
            HasSearched = true;

            Entries = _db.TimeEntries
                .Where(predicate: e => e.LogDate >= StartDate)
                .OrderBy(e => e.LogDate)
                .ThenBy(e => e.MinutesWorked)
                .ToList();

            TotalMinutesWorked = Entries.Sum(e => e.MinutesWorked);
        }

        public IActionResult OnPostDelete(int id)
        {
            var entry = _db.TimeEntries.FirstOrDefault(e => e.Id == id);
            if (entry != null)
            {
                _db.TimeEntries.Remove(entry);
                _db.SaveChanges();
            }

            // Redirect and include StartDate so filter stays active
            return RedirectToPage(new { StartDate = StartDate.ToString("yyyy-MM-dd") });
        }
    }
}