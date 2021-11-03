using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class WithTaskSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TaskSetId",
                table: "Tasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LectureDateTime",
                table: "Lectures",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "TaskSetId",
                table: "Lectures",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaskSets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskSetId",
                table: "Tasks",
                column: "TaskSetId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskSets_TaskSetId",
                table: "Tasks",
                column: "TaskSetId",
                principalTable: "TaskSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_TaskSets_TaskSetId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskSets_TaskSetId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskSets");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskSetId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_TaskSetId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "TaskSetId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "LectureDateTime",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "TaskSetId",
                table: "Lectures");
        }
    }
}
