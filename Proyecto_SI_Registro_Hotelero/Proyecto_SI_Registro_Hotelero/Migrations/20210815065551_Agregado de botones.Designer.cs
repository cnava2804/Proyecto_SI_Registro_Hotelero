﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_SI_Registro_Hotelero.Data;

namespace Proyecto_SI_Registro_Hotelero.Migrations
{
    [DbContext(typeof(PRHoteleroDbContext))]
    [Migration("20210815065551_Agregado de botones")]
    partial class Agregadodebotones
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Proyecto_SI_Registro_Hotelero.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Proyecto_SI_Registro_Hotelero.Models.EstadoHabitacion", b =>
                {
                    b.Property<int>("EstadoHId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoHId");

                    b.ToTable("EstadoHabitaciones");
                });

            modelBuilder.Entity("Proyecto_SI_Registro_Hotelero.Models.Habitacion", b =>
                {
                    b.Property<int>("HabitacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstadoHId")
                        .HasColumnType("int");

                    b.Property<string>("HabitacionDescripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HabitacionNumero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("HabitacionPrecio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PisoHId")
                        .HasColumnType("int");

                    b.Property<int>("TipoHId")
                        .HasColumnType("int");

                    b.HasKey("HabitacionId");

                    b.HasIndex("EstadoHId");

                    b.HasIndex("PisoHId");

                    b.HasIndex("TipoHId");

                    b.ToTable("Habitaciones");
                });

            modelBuilder.Entity("Proyecto_SI_Registro_Hotelero.Models.PagoReserva", b =>
                {
                    b.Property<int>("PReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PReservaCedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PReservaCodigoTarjeta")
                        .HasColumnType("int");

                    b.Property<int>("PReservaFechaVencimiento")
                        .HasColumnType("int");

                    b.Property<string>("PReservaNumeroTarjeta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PReservaTitular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservaHId")
                        .HasColumnType("int");

                    b.HasKey("PReservaId");

                    b.HasIndex("ReservaHId");

                    b.ToTable("PagoReservas");
                });

            modelBuilder.Entity("Proyecto_SI_Registro_Hotelero.Models.PisoHabitacion", b =>
                {
                    b.Property<int>("PisoHId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Piso")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PisoHId");

                    b.ToTable("PisoHabitaciones");
                });

            modelBuilder.Entity("Proyecto_SI_Registro_Hotelero.Models.ReservaHabitacion", b =>
                {
                    b.Property<int>("ReservaHId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechasSalida")
                        .HasColumnType("datetime2");

                    b.Property<int>("HabitacionId")
                        .HasColumnType("int");

                    b.Property<string>("ReservaApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReservaNombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReservaHId");

                    b.HasIndex("HabitacionId");

                    b.ToTable("ReservaHabitaciones");
                });

            modelBuilder.Entity("Proyecto_SI_Registro_Hotelero.Models.TipoHabitacion", b =>
                {
                    b.Property<int>("TipoHId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipoDescripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoHId");

                    b.ToTable("TipoHabitaciones");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Proyecto_SI_Registro_Hotelero.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Proyecto_SI_Registro_Hotelero.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_SI_Registro_Hotelero.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Proyecto_SI_Registro_Hotelero.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proyecto_SI_Registro_Hotelero.Models.Habitacion", b =>
                {
                    b.HasOne("Proyecto_SI_Registro_Hotelero.Models.EstadoHabitacion", "EstadoHabitacion")
                        .WithMany("Habitaciones")
                        .HasForeignKey("EstadoHId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_SI_Registro_Hotelero.Models.PisoHabitacion", "PisoHabitacion")
                        .WithMany("Habitaciones")
                        .HasForeignKey("PisoHId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_SI_Registro_Hotelero.Models.TipoHabitacion", "TipoHabitacion")
                        .WithMany("Habitaciones")
                        .HasForeignKey("TipoHId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoHabitacion");

                    b.Navigation("PisoHabitacion");

                    b.Navigation("TipoHabitacion");
                });

            modelBuilder.Entity("Proyecto_SI_Registro_Hotelero.Models.PagoReserva", b =>
                {
                    b.HasOne("Proyecto_SI_Registro_Hotelero.Models.ReservaHabitacion", "ReservaHabitacion")
                        .WithMany("PagoReservas")
                        .HasForeignKey("ReservaHId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReservaHabitacion");
                });

            modelBuilder.Entity("Proyecto_SI_Registro_Hotelero.Models.ReservaHabitacion", b =>
                {
                    b.HasOne("Proyecto_SI_Registro_Hotelero.Models.Habitacion", "Habitacion")
                        .WithMany("Reservahabitaciones")
                        .HasForeignKey("HabitacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habitacion");
                });

            modelBuilder.Entity("Proyecto_SI_Registro_Hotelero.Models.EstadoHabitacion", b =>
                {
                    b.Navigation("Habitaciones");
                });

            modelBuilder.Entity("Proyecto_SI_Registro_Hotelero.Models.Habitacion", b =>
                {
                    b.Navigation("Reservahabitaciones");
                });

            modelBuilder.Entity("Proyecto_SI_Registro_Hotelero.Models.PisoHabitacion", b =>
                {
                    b.Navigation("Habitaciones");
                });

            modelBuilder.Entity("Proyecto_SI_Registro_Hotelero.Models.ReservaHabitacion", b =>
                {
                    b.Navigation("PagoReservas");
                });

            modelBuilder.Entity("Proyecto_SI_Registro_Hotelero.Models.TipoHabitacion", b =>
                {
                    b.Navigation("Habitaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
