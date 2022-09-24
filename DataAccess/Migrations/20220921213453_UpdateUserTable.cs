using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserTypeName",
                schema: "dbo",
                table: "AppUserTypes",
                newName: "AppUserTypeName");

            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                schema: "dbo",
                table: "AppUsers",
                newName: "AppUserTypeID");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2022, 9, 22, 0, 34, 52, 747, DateTimeKind.Local).AddTicks(2598), new byte[] { 158, 173, 246, 14, 157, 42, 247, 134, 21, 96, 47, 89, 89, 135, 61, 208, 125, 87, 206, 96, 20, 216, 140, 79, 201, 251, 150, 206, 126, 180, 138, 140, 86, 94, 214, 106, 253, 53, 14, 106, 97, 86, 87, 87, 160, 195, 62, 216, 197, 242, 195, 66, 20, 111, 238, 123, 222, 114, 184, 137, 197, 64, 17, 204 }, new byte[] { 220, 182, 9, 15, 131, 147, 130, 194, 54, 128, 249, 198, 201, 112, 242, 239, 71, 128, 207, 166, 1, 109, 193, 181, 36, 47, 47, 105, 186, 208, 16, 101, 170, 236, 78, 10, 75, 177, 125, 14, 37, 33, 202, 37, 85, 106, 175, 16, 76, 27, 67, 24, 195, 53, 250, 141, 0, 168, 125, 143, 39, 193, 141, 152, 17, 50, 167, 99, 80, 3, 253, 140, 119, 136, 92, 28, 15, 157, 129, 5, 116, 61, 40, 120, 193, 204, 99, 172, 191, 170, 6, 192, 201, 81, 133, 224, 114, 71, 237, 161, 16, 98, 44, 217, 114, 46, 206, 119, 16, 101, 136, 171, 171, 152, 151, 4, 251, 158, 61, 44, 219, 8, 121, 123, 176, 166, 243, 12 }, new Guid("c439cb2b-866f-4d14-bef4-163aeb7afa78") });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2022, 9, 22, 0, 34, 52, 746, DateTimeKind.Local).AddTicks(1546), new byte[] { 158, 173, 246, 14, 157, 42, 247, 134, 21, 96, 47, 89, 89, 135, 61, 208, 125, 87, 206, 96, 20, 216, 140, 79, 201, 251, 150, 206, 126, 180, 138, 140, 86, 94, 214, 106, 253, 53, 14, 106, 97, 86, 87, 87, 160, 195, 62, 216, 197, 242, 195, 66, 20, 111, 238, 123, 222, 114, 184, 137, 197, 64, 17, 204 }, new byte[] { 220, 182, 9, 15, 131, 147, 130, 194, 54, 128, 249, 198, 201, 112, 242, 239, 71, 128, 207, 166, 1, 109, 193, 181, 36, 47, 47, 105, 186, 208, 16, 101, 170, 236, 78, 10, 75, 177, 125, 14, 37, 33, 202, 37, 85, 106, 175, 16, 76, 27, 67, 24, 195, 53, 250, 141, 0, 168, 125, 143, 39, 193, 141, 152, 17, 50, 167, 99, 80, 3, 253, 140, 119, 136, 92, 28, 15, 157, 129, 5, 116, 61, 40, 120, 193, 204, 99, 172, 191, 170, 6, 192, 201, 81, 133, 224, 114, 71, 237, 161, 16, 98, 44, 217, 114, 46, 206, 119, 16, 101, 136, 171, 171, 152, 151, 4, 251, 158, 61, 44, 219, 8, 121, 123, 176, 166, 243, 12 }, new Guid("dd7e878f-e985-48a6-b152-4f755a212b7d") });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_AppUserTypeID",
                schema: "dbo",
                table: "AppUsers",
                column: "AppUserTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppUserTypes_AppUserTypeID",
                schema: "dbo",
                table: "AppUsers",
                column: "AppUserTypeID",
                principalSchema: "dbo",
                principalTable: "AppUserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppUserTypes_AppUserTypeID",
                schema: "dbo",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_AppUserTypeID",
                schema: "dbo",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "AppUserTypeName",
                schema: "dbo",
                table: "AppUserTypes",
                newName: "UserTypeName");

            migrationBuilder.RenameColumn(
                name: "AppUserTypeID",
                schema: "dbo",
                table: "AppUsers",
                newName: "UserTypeId");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2022, 7, 23, 15, 10, 33, 961, DateTimeKind.Local).AddTicks(1332), new byte[] { 203, 118, 128, 141, 193, 235, 163, 168, 249, 144, 166, 212, 154, 19, 208, 141, 121, 109, 98, 82, 111, 251, 79, 44, 24, 179, 64, 253, 125, 182, 78, 167, 251, 103, 27, 119, 192, 143, 40, 63, 139, 22, 211, 114, 39, 75, 145, 130, 156, 121, 62, 65, 241, 151, 92, 174, 139, 101, 7, 31, 174, 87, 37, 249 }, new byte[] { 184, 150, 200, 252, 217, 98, 187, 170, 66, 246, 46, 78, 14, 4, 93, 56, 173, 44, 188, 228, 156, 138, 132, 247, 98, 214, 97, 220, 3, 128, 77, 128, 126, 231, 209, 104, 139, 124, 104, 50, 61, 11, 247, 113, 149, 242, 150, 250, 119, 141, 112, 247, 155, 187, 207, 73, 66, 225, 123, 71, 156, 180, 118, 88, 244, 201, 46, 131, 173, 155, 125, 231, 168, 213, 213, 187, 239, 157, 24, 245, 28, 171, 212, 79, 165, 187, 193, 170, 9, 47, 50, 167, 10, 161, 143, 243, 85, 243, 60, 231, 95, 130, 146, 159, 165, 131, 152, 12, 134, 170, 205, 175, 232, 230, 178, 141, 177, 147, 43, 136, 129, 58, 27, 189, 66, 108, 201, 93 }, new Guid("e04b19e5-9503-4d7b-afed-667b55e5b6d1") });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2022, 7, 23, 15, 10, 33, 957, DateTimeKind.Local).AddTicks(7047), new byte[] { 203, 118, 128, 141, 193, 235, 163, 168, 249, 144, 166, 212, 154, 19, 208, 141, 121, 109, 98, 82, 111, 251, 79, 44, 24, 179, 64, 253, 125, 182, 78, 167, 251, 103, 27, 119, 192, 143, 40, 63, 139, 22, 211, 114, 39, 75, 145, 130, 156, 121, 62, 65, 241, 151, 92, 174, 139, 101, 7, 31, 174, 87, 37, 249 }, new byte[] { 184, 150, 200, 252, 217, 98, 187, 170, 66, 246, 46, 78, 14, 4, 93, 56, 173, 44, 188, 228, 156, 138, 132, 247, 98, 214, 97, 220, 3, 128, 77, 128, 126, 231, 209, 104, 139, 124, 104, 50, 61, 11, 247, 113, 149, 242, 150, 250, 119, 141, 112, 247, 155, 187, 207, 73, 66, 225, 123, 71, 156, 180, 118, 88, 244, 201, 46, 131, 173, 155, 125, 231, 168, 213, 213, 187, 239, 157, 24, 245, 28, 171, 212, 79, 165, 187, 193, 170, 9, 47, 50, 167, 10, 161, 143, 243, 85, 243, 60, 231, 95, 130, 146, 159, 165, 131, 152, 12, 134, 170, 205, 175, 232, 230, 178, 141, 177, 147, 43, 136, 129, 58, 27, 189, 66, 108, 201, 93 }, new Guid("8d7b733c-653d-4e3a-813f-76764dc95c6e") });
        }
    }
}
