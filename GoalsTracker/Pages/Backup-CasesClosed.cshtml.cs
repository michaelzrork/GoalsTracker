using GoalsTracker.Data;
using GoalsTracker.Helpers;
using GoalsTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GoalsTracker.Pages
{
    public class CasesClosedModel : PageModel
    {
        private readonly AppDbContext _db;

        public CasesClosedModel(AppDbContext db)
        {
            _db = db;
        }

        public List<CaseEntry> CasesClosed { get; set; } = new();
        public int TotalCasesClosed { get; set; }
        public decimal AverageCasesClosed { get; set; }
        public int QuarterNumber { get; set; }
        public int EndDateQuarterNumber { get; set; }

        [BindProperty(SupportsGet = true)]
        public QuarterSelectorModel QuarterSelector { get; set; }

        public void OnGet()
        {
            InitializeOptions();

            ApplyQuarterSelection();

            LoadCaseData();
        }

        public void OnPost()
        {
            InitializeOptions();

            ApplyQuarterSelection();

            LoadCaseData();
        }

        public IActionResult OnPostDelete(int id)
        {
            var entry = _db.CaseEntries.FirstOrDefault(e => e.Id == id);
            if (entry != null)
            {
                _db.CaseEntries.Remove(entry);
                _db.SaveChanges();
            }

            return RedirectToPage(new
            {
                QuarterSelector.QuarterOption,
                StartDate = QuarterSelector.StartDate.ToString("yyyy-MM-dd"),
                EndDate = QuarterSelector.EndDate.ToString("yyyy-MM-dd")
            });
        }

        private void InitializeOptions()
        {
            QuarterSelector ??= new QuarterSelectorModel();
            QuarterSelector.Options = new List<SelectListItem>
            {
                new SelectListItem { Value = "This", Text = "This Quarter" },
                new SelectListItem { Value = "Last", Text = "Last Quarter" },
                new SelectListItem { Value = "Custom", Text = "Custom Selection" }
            };

            if (string.IsNullOrEmpty(QuarterSelector.QuarterOption))
                QuarterSelector.QuarterOption = "This";
        }

        private void ApplyQuarterSelection()
        {
            if (QuarterSelector.QuarterOption == "Last")
            {
                QuarterSelector.StartDate = DateUtilities.GetQuarterStartDate(DateTime.Today.AddMonths(-3));
                QuarterSelector.EndDate = DateUtilities.GetQuarterEndDate(QuarterSelector.StartDate);
            }
            else if (QuarterSelector.QuarterOption == "This")
            {
                QuarterSelector.StartDate = DateUtilities.GetQuarterStartDate(DateTime.Today);
                QuarterSelector.EndDate = DateUtilities.GetQuarterEndDate(QuarterSelector.StartDate);
            }
            // "Custom" will use the values bound by the form

            QuarterNumber = DateUtilities.GetQuarterNumber(QuarterSelector.StartDate);
            EndDateQuarterNumber = DateUtilities.GetQuarterNumber(QuarterSelector.EndDate);
        }

        private void LoadCaseData()
        {
            CasesClosed = _db.CaseEntries
                .Where(e => e.DateClosed >= QuarterSelector.StartDate && e.DateClosed <= QuarterSelector.EndDate)
                .OrderBy(e => e.DateClosed)
                .ThenByDescending(e => e.CasesClosed)
                .ToList();

            TotalCasesClosed = CasesClosed.Sum(e => e.CasesClosed);
            AverageCasesClosed = TotalCasesClosed > 0
                ? (decimal)TotalCasesClosed / CasesClosed.Count
                : 0;
        }
    }
}
