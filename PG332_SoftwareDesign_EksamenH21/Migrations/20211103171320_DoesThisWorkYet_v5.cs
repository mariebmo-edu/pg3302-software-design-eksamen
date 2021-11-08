using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class DoesThisWorkYet_v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_StudentCourseOverviews_StudentCourseOverviewId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StudentCourseOverviewId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentCourseOverviewId",
                table: "Courses");

            migrationBuilder.AddColumn<long>(
                name: "CourseId",
                table: "StudentCourseOverviews",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseOverviews_CourseId",
                table: "StudentCourseOverviews",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseOverviews_Courses_CourseId",
                table: "StudentCourseOverviews",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseOverviews_Courses_CourseId",
                table: "StudentCourseOverviews");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseOverviews_CourseId",
                table: "StudentCourseOverviews");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "StudentCourseOverviews");

            migrationBuilder.AddColumn<long>(
                name: "StudentCourseOverviewId",
                table: "Courses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentCourseOverviewId",
                table: "Courses",
                column: "StudentCourseOverviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_StudentCourseOverviews_StudentCourseOverviewId",
                table: "Courses",
                column: "StudentCourseOverviewId",
                principalTable: "StudentCourseOverviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
