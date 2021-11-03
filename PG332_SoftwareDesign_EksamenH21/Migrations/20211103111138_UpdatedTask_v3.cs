using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class UpdatedTask_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_TaskSets_TaskSetId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_TaskSetId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskSetId",
                table: "Lectures");

            migrationBuilder.AddColumn<long>(
                name: "LectureId",
                table: "TaskSets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TaskSets_LectureId",
                table: "TaskSets",
                column: "LectureId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskSets_Lectures_LectureId",
                table: "TaskSets",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskSets_Lectures_LectureId",
                table: "TaskSets");

            migrationBuilder.DropIndex(
                name: "IX_TaskSets_LectureId",
                table: "TaskSets");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "TaskSets");

            migrationBuilder.AddColumn<long>(
                name: "LectureId",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TaskSetId",
                table: "Lectures",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_TaskSetId",
                table: "Lectures",
                column: "TaskSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_TaskSets_TaskSetId",
                table: "Lectures",
                column: "TaskSetId",
                principalTable: "TaskSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
