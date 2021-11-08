using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class DoesThisWorkYet_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CoursesInSpecializations_CoursesInSpecializationId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CoursesInSpecializationId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CoursesInSpecializationId",
                table: "Courses");

            migrationBuilder.AddColumn<long>(
                name: "CourseId",
                table: "CoursesInSpecializations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "CoursesInSpecializations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "CoursesInSpecializations");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "CoursesInSpecializations");

            migrationBuilder.AddColumn<long>(
                name: "CoursesInSpecializationId",
                table: "Courses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CoursesInSpecializationId",
                table: "Courses",
                column: "CoursesInSpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CoursesInSpecializations_CoursesInSpecializationId",
                table: "Courses",
                column: "CoursesInSpecializationId",
                principalTable: "CoursesInSpecializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
