// === Models/CaseEntry.cs ===
using Microsoft.AspNetCore.Mvc;

namespace GoalsTracker.Models
{
    public class CaseEntry
    {
        public int Id { get; set; }
        public DateTime DateClosed{ get; set; }
        public int CasesClosed { get; set; }

    }
}