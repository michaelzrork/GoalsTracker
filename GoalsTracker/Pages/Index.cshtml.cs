// === Pages/Index.cshtml.cs ===
using GoalsTracker.Data;
using GoalsTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoalsTracker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }
            
        [BindProperty]
        public TimeEntry NewTimeEntry { get; set; }

        [BindProperty]
        public CaseEntry NewCaseEntry { get; set; }

        public List<TimeEntry> TimeEntries { get; set; }
        public List<CaseEntry> CaseEntries { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime EntryDate { get; set; }

        public void OnGet()
        {
            TimeEntries = _db.TimeEntries.OrderByDescending(e => e.LogDate).ToList();
            CaseEntries = _db.CaseEntries.OrderByDescending(c => c.DateClosed).ToList();

            if (EntryDate != default)
            {
                
            }
            else
            {
                EntryDate = DateTime.Today; // default only if not set
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var existingEntry = _db.TimeEntries.FirstOrDefault(e => e.LogDate == EntryDate);
            if (existingEntry != null)
            {
                existingEntry.MinutesWorked += NewTimeEntry.MinutesWorked;
                _db.TimeEntries.Update(existingEntry);
            }
            else
            {
                NewTimeEntry.LogDate = EntryDate;
                _db.TimeEntries.Add(NewTimeEntry);
            }
            _db.SaveChanges();

            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            var entry = _db.TimeEntries.FirstOrDefault(e => e.Id == id);
            if (entry != null)
            {
                _db.TimeEntries.Remove(entry);
                _db.SaveChanges();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostCaseDelete(int id)
        {
            var entry = _db.CaseEntries.FirstOrDefault(e => e.Id == id);
            if (entry != null)
            {
                _db.CaseEntries.Remove(entry);
                _db.SaveChanges();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostCase()
        {
            if (!ModelState.IsValid)
                return Page();

            var existingEntry = _db.CaseEntries.FirstOrDefault(e => e.DateClosed == EntryDate);
            if (existingEntry != null)
            {
                existingEntry.CasesClosed += NewCaseEntry.CasesClosed;
                _db.CaseEntries.Update(existingEntry);
            }
            else
            {
                _db.CaseEntries.Add(NewCaseEntry);
                NewCaseEntry.DateClosed = EntryDate;
            }
            _db.SaveChanges();

            return RedirectToPage();
        }
    }
}