using Microsoft.EntityFrameworkCore.Migrations;

namespace Threax.Home.Migrations
{
    public partial class buttonstateicon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Icon",
                table: "ButtonStates",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "ButtonStates");
        }
    }
}
