using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class ControlNullables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 7, 24, 17, 42, 33, 170, DateTimeKind.Local).AddTicks(4951), new DateTime(2023, 7, 24, 17, 42, 33, 170, DateTimeKind.Local).AddTicks(4939) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 7, 24, 17, 42, 33, 170, DateTimeKind.Local).AddTicks(4954), new DateTime(2023, 7, 24, 17, 42, 33, 170, DateTimeKind.Local).AddTicks(4953) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
