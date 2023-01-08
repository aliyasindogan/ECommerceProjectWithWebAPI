using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdatePageAndPageTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2023, 1, 8, 13, 29, 6, 301, DateTimeKind.Local).AddTicks(1372), new byte[] { 188, 7, 117, 163, 33, 138, 221, 93, 64, 207, 255, 218, 32, 146, 71, 48, 122, 83, 125, 5, 7, 222, 234, 195, 54, 124, 1, 85, 168, 215, 135, 44, 174, 232, 251, 25, 149, 141, 10, 196, 197, 159, 15, 54, 156, 48, 27, 99, 96, 42, 129, 30, 141, 179, 50, 171, 62, 246, 134, 192, 65, 137, 86, 40 }, new byte[] { 149, 146, 195, 17, 7, 214, 134, 219, 149, 164, 246, 181, 101, 249, 232, 187, 30, 246, 54, 166, 236, 118, 84, 217, 219, 240, 199, 91, 142, 128, 56, 253, 132, 121, 159, 248, 139, 167, 37, 15, 240, 48, 218, 212, 186, 198, 52, 221, 148, 81, 88, 156, 130, 40, 69, 49, 190, 66, 118, 134, 219, 142, 140, 108, 215, 207, 225, 76, 8, 216, 92, 240, 10, 243, 254, 32, 230, 224, 128, 105, 33, 76, 16, 142, 157, 249, 4, 120, 1, 252, 70, 80, 28, 202, 160, 177, 111, 150, 201, 250, 93, 26, 252, 143, 172, 167, 164, 91, 234, 135, 142, 105, 45, 248, 30, 30, 153, 221, 240, 192, 170, 199, 120, 102, 199, 60, 177, 134 }, new Guid("5eef6052-af0b-4ac5-9159-00ec4f2e1a8a") });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 1,
                column: "DisplayOrder",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 2,
                column: "PageURL",
                value: "/Admin/AppUser/List");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 3,
                column: "PageURL",
                value: "/Admin/AppUser/Add");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 4,
                column: "PageURL",
                value: "/Admin/AppUser/Update");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 5,
                column: "PageURL",
                value: "/Admin/AppUser/Delete");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 6,
                column: "PageURL",
                value: "/Admin/AppUser/Detail");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 7,
                column: "PageURL",
                value: "/Admin/AppUserType/List");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 8,
                column: "PageURL",
                value: "/Admin/AppUserType/Add");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 9,
                column: "PageURL",
                value: "/Admin/AppUserType/Update");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 10,
                column: "PageURL",
                value: "/Admin/AppUserType/Delete");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 11,
                column: "PageURL",
                value: "/Admin/AppUserType/Detail");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 12,
                column: "PageURL",
                value: "/Admin/Page/List");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 13,
                column: "PageURL",
                value: "/Admin/Page/Add");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 14,
                column: "PageURL",
                value: "/Admin/Page/Update");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 15,
                column: "PageURL",
                value: "/Admin/Page/Delete");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 16,
                column: "PageURL",
                value: "/Admin/Page/Detail");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 17,
                column: "PageURL",
                value: "/Admin/PagePermisson/List");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 19,
                column: "PageURL",
                value: "/Admin/Product/List");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 20,
                column: "PageURL",
                value: "/Admin/Product/Add");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 21,
                column: "PageURL",
                value: "/Admin/Product/Update");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 22,
                column: "PageURL",
                value: "/Admin/Product/Delete");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 23,
                column: "PageURL",
                value: "/Admin/Product/Detail");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 24,
                column: "PageURL",
                value: "/Admin/ProductType/List");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 25,
                column: "PageURL",
                value: "/Admin/ProductType/Add");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 26,
                column: "PageURL",
                value: "/Admin/ProductType/Update");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 27,
                column: "PageURL",
                value: "/Admin/ProductType/Delete");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 28,
                column: "PageURL",
                value: "/Admin/ProductType/Detail");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 29,
                column: "DisplayOrder",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 31,
                column: "PageURL",
                value: "/Admin/Contact/List");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 32,
                column: "PageURL",
                value: "/Admin/Contact/Add");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 33,
                column: "PageURL",
                value: "/Admin/Contact/Update");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 34,
                column: "PageURL",
                value: "/Admin/Contact/Delete");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 35,
                column: "PageURL",
                value: "/Admin/Contact/Detail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2023, 1, 8, 4, 6, 18, 451, DateTimeKind.Local).AddTicks(6990), new byte[] { 205, 51, 117, 241, 80, 186, 134, 199, 56, 72, 134, 212, 93, 20, 244, 104, 121, 24, 128, 202, 19, 120, 87, 148, 187, 139, 230, 135, 53, 255, 111, 245, 239, 38, 113, 4, 17, 64, 149, 217, 125, 59, 103, 130, 34, 77, 228, 8, 3, 196, 73, 211, 116, 178, 110, 106, 92, 239, 213, 229, 107, 176, 178, 204 }, new byte[] { 115, 155, 5, 104, 160, 152, 205, 197, 12, 46, 27, 77, 222, 253, 204, 185, 66, 233, 31, 154, 35, 133, 189, 49, 111, 168, 104, 39, 33, 238, 108, 12, 2, 108, 56, 241, 10, 165, 203, 101, 111, 187, 89, 75, 17, 141, 119, 105, 164, 32, 194, 112, 98, 248, 210, 212, 255, 5, 115, 25, 1, 121, 106, 180, 76, 27, 110, 54, 152, 158, 57, 33, 105, 33, 124, 251, 160, 6, 164, 28, 147, 140, 104, 146, 28, 210, 220, 83, 154, 2, 201, 29, 20, 139, 129, 25, 160, 14, 164, 146, 60, 113, 48, 234, 22, 235, 82, 50, 217, 247, 181, 183, 227, 94, 136, 147, 165, 116, 127, 45, 45, 125, 134, 121, 194, 33, 174, 239 }, new Guid("59f1cb02-a792-4fa7-af08-173b6c039354") });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 1,
                column: "DisplayOrder",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 2,
                column: "PageURL",
                value: "/Admin/AppUsers/List");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 3,
                column: "PageURL",
                value: "/Admin/AppUsers/Add");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 4,
                column: "PageURL",
                value: "/Admin/AppUsers/Update");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 5,
                column: "PageURL",
                value: "/Admin/AppUsers/Delete");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 6,
                column: "PageURL",
                value: "/Admin/AppUsers/Detail");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 7,
                column: "PageURL",
                value: "/Admin/AppUserTypes/List");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 8,
                column: "PageURL",
                value: "/Admin/AppUserTypes/Add");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 9,
                column: "PageURL",
                value: "/Admin/AppUserTypes/Update");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 10,
                column: "PageURL",
                value: "/Admin/AppUserTypes/Delete");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 11,
                column: "PageURL",
                value: "/Admin/AppUserTypes/Detail");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 12,
                column: "PageURL",
                value: "/Admin/Pages/List");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 13,
                column: "PageURL",
                value: "/Admin/Pages/Add");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 14,
                column: "PageURL",
                value: "/Admin/Pages/Update");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 15,
                column: "PageURL",
                value: "/Admin/Pages/Delete");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 16,
                column: "PageURL",
                value: "/Admin/Pages/Detail");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 17,
                column: "PageURL",
                value: "/Admin/PagePermissons/List");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 19,
                column: "PageURL",
                value: "/Admin/Products/List");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 20,
                column: "PageURL",
                value: "/Admin/Products/Add");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 21,
                column: "PageURL",
                value: "/Admin/Products/Update");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 22,
                column: "PageURL",
                value: "/Admin/Products/Delete");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 23,
                column: "PageURL",
                value: "/Admin/Products/Detail");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 24,
                column: "PageURL",
                value: "/Admin/ProductTypes/List");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 25,
                column: "PageURL",
                value: "/Admin/ProductTypes/Add");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 26,
                column: "PageURL",
                value: "/Admin/ProductTypes/Update");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 27,
                column: "PageURL",
                value: "/Admin/ProductTypes/Delete");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 28,
                column: "PageURL",
                value: "/Admin/ProductTypes/Detail");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 29,
                column: "DisplayOrder",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 31,
                column: "PageURL",
                value: "/Admin/Contacts/List");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 32,
                column: "PageURL",
                value: "/Admin/Contacts/Add");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 33,
                column: "PageURL",
                value: "/Admin/Contacts/Update");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 34,
                column: "PageURL",
                value: "/Admin/Contacts/Delete");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 35,
                column: "PageURL",
                value: "/Admin/Contacts/Detail");
        }
    }
}
