using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddedHabitGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HabitCategory",
                table: "Habits");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HabitLogs",
                newName: "HabitLogId");

            migrationBuilder.AddColumn<int>(
                name: "HabitGroupId",
                table: "Habits",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HabitGroups",
                columns: table => new
                {
                    HabitGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitGroups", x => x.HabitGroupId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habits_HabitGroupId",
                table: "Habits",
                column: "HabitGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_HabitLogs_Habits_HabitId",
                table: "HabitLogs",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_HabitGroups_HabitGroupId",
                table: "Habits",
                column: "HabitGroupId",
                principalTable: "HabitGroups",
                principalColumn: "HabitGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HabitLogs_Habits_HabitId",
                table: "HabitLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Habits_HabitGroups_HabitGroupId",
                table: "Habits");

            migrationBuilder.DropTable(
                name: "HabitGroups");

            migrationBuilder.DropIndex(
                name: "IX_Habits_HabitGroupId",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "HabitGroupId",
                table: "Habits");

            migrationBuilder.RenameColumn(
                name: "HabitLogId",
                table: "HabitLogs",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "HabitCategory",
                table: "Habits",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
