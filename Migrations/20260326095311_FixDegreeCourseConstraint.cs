using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityPersonalAccount.Migrations
{
    /// <inheritdoc />
    public partial class FixDegreeCourseConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CKDegreeCourseValid",
                table: "Courses");

            migrationBuilder.AddCheckConstraint(
                name: "CKDegreeCourseValid",
                table: "Courses",
                sql: "\r\n        (\"DegreeLevel\" = 1 AND \"CourseName\" > 0 AND \"CourseName\" < 5)\r\n        OR\r\n        (\"DegreeLevel\" = 2 AND \"CourseName\" > 0 AND \"CourseName\" < 3)\r\n        OR\r\n        (\"DegreeLevel\" = 3 AND \"CourseName\" > 0 AND \"CourseName\" < 5)\r\n    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CKDegreeCourseValid",
                table: "Courses");

            migrationBuilder.AddCheckConstraint(
                name: "CKDegreeCourseValid",
                table: "Courses",
                sql: "\r\n        (\"DegreeLevel\" = 1 AND \"CourseName\" > 0 AND \"CourseName\" < 5)\r\n        OR\r\n        (\"DegreeLevel\" = 2 AND \"CourseName\" > 0 AND \"CourseName\" < 3)\r\n        OR\r\n        (\"DegreeLevel\" = 3 AND \"CourseName\" > 0 AND \"CourseName\" < 4)\r\n    ");
        }
    }
}
