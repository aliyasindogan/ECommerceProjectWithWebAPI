using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddPageTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PagePermissons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserTypeID = table.Column<int>(type: "int", nullable: false),
                    PageID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagePermissons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PageURL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    PageSeoURL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PageTypeID = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_PageTypes_PageTypeID",
                        column: x => x.PageTypeID,
                        principalSchema: "dbo",
                        principalTable: "PageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2022, 12, 18, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(5430), new byte[] { 20, 49, 145, 104, 84, 24, 122, 135, 235, 148, 61, 163, 29, 88, 241, 87, 154, 189, 156, 95, 1, 170, 94, 86, 29, 235, 203, 225, 147, 179, 2, 233, 178, 248, 176, 249, 108, 207, 183, 161, 210, 106, 190, 68, 79, 63, 181, 51, 237, 150, 83, 4, 229, 137, 70, 202, 230, 211, 47, 94, 121, 179, 183, 2 }, new byte[] { 129, 148, 24, 92, 87, 27, 245, 144, 159, 101, 214, 96, 207, 106, 242, 101, 192, 214, 225, 203, 30, 188, 165, 96, 148, 199, 104, 13, 24, 104, 21, 192, 187, 113, 154, 129, 10, 243, 179, 140, 171, 99, 227, 178, 140, 31, 76, 121, 187, 219, 141, 109, 106, 6, 41, 53, 84, 210, 123, 61, 208, 60, 121, 69, 47, 228, 142, 42, 105, 211, 223, 70, 145, 221, 171, 121, 214, 169, 95, 222, 209, 193, 201, 118, 60, 2, 166, 42, 141, 141, 176, 150, 121, 0, 45, 163, 95, 160, 126, 219, 38, 246, 201, 34, 68, 239, 246, 107, 186, 10, 246, 196, 36, 68, 190, 83, 18, 179, 102, 121, 207, 94, 48, 107, 169, 86, 61, 231 }, new Guid("2498780c-0b61-4549-a3a2-0f2ded4207f3") });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PageTypes",
                columns: new[] { "Id", "IsActive", "PageTypeName" },
                values: new object[] { 2, true, "Web" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PageTypes",
                columns: new[] { "Id", "IsActive", "PageTypeName" },
                values: new object[] { 1, true, "Admin" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Pages",
                columns: new[] { "Id", "DisplayOrder", "IsActive", "MetaDescription", "MetaKeywords", "MetaTitle", "PageName", "PageSeoURL", "PageTypeID", "PageURL", "ParentID" },
                values: new object[,]
                {
                    { 1, 1, true, "", "", "", "Sistem Ayarları", "", 1, "#", null },
                    { 2, 1, true, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUsers/List", 1 },
                    { 3, 1, true, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserTypes/List", 1 },
                    { 4, 1, true, "", "", "", "Sayfalar", "", 1, "/Admin/Pages/List", 1 },
                    { 5, 1, true, "", "", "", "Sayfa Yetkileri", "", 1, "/Admin/PagePermissons/List", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pages_PageTypeID",
                schema: "dbo",
                table: "Pages",
                column: "PageTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagePermissons");

            migrationBuilder.DropTable(
                name: "Pages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PageTypes",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2022, 12, 18, 16, 6, 47, 344, DateTimeKind.Local).AddTicks(5401), new byte[] { 62, 73, 37, 135, 19, 209, 35, 54, 22, 219, 198, 20, 3, 167, 111, 51, 5, 121, 51, 35, 97, 45, 0, 80, 147, 123, 99, 168, 121, 100, 194, 246, 217, 139, 134, 16, 190, 46, 179, 50, 152, 149, 201, 80, 255, 101, 117, 92, 237, 131, 64, 128, 155, 84, 36, 100, 17, 122, 239, 234, 180, 56, 181, 98 }, new byte[] { 13, 163, 43, 29, 128, 31, 125, 114, 140, 253, 98, 47, 214, 8, 176, 89, 97, 47, 152, 61, 245, 53, 110, 26, 18, 13, 129, 240, 201, 114, 38, 21, 148, 175, 93, 4, 46, 144, 91, 76, 14, 91, 17, 207, 197, 205, 202, 82, 202, 88, 70, 28, 159, 42, 149, 45, 170, 63, 196, 193, 25, 137, 232, 79, 87, 196, 226, 123, 121, 38, 178, 7, 65, 156, 101, 109, 110, 217, 229, 161, 167, 180, 161, 106, 90, 209, 184, 234, 226, 36, 207, 139, 66, 123, 197, 104, 243, 250, 4, 199, 180, 199, 247, 238, 189, 134, 56, 31, 114, 205, 143, 39, 145, 139, 130, 48, 23, 22, 70, 229, 215, 61, 35, 129, 160, 213, 87, 126 }, new Guid("f305154d-9e29-4aef-9837-8a13ed761294") });
        }
    }
}
