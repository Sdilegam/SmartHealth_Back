﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartHealth_Infrastructure;

#nullable disable

namespace SmartHealth_Infrastructure.Migrations
{
    [DbContext(typeof(SmartHealthContext))]
    [Migration("20250411113625_Avatar")]
    partial class Avatar
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartHealth_Domain.Entities.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressID"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("SmartHealth_Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"));

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoginID")
                        .HasColumnType("int");

                    b.Property<int>("PersonalAddressAddressID")
                        .HasColumnType("int");

                    b.Property<int>("ProfessionalAddressAddressID")
                        .HasColumnType("int");

                    b.HasKey("DoctorId");

                    b.HasIndex("LoginID");

                    b.HasIndex("PersonalAddressAddressID");

                    b.HasIndex("ProfessionalAddressAddressID");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("SmartHealth_Domain.Entities.Login", b =>
                {
                    b.Property<int>("LoginID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoginID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginID");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("SmartHealth_Domain.Entities.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoginID")
                        .HasColumnType("int");

                    b.Property<int>("PersonalAdressAddressID")
                        .HasColumnType("int");

                    b.HasKey("PatientID");

                    b.HasIndex("LoginID");

                    b.HasIndex("PersonalAdressAddressID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("SmartHealth_Domain.Entities.Telecom", b =>
                {
                    b.Property<int>("TelecomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TelecomId"));

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("Scope")
                        .HasColumnType("int");

                    b.Property<string>("TelecomValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("TelecomId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Telecoms");
                });

            modelBuilder.Entity("SmartHealth_Domain.Entities.Doctor", b =>
                {
                    b.HasOne("SmartHealth_Domain.Entities.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartHealth_Domain.Entities.Address", "PersonalAddress")
                        .WithMany()
                        .HasForeignKey("PersonalAddressAddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartHealth_Domain.Entities.Address", "ProfessionalAddress")
                        .WithMany()
                        .HasForeignKey("ProfessionalAddressAddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Login");

                    b.Navigation("PersonalAddress");

                    b.Navigation("ProfessionalAddress");
                });

            modelBuilder.Entity("SmartHealth_Domain.Entities.Patient", b =>
                {
                    b.HasOne("SmartHealth_Domain.Entities.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartHealth_Domain.Entities.Address", "PersonalAdress")
                        .WithMany()
                        .HasForeignKey("PersonalAdressAddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Login");

                    b.Navigation("PersonalAdress");
                });

            modelBuilder.Entity("SmartHealth_Domain.Entities.Telecom", b =>
                {
                    b.HasOne("SmartHealth_Domain.Entities.Doctor", null)
                        .WithMany("Telecoms")
                        .HasForeignKey("DoctorId");
                });

            modelBuilder.Entity("SmartHealth_Domain.Entities.Doctor", b =>
                {
                    b.Navigation("Telecoms");
                });
#pragma warning restore 612, 618
        }
    }
}
