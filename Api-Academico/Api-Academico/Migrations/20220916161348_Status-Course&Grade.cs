using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_Academico.Migrations
{
    public partial class StatusCourseGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Grades",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Courses",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Courses");
        }
    }
}
