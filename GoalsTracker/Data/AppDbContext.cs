using GoalsTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace GoalsTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TimeEntry> TimeEntries { get; set; }
        public DbSet<CaseEntry> CaseEntries { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeEntry>()
                .HasIndex(e => e.LogDate)
                .IsUnique();

            modelBuilder.Entity<CaseEntry>()
                .HasIndex(e => e.DateClosed)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}