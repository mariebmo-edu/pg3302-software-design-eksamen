using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class MigrationWithOptCoursesAndSpecCourses_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SemesterEnum",
                table: "UserCoursePlan",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_UserCoursePlan_UserId",
                table: "UserCoursePlan",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationCourses_SpecializationId",
                table: "SpecializationCourses",
                column: "SpecializationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecializationCourses_Specializations_SpecializationId",
                table: "SpecializationCourses",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCoursePlan_Users_UserId",
                table: "UserCoursePlan",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecializationCourses_Specializations_SpecializationId",
                table: "SpecializationCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCoursePlan_Users_UserId",
                table: "UserCoursePlan");

            migrationBuilder.DropIndex(
                name: "IX_UserCoursePlan_UserId",
                table: "UserCoursePlan");

            migrationBuilder.DropIndex(
                name: "IX_SpecializationCourses_SpecializationId",
                table: "SpecializationCourses");

            migrationBuilder.AlterColumn<int>(
                name: "SemesterEnum",
                table: "UserCoursePlan",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
