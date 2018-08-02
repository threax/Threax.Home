using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Threax.Home.Migrations
{
    public partial class thermostats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Thermostats",
                columns: table => new
                {
                    ThermostatId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Subsystem = table.Column<string>(nullable: true),
                    Bridge = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: true),
                    Mode = table.Column<int>(nullable: false),
                    Fan = table.Column<int>(nullable: false),
                    HeatTemp = table.Column<int>(nullable: false),
                    CoolTemp = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    FanState = table.Column<int>(nullable: false),
                    TempUnits = table.Column<int>(nullable: false),
                    Schedule = table.Column<int>(nullable: false),
                    SchedulePart = table.Column<int>(nullable: false),
                    Away = table.Column<int>(nullable: false),
                    Holidy = table.Column<int>(nullable: false),
                    Override = table.Column<int>(nullable: false),
                    OverrideTime = table.Column<int>(nullable: false),
                    ForceUnocc = table.Column<int>(nullable: false),
                    SpaceTemp = table.Column<int>(nullable: false),
                    CoolTempMin = table.Column<int>(nullable: false),
                    CoolTempMax = table.Column<int>(nullable: false),
                    HeatTempMin = table.Column<int>(nullable: false),
                    HeatTempMax = table.Column<int>(nullable: false),
                    SetPointDelta = table.Column<int>(nullable: false),
                    Humidity = table.Column<int>(nullable: false),
                    AvailableModes = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thermostats", x => x.ThermostatId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Thermostats");
        }
    }
}
