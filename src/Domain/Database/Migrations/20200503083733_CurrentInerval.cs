using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class CurrentInerval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentInterval",
                table: "Locations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentInterval",
                table: "Locations");
        }
    }
}
