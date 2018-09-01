using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Threax.Home.Migrations
{
    public partial class button : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buttons",
                columns: table => new
                {
                    ButtonId = table.Column<Guid>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buttons", x => x.ButtonId);
                });

            migrationBuilder.CreateTable(
                name: "ButtonSettings",
                columns: table => new
                {
                    ButtonSettingId = table.Column<Guid>(nullable: false),
                    SwitchId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Brightness = table.Column<int>(nullable: true),
                    HexColor = table.Column<string>(maxLength: 450, nullable: true),
                    ButtonId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ButtonSettings", x => x.ButtonSettingId);
                    table.ForeignKey(
                        name: "FK_ButtonSettings_Buttons_ButtonId",
                        column: x => x.ButtonId,
                        principalTable: "Buttons",
                        principalColumn: "ButtonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ButtonSettings_ButtonId",
                table: "ButtonSettings",
                column: "ButtonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ButtonSettings");

            migrationBuilder.DropTable(
                name: "Buttons");
        }
    }
}
