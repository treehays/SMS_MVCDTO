using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSMVCDTO.Migrations
{
    /// <inheritdoc />
    public partial class seedings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordResetToken",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2023, 3, 5, 12, 6, 38, 205, DateTimeKind.Local).AddTicks(8091), new DateTime(2023, 3, 5, 12, 6, 38, 205, DateTimeKind.Local).AddTicks(8113) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2023, 3, 5, 12, 6, 38, 205, DateTimeKind.Local).AddTicks(8116), new DateTime(2023, 3, 5, 12, 6, 38, 205, DateTimeKind.Local).AddTicks(8117) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2023, 3, 5, 12, 6, 38, 205, DateTimeKind.Local).AddTicks(8120), new DateTime(2023, 3, 5, 12, 6, 38, 205, DateTimeKind.Local).AddTicks(8121) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2023, 3, 5, 12, 6, 38, 205, DateTimeKind.Local).AddTicks(8123), new DateTime(2023, 3, 5, 12, 6, 38, 205, DateTimeKind.Local).AddTicks(8124) });

            migrationBuilder.UpdateData(
                table: "SuperAdmins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "DateOfBirth", "Modified" },
                values: new object[] { new DateTime(2023, 3, 5, 12, 6, 38, 205, DateTimeKind.Local).AddTicks(8478), new DateTime(2023, 3, 5, 12, 6, 38, 205, DateTimeKind.Local).AddTicks(8476), new DateTime(2023, 3, 5, 12, 6, 38, 205, DateTimeKind.Local).AddTicks(8479) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "PasswordResetToken" },
                values: new object[] { new DateTime(2023, 3, 5, 12, 6, 38, 205, DateTimeKind.Local).AddTicks(8440), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordResetToken",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2023, 3, 4, 15, 27, 21, 394, DateTimeKind.Local).AddTicks(253), new DateTime(2023, 3, 4, 15, 27, 21, 394, DateTimeKind.Local).AddTicks(275) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2023, 3, 4, 15, 27, 21, 394, DateTimeKind.Local).AddTicks(278), new DateTime(2023, 3, 4, 15, 27, 21, 394, DateTimeKind.Local).AddTicks(279) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2023, 3, 4, 15, 27, 21, 394, DateTimeKind.Local).AddTicks(281), new DateTime(2023, 3, 4, 15, 27, 21, 394, DateTimeKind.Local).AddTicks(282) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2023, 3, 4, 15, 27, 21, 394, DateTimeKind.Local).AddTicks(284), new DateTime(2023, 3, 4, 15, 27, 21, 394, DateTimeKind.Local).AddTicks(285) });

            migrationBuilder.UpdateData(
                table: "SuperAdmins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "DateOfBirth", "Modified" },
                values: new object[] { new DateTime(2023, 3, 4, 15, 27, 21, 394, DateTimeKind.Local).AddTicks(657), new DateTime(2023, 3, 4, 15, 27, 21, 394, DateTimeKind.Local).AddTicks(652), new DateTime(2023, 3, 4, 15, 27, 21, 394, DateTimeKind.Local).AddTicks(658) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 3, 4, 15, 27, 21, 394, DateTimeKind.Local).AddTicks(617));
        }
    }
}
