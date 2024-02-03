using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurnitureStoreProject.API.Migrations
{
    public partial class UpdateUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 2, 3, 22, 35, 49, 543, DateTimeKind.Utc).AddTicks(5764));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 2, 3, 22, 35, 49, 543, DateTimeKind.Utc).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 2, 3, 22, 35, 49, 543, DateTimeKind.Utc).AddTicks(5769));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 3, 19, 35, 49, 543, DateTimeKind.Local).AddTicks(5814));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 3, 19, 35, 49, 543, DateTimeKind.Local).AddTicks(5827));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 3, 19, 35, 49, 543, DateTimeKind.Local).AddTicks(5828));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 3, 19, 35, 49, 543, DateTimeKind.Local).AddTicks(5829));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 12, 2, 24, 36, 605, DateTimeKind.Utc).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 12, 2, 24, 36, 605, DateTimeKind.Utc).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 12, 12, 2, 24, 36, 605, DateTimeKind.Utc).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 11, 23, 24, 36, 605, DateTimeKind.Local).AddTicks(3129));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 11, 23, 24, 36, 605, DateTimeKind.Local).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 11, 23, 24, 36, 605, DateTimeKind.Local).AddTicks(3144));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 11, 23, 24, 36, 605, DateTimeKind.Local).AddTicks(3146));
        }
    }
}
