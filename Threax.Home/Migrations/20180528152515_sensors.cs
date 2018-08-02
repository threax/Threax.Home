using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Threax.Home.Migrations
{
    public partial class sensors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    SensorId = table.Column<Guid>(nullable: false),
                    Bridge = table.Column<string>(maxLength: 450, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    HumidityUnits = table.Column<int>(nullable: true),
                    HumidityValue = table.Column<double>(nullable: true),
                    Id = table.Column<string>(maxLength: 450, nullable: false),
                    LightUnits = table.Column<int>(nullable: true),
                    LightValue = table.Column<double>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Subsystem = table.Column<string>(maxLength: 450, nullable: false),
                    TempUnits = table.Column<int>(nullable: true),
                    TempValue = table.Column<double>(nullable: true),
                    UvUnits = table.Column<int>(nullable: true),
                    UvValue = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.SensorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensors");
        }
    }
}
