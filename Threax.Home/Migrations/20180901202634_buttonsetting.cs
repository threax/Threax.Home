using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Threax.Home.Migrations
{
    public partial class buttonsetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ButtonSettings",
                columns: table => new
                {
                    ButtonSettingId = table.Column<Guid>(nullable: false),
                    SwitchId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Brightness = table.Column<int>(nullable: true),
                    HexColor = table.Column<string>(maxLength: 450, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ButtonSettings", x => x.ButtonSettingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ButtonSettings");
        }
    }
}
