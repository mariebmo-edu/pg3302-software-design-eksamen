using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class DoesThisWorkYet_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseInPlans_StudentCourseOverviewId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_CourseInPlans_StudentCourseOverviewId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseInPlans",
                table: "CourseInPlans");

            migrationBuilder.RenameTable(
                name: "CourseInPlans",
                newName: "StudentCourseOverviews");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourseOverviews",
                table: "StudentCourseOverviews",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_StudentCourseOverviews_StudentCourseOverviewId",
                table: "Courses",
                column: "StudentCourseOverviewId",
                principalTable: "StudentCourseOverviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StudentCourseOverviews_StudentCourseOverviewId",
                table: "Users",
                column: "StudentCourseOverviewId",
                principalTable: "StudentCourseOverviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_StudentCourseOverviews_StudentCourseOverviewId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_StudentCourseOverviews_StudentCourseOverviewId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourseOverviews",
                table: "StudentCourseOverviews");

            migrationBuilder.RenameTable(
                name: "StudentCourseOverviews",
                newName: "CourseInPlans");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseInPlans",
                table: "CourseInPlans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseInPlans_StudentCourseOverviewId",
                table: "Courses",
                column: "StudentCourseOverviewId",
                principalTable: "CourseInPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CourseInPlans_StudentCourseOverviewId",
                table: "Users",
                column: "StudentCourseOverviewId",
                principalTable: "CourseInPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
