using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class sinCampo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Villas");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 7, 14, 12, 30, 11, 83, DateTimeKind.Local).AddTicks(3139), new DateTime(2023, 7, 14, 12, 30, 11, 83, DateTimeKind.Local).AddTicks(3126) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 7, 14, 12, 30, 11, 83, DateTimeKind.Local).AddTicks(3142), new DateTime(2023, 7, 14, 12, 30, 11, 83, DateTimeKind.Local).AddTicks(3141) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Villas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion", "FechaRegistro" },
                values: new object[] { new DateTime(2023, 7, 14, 11, 51, 12, 904, DateTimeKind.Local).AddTicks(26), new DateTime(2023, 7, 14, 11, 51, 12, 904, DateTimeKind.Local).AddTicks(14), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion", "FechaRegistro" },
                values: new object[] { new DateTime(2023, 7, 14, 11, 51, 12, 904, DateTimeKind.Local).AddTicks(28), new DateTime(2023, 7, 14, 11, 51, 12, 904, DateTimeKind.Local).AddTicks(28), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
