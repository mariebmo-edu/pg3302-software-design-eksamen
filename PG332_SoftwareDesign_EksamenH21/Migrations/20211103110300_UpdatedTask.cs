using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class UpdatedTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Lectures_LectureId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_LectureId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Tasks",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tasks");

            migrationBuilder.AddColumn<long>(
                name: "LectureId",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_LectureId",
                table: "Tasks",
                column: "LectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Lectures_LectureId",
                table: "Tasks",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
