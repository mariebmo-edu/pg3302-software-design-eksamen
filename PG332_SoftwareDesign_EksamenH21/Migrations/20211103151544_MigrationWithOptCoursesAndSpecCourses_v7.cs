using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class MigrationWithOptCoursesAndSpecCourses_v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecializationCourses_UserCoursePlan_UserCoursePlanId",
                table: "SpecializationCourses");

            migrationBuilder.DropIndex(
                name: "IX_SpecializationCourses_UserCoursePlanId",
                table: "SpecializationCourses");

            migrationBuilder.DropColumn(
                name: "UserCoursePlanId",
                table: "SpecializationCourses");

            migrationBuilder.AddColumn<long>(
                name: "CoursePlanCoursesId",
                table: "UserCoursePlan",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CoursePlanCourses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpecializationCoursesId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePlanCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursePlanCourses_SpecializationCourses_SpecializationCoursesId",
                        column: x => x.SpecializationCoursesId,
                        principalTable: "SpecializationCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCoursePlan_CoursePlanCoursesId",
                table: "UserCoursePlan",
                column: "CoursePlanCoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePlanCourses_SpecializationCoursesId",
                table: "CoursePlanCourses",
                column: "SpecializationCoursesId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCoursePlan_CoursePlanCourses_CoursePlanCoursesId",
                table: "UserCoursePlan",
                column: "CoursePlanCoursesId",
                principalTable: "CoursePlanCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCoursePlan_CoursePlanCourses_CoursePlanCoursesId",
                table: "UserCoursePlan");

            migrationBuilder.DropTable(
                name: "CoursePlanCourses");

            migrationBuilder.DropIndex(
                name: "IX_UserCoursePlan_CoursePlanCoursesId",
                table: "UserCoursePlan");

            migrationBuilder.DropColumn(
                name: "CoursePlanCoursesId",
                table: "UserCoursePlan");

            migrationBuilder.AddColumn<long>(
                name: "UserCoursePlanId",
                table: "SpecializationCourses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationCourses_UserCoursePlanId",
                table: "SpecializationCourses",
                column: "UserCoursePlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecializationCourses_UserCoursePlan_UserCoursePlanId",
                table: "SpecializationCourses",
                column: "UserCoursePlanId",
                principalTable: "UserCoursePlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
