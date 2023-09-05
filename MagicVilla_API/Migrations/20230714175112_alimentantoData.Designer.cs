﻿// <auto-generated />
using System;
using MagicVilla_API.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla_API.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20230714175112_alimentantoData")]
    partial class alimentantoData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVilla_API.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detalle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagenURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MetrosCuadrados")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocupantes")
                        .HasColumnType("int");

                    b.Property<double>("Tarifa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenidad = "",
                            Detalle = "Detalle de la villa",
                            FechaActualizacion = new DateTime(2023, 7, 14, 11, 51, 12, 904, DateTimeKind.Local).AddTicks(26),
                            FechaCreacion = new DateTime(2023, 7, 14, 11, 51, 12, 904, DateTimeKind.Local).AddTicks(14),
                            FechaRegistro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagenURL = "",
                            MetrosCuadrados = 200,
                            Nombre = "Villa 1",
                            Ocupantes = 5,
                            Tarifa = 0.0
                        },
                        new
                        {
                            Id = 2,
                            Amenidad = "",
                            Detalle = "Detalle de la villa 2",
                            FechaActualizacion = new DateTime(2023, 7, 14, 11, 51, 12, 904, DateTimeKind.Local).AddTicks(28),
                            FechaCreacion = new DateTime(2023, 7, 14, 11, 51, 12, 904, DateTimeKind.Local).AddTicks(28),
                            FechaRegistro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagenURL = "",
                            MetrosCuadrados = 100,
                            Nombre = "Villa 2",
                            Ocupantes = 4,
                            Tarifa = 0.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
