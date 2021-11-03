using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class DoesThisWorkYet_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CoursesInSpecializations_CourseId",
                table: "CoursesInSpecializations",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesInSpecializations_Courses_CourseId",
                table: "CoursesInSpecializations",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursesInSpecializations_Courses_CourseId",
                table: "CoursesInSpecializations");

            migrationBuilder.DropIndex(
                name: "IX_CoursesInSpecializations_CourseId",
                table: "CoursesInSpecializations");
        }
    }
}
