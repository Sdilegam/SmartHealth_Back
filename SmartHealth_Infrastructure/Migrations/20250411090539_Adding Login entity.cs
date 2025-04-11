using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHealth_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingLoginentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Addresses_AddressID",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Doctors",
                newName: "ProfessionalAddressAddressID");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_AddressID",
                table: "Doctors",
                newName: "IX_Doctors_ProfessionalAddressAddressID");

            migrationBuilder.AddColumn<int>(
                name: "LoginID",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoginID",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalAddressAddressID",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    LoginID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.LoginID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_LoginID",
                table: "Patients",
                column: "LoginID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_LoginID",
                table: "Doctors",
                column: "LoginID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PersonalAddressAddressID",
                table: "Doctors",
                column: "PersonalAddressAddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Addresses_PersonalAddressAddressID",
                table: "Doctors",
                column: "PersonalAddressAddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Addresses_ProfessionalAddressAddressID",
                table: "Doctors",
                column: "ProfessionalAddressAddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.NoAction);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Addresses_PersonalAddressAddressID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Addresses_ProfessionalAddressAddressID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Login_LoginID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Login_LoginID",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropIndex(
                name: "IX_Patients_LoginID",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_LoginID",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_PersonalAddressAddressID",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "LoginID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "LoginID",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PersonalAddressAddressID",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "ProfessionalAddressAddressID",
                table: "Doctors",
                newName: "AddressID");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_ProfessionalAddressAddressID",
                table: "Doctors",
                newName: "IX_Doctors_AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Addresses_AddressID",
                table: "Doctors",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
