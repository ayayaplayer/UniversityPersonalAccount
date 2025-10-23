using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityPersonalAccount.Migrations
{
    /// <inheritdoc />
    public partial class ChangeER : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Groups_GroupId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Groups_GroupId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Schedules_ScheduleId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_HalfYears_Sessions_SessionId",
                table: "HalfYears");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Schedules_ScheduleId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_HalfYears_SessionId",
                table: "HalfYears");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_GroupId",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Courses_GroupId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "HalfYears");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId",
                table: "Sessions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "HalfYearId",
                table: "Sessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId",
                table: "Groups",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Groups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "CourseGroup",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "integer", nullable: false),
                    GroupsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseGroup", x => new { x.CoursesId, x.GroupsId });
                    table.ForeignKey(
                        name: "FK_CourseGroup_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseGroup_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "integer", nullable: false),
                    StudentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_HalfYearId",
                table: "Sessions",
                column: "HalfYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_FacultyId",
                table: "Groups",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroup_GroupsId",
                table: "CourseGroup",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Faculties_FacultyId",
                table: "Groups",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Schedules_ScheduleId",
                table: "Groups",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_HalfYears_HalfYearId",
                table: "Sessions",
                column: "HalfYearId",
                principalTable: "HalfYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Schedules_ScheduleId",
                table: "Sessions",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Faculties_FacultyId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Schedules_ScheduleId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_HalfYears_HalfYearId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Schedules_ScheduleId",
                table: "Sessions");

            migrationBuilder.DropTable(
                name: "CourseGroup");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_HalfYearId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Groups_FacultyId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "HalfYearId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId",
                table: "Sessions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "HalfYears",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId",
                table: "Groups",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Faculties",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HalfYears_SessionId",
                table: "HalfYears",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_GroupId",
                table: "Faculties",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_GroupId",
                table: "Courses",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Groups_GroupId",
                table: "Courses",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Groups_GroupId",
                table: "Faculties",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Schedules_ScheduleId",
                table: "Groups",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HalfYears_Sessions_SessionId",
                table: "HalfYears",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Schedules_ScheduleId",
                table: "Sessions",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
