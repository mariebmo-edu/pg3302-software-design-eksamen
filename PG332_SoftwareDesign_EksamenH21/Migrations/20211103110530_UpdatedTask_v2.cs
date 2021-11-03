using Microsoft.EntityFrameworkCore.Migrations;

namespace PG332_SoftwareDesign_EksamenH21.Migrations
{
    public partial class UpdatedTask_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LectureId",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Tasks");
        }
    }
}
