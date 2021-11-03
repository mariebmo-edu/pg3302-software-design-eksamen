using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class MigrationWithOptCoursesAndSpecCourses_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "UserCoursePlan");

            migrationBuilder.AddColumn<long>(
                name: "UserCoursePlanId",
                table: "Courses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationCourses_CourseId",
                table: "SpecializationCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserCoursePlanId",
                table: "Courses",
                column: "UserCoursePlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_UserCoursePlan_UserCoursePlanId",
                table: "Courses",
                column: "UserCoursePlanId",
                principalTable: "UserCoursePlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecializationCourses_Courses_CourseId",
                table: "SpecializationCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_UserCoursePlan_UserCoursePlanId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecializationCourses_Courses_CourseId",
                table: "SpecializationCourses");

            migrationBuilder.DropIndex(
                name: "IX_SpecializationCourses_CourseId",
                table: "SpecializationCourses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_UserCoursePlanId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UserCoursePlanId",
                table: "Courses");

            migrationBuilder.AddColumn<long>(
                name: "CourseId",
                table: "UserCoursePlan",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
