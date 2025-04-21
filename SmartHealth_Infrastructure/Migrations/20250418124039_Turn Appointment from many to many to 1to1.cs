using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHealth_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TurnAppointmentfrommanytomanyto1to1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentDoctor");

            migrationBuilder.DropTable(
                name: "AppointmentPatient");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorId",
                table: "Appointment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientID",
                table: "Appointment",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Doctors_DoctorId",
                table: "Appointment",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patients_PatientID",
                table: "Appointment",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Doctors_DoctorId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patients_PatientID",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_DoctorId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_PatientID",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "Appointment");

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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AppointmentDoctor_Doctors_DoctorsDoctorId",
                        column: x => x.DoctorsDoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.NoAction);
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
        }
    }
}
