using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class alimentantoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "FechaRegistro", "ImagenURL", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Detalle de la villa", new DateTime(2023, 7, 14, 11, 51, 12, 904, DateTimeKind.Local).AddTicks(26), new DateTime(2023, 7, 14, 11, 51, 12, 904, DateTimeKind.Local).AddTicks(14), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 200, "Villa 1", 5, 0.0 },
                    { 2, "", "Detalle de la villa 2", new DateTime(2023, 7, 14, 11, 51, 12, 904, DateTimeKind.Local).AddTicks(28), new DateTime(2023, 7, 14, 11, 51, 12, 904, DateTimeKind.Local).AddTicks(28), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 100, "Villa 2", 4, 0.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
