using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityPersonalAccount.Migrations
{
    /// <inheritdoc />
    public partial class DeleteGroupIdFromCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
