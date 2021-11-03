using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class MigrationWithOptCoursesAndSpecCourses_v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCoursePlan_CoursePlanCourses_CoursePlanCoursesId",
                table: "UserCoursePlan");

            migrationBuilder.DropTable(
                name: "CoursePlanCourses");

            migrationBuilder.DropTable(
                name: "SpecializationCourses");

            migrationBuilder.DropIndex(
                name: "IX_UserCoursePlan_CoursePlanCoursesId",
                table: "UserCoursePlan");

            migrationBuilder.DropColumn(
                name: "CoursePlanCoursesId",
                table: "UserCoursePlan");

            migrationBuilder.RenameColumn(
                name: "SemesterEnum",
                table: "UserCoursePlan",
                newName: "CourseInPlanId");

            migrationBuilder.CreateTable(
                name: "CoursesInSpecializations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpecializationId = table.Column<long>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<long>(type: "INTEGER", nullable: false),
                    mandatory = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesInSpecializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursesInSpecializations_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesInSpecializations_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseInPlans",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpecializationCoursesId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseInPlans_CoursesInSpecializations_SpecializationCoursesId",
                        column: x => x.SpecializationCoursesId,
                        principalTable: "CoursesInSpecializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCoursePlan_CourseInPlanId",
                table: "UserCoursePlan",
                column: "CourseInPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInPlans_SpecializationCoursesId",
                table: "CourseInPlans",
                column: "SpecializationCoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesInSpecializations_CourseId",
                table: "CoursesInSpecializations",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesInSpecializations_SpecializationId",
                table: "CoursesInSpecializations",
                column: "SpecializationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCoursePlan_CourseInPlans_CourseInPlanId",
                table: "UserCoursePlan",
                column: "CourseInPlanId",
                principalTable: "CourseInPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCoursePlan_CourseInPlans_CourseInPlanId",
                table: "UserCoursePlan");

            migrationBuilder.DropTable(
                name: "CourseInPlans");

            migrationBuilder.DropTable(
                name: "CoursesInSpecializations");

            migrationBuilder.DropIndex(
                name: "IX_UserCoursePlan_CourseInPlanId",
                table: "UserCoursePlan");

            migrationBuilder.RenameColumn(
                name: "CourseInPlanId",
                table: "UserCoursePlan",
                newName: "SemesterEnum");

            migrationBuilder.AddColumn<long>(
                name: "CoursePlanCoursesId",
                table: "UserCoursePlan",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SpecializationCourses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseId = table.Column<long>(type: "INTEGER", nullable: false),
                    SpecializationId = table.Column<long>(type: "INTEGER", nullable: false),
                    mandatory = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializationCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecializationCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecializationCourses_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationCourses_CourseId",
                table: "SpecializationCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationCourses_SpecializationId",
                table: "SpecializationCourses",
                column: "SpecializationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCoursePlan_CoursePlanCourses_CoursePlanCoursesId",
                table: "UserCoursePlan",
                column: "CoursePlanCoursesId",
                principalTable: "CoursePlanCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
