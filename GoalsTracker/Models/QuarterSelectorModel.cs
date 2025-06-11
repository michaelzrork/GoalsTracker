using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace GoalsTracker.Models
{
    public class QuarterSelectorModel
    {
        public string QuarterOption { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SelectListItem> Options { get; set; }

        // Optional if you want to customize multiple forms
        public string CustomFieldContainerId { get; set; } = "custom-fields";
    }
}
