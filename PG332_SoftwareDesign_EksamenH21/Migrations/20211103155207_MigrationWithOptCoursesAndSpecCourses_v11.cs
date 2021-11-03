using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class MigrationWithOptCoursesAndSpecCourses_v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserCoursePlan_UserCoursePlanId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserCoursePlanId",
                table: "Users");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "CourseInPlans",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseInPlans_UserId",
                table: "CourseInPlans",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInPlans_Users_UserId",
                table: "CourseInPlans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInPlans_Users_UserId",
                table: "CourseInPlans");

            migrationBuilder.DropIndex(
                name: "IX_CourseInPlans_UserId",
                table: "CourseInPlans");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CourseInPlans");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCoursePlanId",
                table: "Users",
                column: "UserCoursePlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserCoursePlan_UserCoursePlanId",
                table: "Users",
                column: "UserCoursePlanId",
                principalTable: "UserCoursePlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
