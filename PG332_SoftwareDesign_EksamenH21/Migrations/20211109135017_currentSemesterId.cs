using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class currentSemesterId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "currentSemesterId",
                table: "Users",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "currentSemesterId",
                table: "Users");
        }
    }
}
