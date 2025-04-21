using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHealth_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangingAvailabilitytimefromstringtoTimeOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndHour",
                table: "DoctorAvailability");

            migrationBuilder.DropColumn(
                name: "EndMinute",
                table: "DoctorAvailability");

            migrationBuilder.DropColumn(
                name: "StartHour",
                table: "DoctorAvailability");

            migrationBuilder.DropColumn(
                name: "StartMinute",
                table: "DoctorAvailability");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "EndTime",
                table: "DoctorAvailability",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "StartTime",
                table: "DoctorAvailability",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "DoctorAvailability");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "DoctorAvailability");

            migrationBuilder.AddColumn<int>(
                name: "EndHour",
                table: "DoctorAvailability",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndMinute",
                table: "DoctorAvailability",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartHour",
                table: "DoctorAvailability",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartMinute",
                table: "DoctorAvailability",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
