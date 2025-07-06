using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalsTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntries_Date",
                table: "TimeEntries",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntries_DateClosed",
                table: "CaseEntries",
                column: "DateClosed",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TimeEntries_Date",
                table: "TimeEntries");

            migrationBuilder.DropIndex(
                name: "IX_CaseEntries_DateClosed",
                table: "CaseEntries");
        }
    }
}
