using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Threax.Home.Migrations
{
    public partial class thermosettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThermostatSettings",
                columns: table => new
                {
                    ThermostatSettingId = table.Column<Guid>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    CoolTemp = table.Column<int>(nullable: false),
                    HeatTemp = table.Column<int>(nullable: false),
                    On = table.Column<bool>(nullable: false),
                    ThermostatId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThermostatSettings", x => x.ThermostatSettingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThermostatSettings");
        }
    }
}
