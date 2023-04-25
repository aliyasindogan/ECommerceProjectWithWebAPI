using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AppOperationClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_AppUserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
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
                name: "AppUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    GsmNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    RefreshToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsers_AppUserTypes_UserTypeID",
                        column: x => x.UserTypeID,
                        principalSchema: "dbo",
                        principalTable: "AppUserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTypeAppOperationClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserTypeId = table.Column<int>(type: "int", nullable: true),
                    AppOperationClaimId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserTypeID = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "char(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTypeAppOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserTypeAppOperationClaims_AppOperationClaims_AppOperationClaimId",
                        column: x => x.AppOperationClaimId,
                        principalSchema: "dbo",
                        principalTable: "AppOperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUserTypeAppOperationClaims_AppUserTypes_AppUserTypeId",
                        column: x => x.AppUserTypeId,
                        principalSchema: "dbo",
                        principalTable: "AppUserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "PagePermissons",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeID = table.Column<int>(type: "int", nullable: false),
                    PageID = table.Column<int>(type: "int", nullable: false),
                    OperationClaimID = table.Column<int>(type: "int", nullable: false),
                    AppUserTypeId = table.Column<int>(type: "int", nullable: true),
                    AppOperationClaimId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_PagePermissons_AppOperationClaims_AppOperationClaimId",
                        column: x => x.AppOperationClaimId,
                        principalSchema: "dbo",
                        principalTable: "AppOperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagePermissons_AppUserTypes_AppUserTypeId",
                        column: x => x.AppUserTypeId,
                        principalSchema: "dbo",
                        principalTable: "AppUserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagePermissons_Pages_PageID",
                        column: x => x.PageID,
                        principalSchema: "dbo",
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppOperationClaims",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "AppUser" },
                    { 2, true, "AppUserType" },
                    { 3, true, "Page" },
                    { 4, true, "PageType" },
                    { 5, true, "Product" },
                    { 6, true, "ProductType" },
                    { 7, true, "Contact" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypes",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "IsActive", "IsDeleted", "UpdatedDate", "UpdatedUserId", "UserTypeName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 25, 19, 41, 11, 702, DateTimeKind.Local).AddTicks(2197), -1, null, null, true, false, null, null, "System Admin" },
                    { 2, new DateTime(2023, 4, 25, 19, 41, 11, 702, DateTimeKind.Local).AddTicks(2459), -1, null, null, true, false, null, null, "Admin" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Languages",
                columns: new[] { "Id", "DisplayOrder", "IsActive", "LanguageCode", "LanguageName" },
                values: new object[,]
                {
                    { 1, 1, true, "tr-TR", "Türkçe" },
                    { 2, 2, true, "en-EN", "English" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PageTypes",
                columns: new[] { "Id", "IsActive", "PageTypeName" },
                values: new object[,]
                {
                    { 1, true, "Admin" },
                    { 2, true, "Web" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUsers",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "Email", "FirstName", "GsmNumber", "IsActive", "IsDeleted", "LastName", "PasswordHash", "PasswordSalt", "ProfileImageUrl", "RefreshToken", "UpdatedDate", "UpdatedUserId", "UserName", "UserTypeID" },
                values: new object[] { -1, new DateTime(2023, 4, 25, 19, 41, 11, 696, DateTimeKind.Local).AddTicks(4355), 1, null, null, "sadmin@gmail.com", "System", "", true, false, "Admin", new byte[] { 111, 43, 247, 24, 169, 251, 238, 130, 22, 40, 11, 187, 211, 85, 231, 156, 206, 153, 74, 128, 142, 185, 147, 133, 102, 132, 11, 37, 11, 98, 45, 46, 142, 59, 207, 34, 68, 241, 30, 109, 43, 70, 173, 151, 253, 142, 148, 119, 126, 163, 209, 231, 136, 219, 250, 242, 241, 169, 233, 167, 22, 38, 123, 219 }, new byte[] { 208, 176, 236, 68, 69, 217, 116, 159, 240, 204, 195, 13, 1, 40, 100, 13, 149, 7, 106, 18, 91, 53, 139, 29, 28, 70, 163, 26, 155, 222, 204, 209, 75, 50, 123, 135, 187, 205, 136, 212, 210, 157, 187, 93, 112, 187, 24, 92, 83, 245, 171, 196, 199, 50, 110, 69, 127, 97, 78, 46, 228, 3, 31, 107, 218, 50, 231, 191, 89, 121, 217, 118, 38, 24, 226, 0, 221, 45, 7, 147, 46, 123, 101, 140, 73, 245, 124, 168, 224, 172, 199, 251, 61, 92, 111, 181, 113, 152, 195, 152, 223, 247, 122, 149, 54, 202, 156, 231, 17, 220, 154, 99, 154, 223, 114, 115, 151, 8, 172, 42, 8, 38, 8, 234, 84, 217, 24, 162 }, "", new Guid("f6a6dca3-0eb8-4291-ae5a-81dcab19af5d"), null, null, "sadmin", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Pages",
                columns: new[] { "Id", "DisplayOrder", "IsActive", "MetaDescription", "MetaKeywords", "MetaTitle", "PageName", "PageSeoURL", "PageTypeID", "PageURL", "ParentID" },
                values: new object[,]
                {
                    { 19, 1, true, "", "", "", "Ürünler", "", 1, "/Admin/Product/List", 18 },
                    { 20, 1, false, "", "", "", "Ürünler", "", 1, "/Admin/Product/Add", 19 },
                    { 21, 1, false, "", "", "", "Ürünler", "", 1, "/Admin/Product/Update", 19 },
                    { 22, 1, false, "", "", "", "Ürünler", "", 1, "/Admin/Product/Delete", 19 },
                    { 23, 1, false, "", "", "", "Ürünler", "", 1, "/Admin/Product/Detail", 19 },
                    { 24, 1, true, "", "", "", "Ürün Tipleri", "", 1, "/Admin/ProductType/List", 18 },
                    { 18, 1, true, "", "", "", "Ürün", "", 1, "#", null },
                    { 25, 1, false, "", "", "", "Ürün Tipleri", "", 1, "/Admin/ProductType/Add", 24 },
                    { 27, 1, false, "", "", "", "Ürün Tipleri", "", 1, "/Admin/ProductType/Delete", 24 },
                    { 28, 1, false, "", "", "", "Ürün Tipleri", "", 1, "/Admin/ProductType/Detail", 24 },
                    { 29, 2, true, "", "", "", "Genel Sayfalar", "", 1, "#", null },
                    { 31, 1, true, "", "", "", "Hakkımızda", "", 1, "/Admin/Contact/List", 29 },
                    { 32, 1, false, "", "", "", "Hakkımızda", "", 1, "/Admin/Contact/Add", 30 },
                    { 33, 1, false, "", "", "", "Hakkımızda", "", 1, "/Admin/Contact/Update", 30 },
                    { 26, 1, false, "", "", "", "Ürün Tipleri", "", 1, "/Admin/ProductType/Update", 24 },
                    { 34, 1, false, "", "", "", "Hakkımızda", "", 1, "/Admin/Contact/Delete", 30 },
                    { 17, 1, true, "", "", "", "Sayfa Yetkileri", "", 1, "/Admin/PagePermisson/List", 1 },
                    { 15, 1, false, "", "", "", "Sayfalar", "", 1, "/Admin/Page/Delete", 12 },
                    { 1, 3, true, "", "", "", "Sistem Ayarları", "", 1, "#", null },
                    { 2, 1, true, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUser/List", 1 },
                    { 3, 1, false, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUser/Add", 2 },
                    { 4, 1, false, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUser/Update", 2 },
                    { 5, 1, false, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUser/Delete", 2 },
                    { 6, 1, false, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUser/Detail", 2 },
                    { 16, 1, false, "", "", "", "Sayfalar", "", 1, "/Admin/Page/Detail", 12 },
                    { 7, 1, true, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserType/List", 1 },
                    { 9, 1, false, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserType/Update", 7 },
                    { 10, 1, false, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserType/Delete", 7 },
                    { 11, 1, false, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserType/Detail", 7 },
                    { 12, 1, true, "", "", "", "Sayfalar", "", 1, "/Admin/Page/List", 1 },
                    { 13, 1, false, "", "", "", "Sayfalar", "", 1, "/Admin/Page/Add", 12 },
                    { 14, 1, false, "", "", "", "Sayfalar", "", 1, "/Admin/Page/Update", 12 },
                    { 8, 1, false, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserType/Add", 7 },
                    { 35, 1, false, "", "", "", "Hakkımızda", "", 1, "/Admin/Contact/Detail", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_UserTypeID",
                schema: "dbo",
                table: "AppUsers",
                column: "UserTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTypeAppOperationClaims_AppOperationClaimId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                column: "AppOperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTypeAppOperationClaims_AppUserTypeId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                column: "AppUserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PagePermissons_AppOperationClaimId",
                schema: "dbo",
                table: "PagePermissons",
                column: "AppOperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_PagePermissons_AppUserTypeId",
                schema: "dbo",
                table: "PagePermissons",
                column: "AppUserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PagePermissons_PageID",
                schema: "dbo",
                table: "PagePermissons",
                column: "PageID");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_PageTypeID",
                schema: "dbo",
                table: "Pages",
                column: "PageTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppUserTypeAppOperationClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PagePermissons",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppOperationClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppUserTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Pages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PageTypes",
                schema: "dbo");
        }
    }
}
