using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitTracker.Migrations
{
    /// <inheritdoc />
    public partial class Addeduniqueindexinthelog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HabitLogs_HabitId_LogDate",
                table: "HabitLogs",
                columns: new[] { "HabitId", "LogDate" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HabitLogs_HabitId_LogDate",
                table: "HabitLogs");
        }
    }
}
