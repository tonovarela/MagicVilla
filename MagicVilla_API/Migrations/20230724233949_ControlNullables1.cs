using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class ControlNullables1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 7, 24, 17, 39, 49, 613, DateTimeKind.Local).AddTicks(1469), new DateTime(2023, 7, 24, 17, 39, 49, 613, DateTimeKind.Local).AddTicks(1457) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 7, 24, 17, 39, 49, 613, DateTimeKind.Local).AddTicks(1472), new DateTime(2023, 7, 24, 17, 39, 49, 613, DateTimeKind.Local).AddTicks(1471) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 7, 24, 17, 38, 18, 486, DateTimeKind.Local).AddTicks(1607), new DateTime(2023, 7, 24, 17, 38, 18, 486, DateTimeKind.Local).AddTicks(1595) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 7, 24, 17, 38, 18, 486, DateTimeKind.Local).AddTicks(1610), new DateTime(2023, 7, 24, 17, 38, 18, 486, DateTimeKind.Local).AddTicks(1609) });
        }
    }
}
