using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHealth_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addingdoctorsavailabilityandappointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PatientsNotes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppointmentID);
                });

            migrationBuilder.CreateTable(
                name: "DoctorAvailability",
                columns: table => new
                {
                    DoctorAvailabilityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Days = table.Column<int>(type: "int", nullable: false),
                    StartHour = table.Column<int>(type: "int", nullable: false),
                    EndHour = table.Column<int>(type: "int", nullable: false),
                    StartMinute = table.Column<int>(type: "int", nullable: false),
                    EndMinute = table.Column<int>(type: "int", nullable: false),
                    ValidtyStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidtyEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorAvailability", x => x.DoctorAvailabilityID);
                    table.ForeignKey(
                        name: "FK_DoctorAvailability_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId");
                });

            migrationBuilder.CreateTable(
                name: "AppointmentDoctor",
                columns: table => new
                {
                    AppointmentsAppointmentID = table.Column<int>(type: "int", nullable: false),
                    DoctorsDoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentDoctor", x => new { x.AppointmentsAppointmentID, x.DoctorsDoctorId });
                    table.ForeignKey(
                        name: "FK_AppointmentDoctor_Appointment_AppointmentsAppointmentID",
                        column: x => x.AppointmentsAppointmentID,
                        principalTable: "Appointment",
                        principalColumn: "AppointmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentDoctor_Doctors_DoctorsDoctorId",
                        column: x => x.DoctorsDoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentPatient",
                columns: table => new
                {
                    AppointmentsAppointmentID = table.Column<int>(type: "int", nullable: false),
                    PatientsPatientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentPatient", x => new { x.AppointmentsAppointmentID, x.PatientsPatientID });
                    table.ForeignKey(
                        name: "FK_AppointmentPatient_Appointment_AppointmentsAppointmentID",
                        column: x => x.AppointmentsAppointmentID,
                        principalTable: "Appointment",
                        principalColumn: "AppointmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentPatient_Patients_PatientsPatientID",
                        column: x => x.PatientsPatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDoctor_DoctorsDoctorId",
                table: "AppointmentDoctor",
                column: "DoctorsDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentPatient_PatientsPatientID",
                table: "AppointmentPatient",
                column: "PatientsPatientID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAvailability_DoctorId",
                table: "DoctorAvailability",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentDoctor");

            migrationBuilder.DropTable(
                name: "AppointmentPatient");

            migrationBuilder.DropTable(
                name: "DoctorAvailability");

            migrationBuilder.DropTable(
                name: "Appointment");
        }
    }
}
