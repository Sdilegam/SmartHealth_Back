using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHealth_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inamilanguagesspokenaddedtodoctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "INAMI",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LanguageSpoken",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "INAMI",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "LanguageSpoken",
                table: "Doctors");
        }
    }
}
