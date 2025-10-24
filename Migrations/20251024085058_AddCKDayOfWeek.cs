using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityPersonalAccount.Migrations
{
    /// <inheritdoc />
    public partial class AddCKDayOfWeek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Degree",
                table: "Courses",
                newName: "DegreeLevel");

            migrationBuilder.AddCheckConstraint(
                name: "CKDayOfWeek",
                table: "Sessions",
                sql: " \"DayOfWeek\" > 0 AND \"DayOfWeek\" < 8");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CKDayOfWeek",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "DegreeLevel",
                table: "Courses",
                newName: "Degree");
        }
    }
}
