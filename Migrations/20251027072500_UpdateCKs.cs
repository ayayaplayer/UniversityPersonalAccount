using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityPersonalAccount.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CKValidateEmail",
                table: "Students");

            migrationBuilder.DropCheckConstraint(
                name: "CKDayOfWeek",
                table: "Sessions");

            migrationBuilder.AddCheckConstraint(
                name: "CKValidateEmail",
                table: "Students",
                sql: " \"Email\" ~ '^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$' ");

            migrationBuilder.AddCheckConstraint(
                name: "CKClassNumber",
                table: "Sessions",
                sql: " \"ClassNumber\" > 0 AND \"ClassNumber\" < 8");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CKValidateEmail",
                table: "Students");

            migrationBuilder.DropCheckConstraint(
                name: "CKClassNumber",
                table: "Sessions");

            migrationBuilder.AddCheckConstraint(
                name: "CKValidateEmail",
                table: "Students",
                sql: " \"Email\" ~  '^.*$' ");

            migrationBuilder.AddCheckConstraint(
                name: "CKDayOfWeek",
                table: "Sessions",
                sql: " \"DayOfWeek\" > 0 AND \"DayOfWeek\" < 8");
        }
    }
}
