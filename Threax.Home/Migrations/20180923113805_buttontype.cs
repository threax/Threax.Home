using Microsoft.EntityFrameworkCore.Migrations;

namespace Threax.Home.Migrations
{
    public partial class buttontype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ButtonType",
                table: "Buttons",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ButtonType",
                table: "Buttons");
        }
    }
}
