using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityPersonalAccount.Migrations
{
    /// <inheritdoc />
    public partial class CreateValidateDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CKValidateDate",
                table: "HalfYears",
                sql: " \"DateEnd\" >  \"DateStart\"");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CKValidateDate",
                table: "HalfYears");
        }
    }
}
