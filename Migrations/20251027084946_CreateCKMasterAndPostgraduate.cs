using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityPersonalAccount.Migrations
{
    /// <inheritdoc />
    public partial class CreateCKMasterAndPostgraduate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CKBachelor",
                table: "Courses");

            migrationBuilder.AddCheckConstraint(
                name: "CKBachelor",
                table: "Courses",
                sql: " \"DegreeLevel\" = 1 AND \"CourseName\" > 0 AND  \"CourseName\" < 5  ");

            migrationBuilder.AddCheckConstraint(
                name: "CKMaster",
                table: "Courses",
                sql: " \"DegreeLevel\" = 2 AND \"CourseName\" > 0 AND  \"CourseName\" < 3  ");

            migrationBuilder.AddCheckConstraint(
                name: "CKPostgraduate",
                table: "Courses",
                sql: " \"DegreeLevel\" = 3 AND \"CourseName\" > 0 AND  \"CourseName\" < 4  ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CKBachelor",
                table: "Courses");

            migrationBuilder.DropCheckConstraint(
                name: "CKMaster",
                table: "Courses");

            migrationBuilder.DropCheckConstraint(
                name: "CKPostgraduate",
                table: "Courses");

            migrationBuilder.AddCheckConstraint(
                name: "CKBachelor",
                table: "Courses",
                sql: " \"DegreeLevel\" = 1 AND \"CourseName\" > 0 AND  \"CourseName\" < 6  ");
        }
    }
}
