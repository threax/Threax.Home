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
                name: "ButtonStates",
                columns: table => new
                {
                    ButtonStateId = table.Column<Guid>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    ButtonId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ButtonStates", x => x.ButtonStateId);
                    table.ForeignKey(
                        name: "FK_ButtonStates_Buttons_ButtonId",
                        column: x => x.ButtonId,
                        principalTable: "Buttons",
                        principalColumn: "ButtonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SwitchSettings",
                columns: table => new
                {
                    SwitchSettingId = table.Column<Guid>(nullable: false),
                    SwitchId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Brightness = table.Column<int>(nullable: true),
                    HexColor = table.Column<string>(maxLength: 450, nullable: true),
                    ButtonStateId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwitchSettings", x => x.SwitchSettingId);
                    table.ForeignKey(
                        name: "FK_SwitchSettings_ButtonStates_ButtonStateId",
                        column: x => x.ButtonStateId,
                        principalTable: "ButtonStates",
                        principalColumn: "ButtonStateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ButtonStates_ButtonId",
                table: "ButtonStates",
                column: "ButtonId");

            migrationBuilder.CreateIndex(
                name: "IX_SwitchSettings_ButtonStateId",
                table: "SwitchSettings",
                column: "ButtonStateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SwitchSettings");

            migrationBuilder.DropTable(
                name: "ButtonStates");

            migrationBuilder.DropTable(
                name: "Buttons");
        }
    }
}
