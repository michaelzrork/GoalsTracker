using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GoalsTracker.Models;
using GoalsTracker.Data;

namespace GoalsTracker.Pages
{
    public class EditCaseEntryModel : PageModel
    {
        private readonly AppDbContext _db;

        public EditCaseEntryModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public CaseEntry Entry { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ReturnUrl { get; set; }

        public IActionResult OnGet(int id)
        {
            Entry = _db.CaseEntries.FirstOrDefault(e => e.Id == id);
            if (Entry == null)
            {
                return RedirectToPage("/CasesClosed");
            }

            // Keep the return URL from the query string, or fallback to referrer
            ReturnUrl ??= Request.Headers["Referer"].ToString();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existing = _db.CaseEntries.FirstOrDefault(e => e.Id == Entry.Id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.DateClosed = Entry.DateClosed;
            existing.CasesClosed = Entry.CasesClosed;
            _db.SaveChanges();

            if (!string.IsNullOrEmpty(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }

            return RedirectToPage();
        }
    }
}