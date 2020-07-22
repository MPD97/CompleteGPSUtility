using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class fixDecimalToShort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeUnix",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "TimeY2K",
                table: "Locations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeY2K",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "TimeUnix",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
