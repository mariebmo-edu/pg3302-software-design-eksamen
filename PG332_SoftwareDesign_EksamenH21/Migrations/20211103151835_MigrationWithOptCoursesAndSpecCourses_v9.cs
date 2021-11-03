using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class MigrationWithOptCoursesAndSpecCourses_v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCoursePlan_Users_UserId",
                table: "UserCoursePlan");

            migrationBuilder.DropIndex(
                name: "IX_UserCoursePlan_UserId",
                table: "UserCoursePlan");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserCoursePlan");

            migrationBuilder.AddColumn<long>(
                name: "UserCoursePlanId",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserCoursePlan_UserCoursePlanId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserCoursePlanId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserCoursePlanId",
                table: "Users");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "UserCoursePlan",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_UserCoursePlan_UserId",
                table: "UserCoursePlan",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCoursePlan_Users_UserId",
                table: "UserCoursePlan",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
