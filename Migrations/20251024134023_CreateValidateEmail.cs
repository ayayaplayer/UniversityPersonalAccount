using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityPersonalAccount.Migrations
{
    /// <inheritdoc />
    public partial class CreateValidateEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CKValidateEmail",
                table: "Students",
                sql: " \"Email\" ~  '^.*$' ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CKValidateEmail",
                table: "Students");
        }
    }
}
