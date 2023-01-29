using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateColumnNameResourceName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResourceValue",
                schema: "dbo",
                table: "Resources",
                newName: "ResourceName");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUserTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 29, 22, 30, 45, 819, DateTimeKind.Local).AddTicks(3906));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2023, 1, 29, 22, 30, 45, 815, DateTimeKind.Local).AddTicks(1933), new byte[] { 169, 1, 99, 32, 213, 31, 137, 112, 85, 177, 7, 89, 65, 246, 148, 218, 39, 155, 4, 205, 156, 101, 188, 75, 2, 155, 82, 144, 16, 79, 96, 211, 181, 191, 24, 193, 156, 170, 9, 250, 147, 118, 42, 107, 167, 79, 242, 20, 233, 157, 110, 152, 94, 199, 237, 24, 89, 145, 237, 194, 85, 179, 248, 134 }, new byte[] { 118, 24, 103, 214, 202, 83, 41, 235, 167, 113, 185, 50, 226, 255, 99, 85, 183, 212, 58, 162, 39, 109, 220, 12, 68, 79, 68, 71, 56, 98, 42, 239, 202, 9, 112, 249, 23, 175, 82, 246, 115, 138, 0, 254, 109, 201, 225, 13, 255, 29, 55, 197, 14, 24, 147, 76, 220, 183, 117, 74, 23, 221, 53, 229, 211, 144, 51, 145, 101, 85, 59, 107, 225, 204, 41, 245, 38, 164, 146, 76, 253, 108, 178, 153, 158, 65, 20, 81, 45, 122, 148, 204, 110, 223, 117, 119, 144, 255, 87, 98, 50, 130, 66, 204, 115, 163, 17, 179, 51, 61, 152, 95, 218, 207, 228, 50, 156, 68, 58, 180, 121, 45, 211, 102, 243, 241, 107, 38 }, new Guid("4ff05c23-a60f-4b66-9795-496db9d8ac71") });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ResourceDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 29, 22, 30, 45, 836, DateTimeKind.Local).AddTicks(2323));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ResourceDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 29, 22, 30, 45, 836, DateTimeKind.Local).AddTicks(4767));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 29, 22, 30, 45, 834, DateTimeKind.Local).AddTicks(395));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResourceName",
                schema: "dbo",
                table: "Resources",
                newName: "ResourceValue");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUserTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 29, 22, 28, 37, 53, DateTimeKind.Local).AddTicks(6341));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2023, 1, 29, 22, 28, 37, 48, DateTimeKind.Local).AddTicks(5769), new byte[] { 173, 139, 33, 62, 205, 24, 164, 172, 101, 124, 36, 167, 5, 156, 187, 253, 62, 18, 24, 223, 132, 220, 165, 159, 184, 143, 187, 109, 252, 134, 171, 134, 235, 35, 22, 224, 53, 173, 71, 116, 120, 206, 111, 18, 17, 141, 100, 44, 154, 91, 177, 80, 63, 189, 172, 39, 211, 39, 43, 111, 105, 184, 205, 138 }, new byte[] { 185, 206, 53, 95, 206, 33, 155, 99, 202, 241, 188, 164, 188, 157, 125, 123, 44, 220, 113, 193, 143, 143, 119, 91, 100, 81, 1, 251, 46, 27, 67, 88, 119, 107, 254, 94, 176, 59, 222, 239, 208, 223, 91, 216, 125, 160, 121, 148, 22, 199, 33, 223, 215, 22, 194, 21, 30, 38, 106, 43, 2, 45, 135, 121, 246, 66, 67, 68, 101, 121, 240, 163, 100, 250, 251, 252, 146, 114, 29, 14, 176, 58, 140, 14, 134, 227, 54, 237, 145, 132, 103, 124, 71, 155, 226, 161, 225, 55, 18, 112, 222, 139, 228, 57, 229, 90, 77, 54, 133, 156, 135, 106, 189, 223, 138, 160, 99, 180, 50, 249, 97, 85, 60, 241, 207, 56, 7, 118 }, new Guid("4f4ba8a2-b7d8-469b-85a0-ec1e81303cee") });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ResourceDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 29, 22, 28, 37, 71, DateTimeKind.Local).AddTicks(6794));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ResourceDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 29, 22, 28, 37, 71, DateTimeKind.Local).AddTicks(9125));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 29, 22, 28, 37, 68, DateTimeKind.Local).AddTicks(5107));
        }
    }
}
