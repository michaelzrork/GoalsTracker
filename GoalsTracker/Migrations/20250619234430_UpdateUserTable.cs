using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalsTracker.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "TimeEntries",
                newName: "LogDate");

            migrationBuilder.RenameIndex(
                name: "IX_TimeEntries_Date",
                table: "TimeEntries",
                newName: "IX_TimeEntries_LogDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LogDate",
                table: "TimeEntries",
                newName: "Date");

            migrationBuilder.RenameIndex(
                name: "IX_TimeEntries_LogDate",
                table: "TimeEntries",
                newName: "IX_TimeEntries_Date");
        }
    }
}
