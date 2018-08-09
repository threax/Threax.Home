﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Threax.Home.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    SwitchId = table.Column<Guid>(nullable: false),
                    Bridge = table.Column<string>(maxLength: 450, nullable: false),
                    Brightness = table.Column<byte>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    HexColor = table.Column<string>(maxLength: 450, nullable: true),
                    Id = table.Column<string>(maxLength: 450, nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Subsystem = table.Column<string>(maxLength: 450, nullable: false),
                    Value = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Switches", x => x.SwitchId);
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

            migrationBuilder.CreateIndex(
                name: "IX_spc.auth.UsersToRoles_RoleId",
                table: "spc.auth.UsersToRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Switches_Bridge_Subsystem_Id",
                table: "Switches",
                columns: new[] { "Bridge", "Subsystem", "Id" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "spc.auth.UsersToRoles");

            migrationBuilder.DropTable(
                name: "Switches");

            migrationBuilder.DropTable(
                name: "spc.auth.Roles");

            migrationBuilder.DropTable(
                name: "spc.auth.Users");
        }
    }
}