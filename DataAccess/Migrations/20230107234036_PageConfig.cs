using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class PageConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "PagePermissons",
                newName: "PagePermissons",
                newSchema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2023, 1, 8, 2, 40, 35, 554, DateTimeKind.Local).AddTicks(6916), new byte[] { 246, 12, 40, 158, 187, 122, 20, 78, 194, 126, 174, 26, 203, 218, 204, 251, 200, 51, 0, 66, 79, 49, 144, 240, 235, 120, 235, 250, 88, 139, 228, 70, 220, 135, 217, 23, 224, 207, 203, 159, 214, 120, 7, 150, 247, 106, 203, 45, 202, 28, 89, 122, 248, 238, 148, 113, 132, 187, 140, 184, 36, 40, 169, 112 }, new byte[] { 38, 185, 172, 24, 254, 40, 76, 19, 118, 243, 19, 39, 233, 57, 214, 172, 213, 143, 129, 214, 89, 247, 225, 225, 133, 6, 172, 170, 142, 198, 251, 9, 249, 105, 200, 196, 195, 255, 42, 200, 65, 253, 90, 53, 252, 88, 12, 98, 189, 161, 192, 70, 71, 59, 240, 110, 126, 128, 31, 104, 91, 72, 138, 180, 193, 103, 175, 99, 89, 156, 86, 195, 24, 132, 144, 7, 199, 240, 242, 112, 193, 55, 214, 248, 169, 189, 43, 231, 66, 153, 15, 40, 46, 168, 215, 40, 101, 200, 71, 245, 41, 76, 42, 181, 125, 113, 182, 239, 1, 151, 255, 213, 149, 139, 222, 240, 78, 168, 63, 33, 25, 120, 184, 100, 1, 188, 234, 240 }, new Guid("c9503bd5-40dd-4e99-a475-9c45f8405aea") });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsActive", "PageName", "PageURL", "ParentID" },
                values: new object[] { false, "Kullanıcılar", "/Admin/AppUsers/Add", 2 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsActive", "PageName", "PageURL", "ParentID" },
                values: new object[] { false, "Kullanıcılar", "/Admin/AppUsers/Update", 2 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IsActive", "PageName", "PageURL", "ParentID" },
                values: new object[] { false, "Kullanıcılar", "/Admin/AppUsers/Delete", 2 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Pages",
                columns: new[] { "Id", "DisplayOrder", "IsActive", "MetaDescription", "MetaKeywords", "MetaTitle", "PageName", "PageSeoURL", "PageTypeID", "PageURL", "ParentID" },
                values: new object[,]
                {
                    { 35, 1, false, "", "", "", "Hakkımızda", "", 1, "/Admin/Contacts/Detail", 30 },
                    { 34, 1, false, "", "", "", "Hakkımızda", "", 1, "/Admin/Contacts/Delete", 30 },
                    { 33, 1, false, "", "", "", "Hakkımızda", "", 1, "/Admin/Contacts/Update", 30 },
                    { 32, 1, false, "", "", "", "Hakkımızda", "", 1, "/Admin/Contacts/Add", 30 },
                    { 31, 1, true, "", "", "", "Hakkımızda", "", 1, "/Admin/Contacts/List", 29 },
                    { 29, 1, true, "", "", "", "Genel Sayfalar", "", 1, "#", null },
                    { 28, 1, false, "", "", "", "Ürün Tipleri", "", 1, "/Admin/ProductTypes/Detail", 24 },
                    { 27, 1, false, "", "", "", "Ürün Tipleri", "", 1, "/Admin/ProductTypes/Delete", 24 },
                    { 26, 1, false, "", "", "", "Ürün Tipleri", "", 1, "/Admin/ProductTypes/Update", 24 },
                    { 25, 1, false, "", "", "", "Ürün Tipleri", "", 1, "/Admin/ProductTypes/Add", 24 },
                    { 24, 1, true, "", "", "", "Ürün Tipleri", "", 1, "/Admin/ProductTypes/List", 18 },
                    { 23, 1, false, "", "", "", "Ürünler", "", 1, "/Admin/Products/Detail", 19 },
                    { 22, 1, false, "", "", "", "Ürünler", "", 1, "/Admin/Products/Delete", 19 },
                    { 20, 1, false, "", "", "", "Ürünler", "", 1, "/Admin/Products/Add", 19 },
                    { 19, 1, true, "", "", "", "Ürünler", "", 1, "/Admin/Products/List", 18 },
                    { 18, 1, true, "", "", "", "Ürün", "", 1, "#", null },
                    { 17, 1, true, "", "", "", "Sayfa Yetkileri", "", 1, "/Admin/PagePermissons/List", 1 },
                    { 16, 1, false, "", "", "", "Sayfalar", "", 1, "/Admin/Pages/Detail", 12 },
                    { 15, 1, false, "", "", "", "Sayfalar", "", 1, "/Admin/Pages/Delete", 12 },
                    { 14, 1, false, "", "", "", "Sayfalar", "", 1, "/Admin/Pages/Update", 12 },
                    { 13, 1, false, "", "", "", "Sayfalar", "", 1, "/Admin/Pages/Add", 12 },
                    { 12, 1, true, "", "", "", "Sayfalar", "", 1, "/Admin/Pages/List", 1 },
                    { 11, 1, false, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserTypes/Detail", 7 },
                    { 10, 1, false, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserTypes/Delete", 7 },
                    { 9, 1, false, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserTypes/Update", 7 },
                    { 8, 1, false, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserTypes/Add", 7 },
                    { 7, 1, true, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserTypes/List", 1 },
                    { 21, 1, false, "", "", "", "Ürünler", "", 1, "/Admin/Products/Update", 19 },
                    { 6, 1, false, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUsers/Detail", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.RenameTable(
                name: "PagePermissons",
                schema: "dbo",
                newName: "PagePermissons");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 53, 50, 824, DateTimeKind.Local).AddTicks(6400), new byte[] { 126, 190, 78, 215, 118, 139, 169, 251, 211, 149, 103, 124, 128, 172, 32, 88, 3, 241, 192, 60, 237, 136, 206, 43, 96, 176, 73, 0, 78, 72, 10, 213, 188, 30, 9, 218, 161, 208, 241, 1, 71, 117, 7, 153, 166, 178, 188, 143, 201, 224, 23, 75, 91, 128, 184, 82, 88, 172, 10, 104, 68, 247, 25, 61 }, new byte[] { 163, 199, 110, 90, 104, 165, 89, 161, 25, 136, 41, 238, 96, 97, 92, 90, 213, 145, 173, 114, 52, 208, 97, 213, 188, 87, 99, 27, 122, 13, 218, 151, 55, 74, 159, 218, 81, 0, 120, 97, 131, 122, 96, 246, 210, 228, 22, 169, 108, 10, 75, 19, 164, 53, 37, 107, 106, 160, 247, 18, 132, 173, 128, 103, 248, 56, 65, 39, 139, 217, 40, 103, 174, 141, 186, 49, 98, 46, 233, 40, 214, 111, 253, 124, 153, 249, 4, 52, 75, 229, 187, 92, 76, 218, 211, 181, 20, 0, 17, 204, 239, 205, 88, 250, 161, 46, 255, 148, 200, 213, 52, 60, 29, 165, 139, 6, 96, 214, 75, 49, 84, 119, 76, 230, 237, 57, 194, 85 }, new Guid("1d502e9c-2693-4dee-adde-1f0126160316") });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsActive", "PageName", "PageURL", "ParentID" },
                values: new object[] { true, "Kullanıcı Tipleri", "/Admin/AppUserTypes/List", 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsActive", "PageName", "PageURL", "ParentID" },
                values: new object[] { true, "Sayfalar", "/Admin/Pages/List", 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Pages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IsActive", "PageName", "PageURL", "ParentID" },
                values: new object[] { true, "Sayfa Yetkileri", "/Admin/PagePermissons/List", 1 });
        }
    }
}
