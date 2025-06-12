using GoalsTracker.Data;
using GoalsTracker.Helpers;
using GoalsTracker.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace GoalsTracker.Pages
{
    public class CasesClosedModel : PageModel
    {
        private readonly AppDbContext _db;

        public CasesClosedModel(AppDbContext db)
        {
            _db = db;
        }


        public int QuarterStartMonth { get; set; } 

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; }

        public List<CaseEntry> CasesClosed { get; set; }

        public int TotalCasesClosed { get; set; }

        public int QuarterNumber { get; set; }

        public bool HasSearched { get; set; }

        public DateTime LastQuarterStartDate { get; set; }
        public DateTime LastQuarterEndDate { get; set; }

        public decimal AverageCasesClosed { get; set; }

        [BindProperty(SupportsGet = true)]
        public string QuarterOption { get; set; }


        public List<SelectListItem> Options { get; set; }

        public int EndDateQuarterNumber { get; set; }

        public void OnGet()
        {
            Options = new List<SelectListItem>
            {
                new SelectListItem { Value = "This", Text = "This Quarter" },
                new SelectListItem { Value = "Last", Text = "Last Quarter" },
                new SelectListItem { Value = "Custom", Text = "Custom Selection" }
            };

            if (QuarterOption == "Custom" && StartDate != default && EndDate != default)
            {
                QuarterNumber = DateUtilities.GetQuarterNumber(StartDate);
                EndDateQuarterNumber = DateUtilities.GetQuarterNumber(EndDate);
            }
            else if (QuarterOption == "Last")
            {
                StartDate = DateUtilities.GetQuarterStartDate(DateTime.Today.AddMonths(-3));
                EndDate = DateUtilities.GetQuarterEndDate(StartDate);
                QuarterNumber = DateUtilities.GetQuarterNumber(StartDate);
                EndDateQuarterNumber = DateUtilities.GetQuarterNumber(EndDate);
            }
            else // Default to "This"
            {
                QuarterOption = "This";
                StartDate = DateUtilities.GetQuarterStartDate(DateTime.Today);
                EndDate = DateUtilities.GetQuarterEndDate(StartDate);
                QuarterNumber = DateUtilities.GetQuarterNumber(StartDate);
                EndDateQuarterNumber = DateUtilities.GetQuarterNumber(EndDate);
            }

            CasesClosed = _db.CaseEntries
                .Where(e => e.DateClosed >= StartDate && e.DateClosed <= EndDate)
                .OrderBy(e => e.DateClosed)
                .ThenByDescending(e => e.CasesClosed)
                .ToList();

            TotalCasesClosed = CasesClosed.Sum(e => e.CasesClosed);
            AverageCasesClosed = @MathUtilities.GetAverage(TotalCasesClosed,CasesClosed.Count,2);
        }

        public void OnPost()
        {
            Options = new List<SelectListItem>
                {
                    new SelectListItem { Value = "This", Text = "This Quarter" },
                    new SelectListItem { Value = "Last", Text = "Last Quarter" },
                    new SelectListItem { Value = "Custom", Text = "Custom Selection" }
                };

            if (QuarterOption == "Last")
            {
                StartDate = DateUtilities.GetQuarterStartDate(DateTime.Today.AddMonths(-3));
                EndDate = DateUtilities.GetQuarterEndDate(StartDate);
            }
            else if (QuarterOption == "This")
            {
                StartDate = DateUtilities.GetQuarterStartDate(DateTime.Today);
                EndDate = DateUtilities.GetQuarterEndDate(StartDate);
            }
            // If "Custom", keep StartDate and EndDate from the form

            QuarterNumber = DateUtilities.GetQuarterNumber(StartDate);
            EndDateQuarterNumber = DateUtilities.GetQuarterNumber(EndDate);

            CasesClosed = _db.CaseEntries
                .Where(e => e.DateClosed >= StartDate && e.DateClosed <= EndDate)
                .OrderBy(e => e.DateClosed)
                .ThenByDescending(e => e.CasesClosed)
                .ToList();

            TotalCasesClosed = CasesClosed.Sum(e => e.CasesClosed);
            AverageCasesClosed = @MathUtilities.GetAverage(TotalCasesClosed, CasesClosed.Count, 2);
        }

        public IActionResult OnPostDelete(int id)
        {
            var entry = _db.CaseEntries.FirstOrDefault(e => e.Id == id);
            if (entry != null)
            {
                _db.CaseEntries.Remove(entry);
                _db.SaveChanges();
            }

            // Redirect and include StartDate so filter stays active
            return RedirectToPage(new { StartDate = StartDate.ToString("yyyy-MM-dd") });
        }

    }
}