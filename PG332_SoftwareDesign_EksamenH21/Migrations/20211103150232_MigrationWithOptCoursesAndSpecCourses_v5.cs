using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class MigrationWithOptCoursesAndSpecCourses_v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Semesters_SemesterId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_UserCoursePlan_UserCoursePlanId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Semesters_Specializations_SpecializationId",
                table: "Semesters");

            migrationBuilder.DropIndex(
                name: "IX_Courses_UserCoursePlanId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters");

            migrationBuilder.DropColumn(
                name: "UserCoursePlanId",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Semesters",
                newName: "Semester");

            migrationBuilder.RenameIndex(
                name: "IX_Semesters_SpecializationId",
                table: "Semester",
                newName: "IX_Semester_SpecializationId");

            migrationBuilder.AddColumn<long>(
                name: "UserCoursePlanId",
                table: "SpecializationCourses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semester",
                table: "Semester",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationCourses_UserCoursePlanId",
                table: "SpecializationCourses",
                column: "UserCoursePlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Semester_SemesterId",
                table: "Courses",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Semester_Specializations_SpecializationId",
                table: "Semester",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecializationCourses_UserCoursePlan_UserCoursePlanId",
                table: "SpecializationCourses",
                column: "UserCoursePlanId",
                principalTable: "UserCoursePlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Semester_SemesterId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Semester_Specializations_SpecializationId",
                table: "Semester");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecializationCourses_UserCoursePlan_UserCoursePlanId",
                table: "SpecializationCourses");

            migrationBuilder.DropIndex(
                name: "IX_SpecializationCourses_UserCoursePlanId",
                table: "SpecializationCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semester",
                table: "Semester");

            migrationBuilder.DropColumn(
                name: "UserCoursePlanId",
                table: "SpecializationCourses");

            migrationBuilder.RenameTable(
                name: "Semester",
                newName: "Semesters");

            migrationBuilder.RenameIndex(
                name: "IX_Semester_SpecializationId",
                table: "Semesters",
                newName: "IX_Semesters_SpecializationId");

            migrationBuilder.AddColumn<long>(
                name: "UserCoursePlanId",
                table: "Courses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserCoursePlanId",
                table: "Courses",
                column: "UserCoursePlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Semesters_SemesterId",
                table: "Courses",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_UserCoursePlan_UserCoursePlanId",
                table: "Courses",
                column: "UserCoursePlanId",
                principalTable: "UserCoursePlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Semesters_Specializations_SpecializationId",
                table: "Semesters",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
