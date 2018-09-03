using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Threax.Home.Migrations
{
    public partial class initial : Migration
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
                name: "Sensors",
                columns: table => new
                {
                    SensorId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Subsystem = table.Column<string>(maxLength: 450, nullable: false),
                    Bridge = table.Column<string>(maxLength: 450, nullable: false),
                    Id = table.Column<string>(maxLength: 450, nullable: false),
                    TempValue = table.Column<double>(nullable: true),
                    TempUnits = table.Column<int>(nullable: true),
                    LightValue = table.Column<double>(nullable: true),
                    LightUnits = table.Column<int>(nullable: true),
                    HumidityValue = table.Column<double>(nullable: true),
                    HumidityUnits = table.Column<int>(nullable: true),
                    UvValue = table.Column<double>(nullable: true),
                    UvUnits = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.SensorId);
                });

            migrationBuilder.CreateTable(
                name: "spc.auth.Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spc.auth.Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "spc.auth.Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spc.auth.Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Switches",
                columns: table => new
                {
                    Brightness = table.Column<byte>(nullable: true),
                    SwitchId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Subsystem = table.Column<string>(maxLength: 450, nullable: false),
                    Bridge = table.Column<string>(maxLength: 450, nullable: false),
                    Id = table.Column<string>(maxLength: 450, nullable: false),
                    Value = table.Column<string>(maxLength: 450, nullable: true),
                    HexColor = table.Column<string>(maxLength: 450, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Switches", x => x.SwitchId);
                });

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
                name: "spc.auth.UsersToRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spc.auth.UsersToRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_spc.auth.UsersToRoles_spc.auth.Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "spc.auth.Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spc.auth.UsersToRoles_spc.auth.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "spc.auth.Users",
                        principalColumn: "UserId",
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
                    table.ForeignKey(
                        name: "FK_SwitchSettings_Switches_SwitchId",
                        column: x => x.SwitchId,
                        principalTable: "Switches",
                        principalColumn: "SwitchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ButtonStates_ButtonId",
                table: "ButtonStates",
                column: "ButtonId");

            migrationBuilder.CreateIndex(
                name: "IX_spc.auth.UsersToRoles_RoleId",
                table: "spc.auth.UsersToRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Switches_Bridge_Subsystem_Id",
                table: "Switches",
                columns: new[] { "Bridge", "Subsystem", "Id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SwitchSettings_ButtonStateId",
                table: "SwitchSettings",
                column: "ButtonStateId");

            migrationBuilder.CreateIndex(
                name: "IX_SwitchSettings_SwitchId",
                table: "SwitchSettings",
                column: "SwitchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "spc.auth.UsersToRoles");

            migrationBuilder.DropTable(
                name: "SwitchSettings");

            migrationBuilder.DropTable(
                name: "Thermostats");

            migrationBuilder.DropTable(
                name: "spc.auth.Roles");

            migrationBuilder.DropTable(
                name: "spc.auth.Users");

            migrationBuilder.DropTable(
                name: "ButtonStates");

            migrationBuilder.DropTable(
                name: "Switches");

            migrationBuilder.DropTable(
                name: "Buttons");
        }
    }
}
