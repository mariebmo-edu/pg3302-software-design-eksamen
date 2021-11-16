using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class FinishedFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Finished",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Finished",
                table: "Semesters",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finished",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Finished",
                table: "Semesters");
        }
    }
}
