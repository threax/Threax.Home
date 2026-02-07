using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Threax.Home.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNetTen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Sensors",
                type: "TEXT",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 450);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Sensors",
                type: "TEXT",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 450,
                oldNullable: true);
        }
    }
}
