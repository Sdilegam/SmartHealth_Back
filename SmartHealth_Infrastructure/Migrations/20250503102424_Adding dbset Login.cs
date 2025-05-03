using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHealth_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingdbsetLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Login_LoginID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Login_LoginID",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Login",
                table: "Login");

            migrationBuilder.RenameTable(
                name: "Login",
                newName: "Logins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logins",
                table: "Logins",
                column: "LoginID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Logins_LoginID",
                table: "Doctors",
                column: "LoginID",
                principalTable: "Logins",
                principalColumn: "LoginID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Logins_LoginID",
                table: "Patients",
                column: "LoginID",
                principalTable: "Logins",
                principalColumn: "LoginID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Logins_LoginID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Logins_LoginID",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logins",
                table: "Logins");

            migrationBuilder.RenameTable(
                name: "Logins",
                newName: "Login");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Login",
                table: "Login",
                column: "LoginID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Login_LoginID",
                table: "Doctors",
                column: "LoginID",
                principalTable: "Login",
                principalColumn: "LoginID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Login_LoginID",
                table: "Patients",
                column: "LoginID",
                principalTable: "Login",
                principalColumn: "LoginID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
