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
                    PageURL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    PageTypeID = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                name: "PageLanguages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageID = table.Column<int>(type: "int", nullable: false),
                    PageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PageSeoURL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    LanguageID = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PageLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageLanguages_Languages_LanguageID",
                        column: x => x.LanguageID,
                        principalSchema: "dbo",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageLanguages_Pages_PageID",
                        column: x => x.PageID,
                        principalSchema: "dbo",
                        principalTable: "Pages",
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
                    { -1, new DateTime(2023, 8, 22, 14, 14, 26, 599, DateTimeKind.Local).AddTicks(3309), -1, null, null, true, false, null, null, "System Admin" },
                    { -2, new DateTime(2023, 8, 22, 14, 14, 26, 599, DateTimeKind.Local).AddTicks(3879), -1, null, null, true, false, null, null, "Admin" }
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
                values: new object[] { -1, new DateTime(2023, 8, 22, 14, 14, 26, 590, DateTimeKind.Local).AddTicks(5461), 1, null, null, "sadmin@gmail.com", "System", "", true, false, "Admin", new byte[] { 146, 239, 59, 134, 52, 177, 208, 142, 143, 15, 3, 142, 126, 190, 200, 134, 202, 181, 75, 177, 189, 63, 81, 6, 239, 1, 160, 6, 99, 231, 31, 140, 176, 120, 182, 183, 91, 224, 86, 81, 113, 73, 247, 193, 16, 189, 137, 48, 64, 172, 246, 33, 102, 178, 63, 133, 33, 183, 45, 2, 111, 230, 248, 210 }, new byte[] { 186, 117, 177, 11, 169, 123, 241, 123, 68, 74, 157, 33, 36, 241, 242, 191, 228, 205, 204, 128, 211, 3, 18, 244, 83, 11, 55, 36, 255, 92, 122, 239, 181, 253, 104, 222, 95, 112, 80, 249, 121, 154, 22, 163, 36, 93, 57, 48, 93, 32, 3, 191, 204, 96, 154, 43, 84, 97, 141, 81, 48, 80, 92, 161, 151, 155, 218, 105, 0, 161, 13, 35, 200, 252, 30, 73, 68, 218, 181, 134, 111, 203, 135, 67, 175, 104, 239, 94, 210, 240, 169, 133, 13, 239, 105, 115, 24, 60, 253, 8, 31, 9, 34, 114, 64, 150, 128, 16, 170, 222, 185, 208, 79, 110, 5, 139, 176, 15, 167, 129, 205, 52, 34, 161, 151, 183, 48, 12 }, "", new Guid("bc0ebbcb-c7b0-4bef-a7e4-40fd0b01e9df"), null, null, "sadmin", -1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Pages",
                columns: new[] { "Id", "DisplayOrder", "IsActive", "PageTypeID", "PageURL", "ParentID" },
                values: new object[,]
                {
                    { 19, 1, true, 1, "/Admin/Product/List", 18 },
                    { 20, 1, false, 1, "/Admin/Product/Add", 19 },
                    { 21, 1, false, 1, "/Admin/Product/Update", 19 },
                    { 22, 1, false, 1, "/Admin/Product/Delete", 19 },
                    { 23, 1, false, 1, "/Admin/Product/Detail", 19 },
                    { 24, 1, true, 1, "/Admin/ProductType/List", 18 },
                    { 18, 1, true, 1, "#", null },
                    { 25, 1, false, 1, "/Admin/ProductType/Add", 24 },
                    { 27, 1, false, 1, "/Admin/ProductType/Delete", 24 },
                    { 28, 1, false, 1, "/Admin/ProductType/Detail", 24 },
                    { 29, 2, true, 1, "#", null },
                    { 31, 1, true, 1, "/Admin/Contact/List", 29 },
                    { 32, 1, false, 1, "/Admin/Contact/Add", 30 },
                    { 33, 1, false, 1, "/Admin/Contact/Update", 30 },
                    { 26, 1, false, 1, "/Admin/ProductType/Update", 24 },
                    { 34, 1, false, 1, "/Admin/Contact/Delete", 30 },
                    { 17, 1, true, 1, "/Admin/PagePermisson/List", 1 },
                    { 15, 1, false, 1, "/Admin/Page/Delete", 12 },
                    { 1, 3, true, 1, "#", null },
                    { 2, 1, true, 1, "/Admin/AppUser/List", 1 },
                    { 3, 1, false, 1, "/Admin/AppUser/Add", 2 },
                    { 4, 1, false, 1, "/Admin/AppUser/Update", 2 },
                    { 5, 1, false, 1, "/Admin/AppUser/Delete", 2 },
                    { 6, 1, false, 1, "/Admin/AppUser/Detail", 2 },
                    { 16, 1, false, 1, "/Admin/Page/Detail", 12 },
                    { 7, 1, true, 1, "/Admin/AppUserType/List", 1 },
                    { 9, 1, false, 1, "/Admin/AppUserType/Update", 7 },
                    { 10, 1, false, 1, "/Admin/AppUserType/Delete", 7 },
                    { 11, 1, false, 1, "/Admin/AppUserType/Detail", 7 },
                    { 12, 1, true, 1, "/Admin/Page/List", 1 },
                    { 13, 1, false, 1, "/Admin/Page/Add", 12 },
                    { 14, 1, false, 1, "/Admin/Page/Update", 12 },
                    { 8, 1, false, 1, "/Admin/AppUserType/Add", 7 },
                    { 35, 1, false, 1, "/Admin/Contact/Detail", 30 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PageLanguages",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "IsActive", "IsDeleted", "LanguageID", "MetaDescription", "MetaKeywords", "MetaTitle", "PageID", "PageName", "PageSeoURL", "UpdatedDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 22, 14, 14, 26, 619, DateTimeKind.Local).AddTicks(9272), -1, null, null, true, false, 1, "", "", "", 1, "Sistem Ayarları", "", null, null },
                    { 15, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3840), -1, null, null, false, false, 1, "", "", "", 15, "Sayfalar", "", null, null },
                    { 16, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3844), -1, null, null, false, false, 1, "", "", "", 16, "Sayfalar", "", null, null },
                    { 17, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3848), -1, null, null, true, false, 1, "", "", "", 17, "Sayfa Yetkileri", "", null, null },
                    { 18, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3852), -1, null, null, true, false, 1, "", "", "", 18, "Ürün", "", null, null },
                    { 19, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3856), -1, null, null, true, false, 1, "", "", "", 19, "Ürünler", "", null, null },
                    { 20, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3860), -1, null, null, false, false, 1, "", "", "", 20, "Ürünler", "", null, null },
                    { 21, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3865), -1, null, null, false, false, 1, "", "", "", 21, "Ürünler", "", null, null },
                    { 22, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3869), -1, null, null, false, false, 1, "", "", "", 22, "Ürünler", "", null, null },
                    { 14, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3835), -1, null, null, false, false, 1, "", "", "", 14, "Sayfalar", "", null, null },
                    { 23, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3873), -1, null, null, false, false, 1, "", "", "", 23, "Ürünler", "", null, null },
                    { 25, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3881), -1, null, null, false, false, 1, "", "", "", 25, "Ürün Tipleri", "", null, null },
                    { 26, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3885), -1, null, null, false, false, 1, "", "", "", 26, "Ürün Tipleri", "", null, null },
                    { 27, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3889), -1, null, null, false, false, 1, "", "", "", 27, "Ürün Tipleri", "", null, null },
                    { 28, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3893), -1, null, null, false, false, 1, "", "", "", 28, "Ürün Tipleri", "", null, null },
                    { 29, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3897), -1, null, null, true, false, 1, "", "", "", 29, "Genel Sayfalar", "", null, null },
                    { 31, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3901), -1, null, null, true, false, 1, "", "", "", 31, "Hakkımızda", "", null, null },
                    { 32, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3905), -1, null, null, false, false, 1, "", "", "", 32, "Hakkımızda", "", null, null },
                    { 33, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3909), -1, null, null, false, false, 1, "", "", "", 33, "Hakkımızda", "", null, null },
                    { 24, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3877), -1, null, null, true, false, 1, "", "", "", 24, "Ürün Tipleri", "", null, null },
                    { 13, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3831), -1, null, null, false, false, 1, "", "", "", 13, "Sayfalar", "", null, null },
                    { 12, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3827), -1, null, null, true, false, 1, "", "", "", 12, "Sayfalar", "", null, null },
                    { 35, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3917), -1, null, null, false, false, 1, "", "", "", 35, "Hakkımızda", "", null, null },
                    { 11, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3823), -1, null, null, false, false, 1, "", "", "", 11, "Kullanıcı Tipleri", "", null, null },
                    { 2, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3629), -1, null, null, true, false, 1, "", "", "", 2, "Kullanıcılar", "", null, null },
                    { 10, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3819), -1, null, null, false, false, 1, "", "", "", 10, "Kullanıcı Tipleri", "", null, null },
                    { 9, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3814), -1, null, null, false, false, 1, "", "", "", 9, "Kullanıcı Tipleri", "", null, null },
                    { 3, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3783), -1, null, null, false, false, 1, "", "", "", 3, "Kullanıcılar", "", null, null },
                    { 8, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3809), -1, null, null, false, false, 1, "", "", "", 8, "Kullanıcı Tipleri", "", null, null },
                    { 7, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3805), -1, null, null, true, false, 1, "", "", "", 7, "Kullanıcı Tipleri", "", null, null },
                    { 34, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3913), -1, null, null, false, false, 1, "", "", "", 34, "Hakkımızda", "", null, null },
                    { 6, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3800), -1, null, null, false, false, 1, "", "", "", 6, "Kullanıcılar", "", null, null },
                    { 4, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3792), -1, null, null, false, false, 1, "", "", "", 4, "Kullanıcılar", "", null, null },
                    { 5, new DateTime(2023, 8, 22, 14, 14, 26, 620, DateTimeKind.Local).AddTicks(3796), -1, null, null, false, false, 1, "", "", "", 5, "Kullanıcılar", "", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PagePermissons",
                columns: new[] { "Id", "AppOperationClaimId", "AppUserTypeId", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "IsActive", "IsDeleted", "OperationClaimID", "PageID", "UpdatedDate", "UpdatedUserId", "UserTypeID" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, true, false, 1, 2, null, null, 2 },
                    { 2, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, true, false, 1, 3, null, null, 2 },
                    { 5, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, true, false, 1, 6, null, null, 2 },
                    { 4, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, true, false, 1, 5, null, null, 2 },
                    { 6, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, true, false, 1, 7, null, null, 2 },
                    { 7, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, true, false, 1, 8, null, null, 2 },
                    { 8, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, true, false, 1, 9, null, null, 2 },
                    { 9, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, true, false, 1, 10, null, null, 2 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PagePermissons",
                columns: new[] { "Id", "AppOperationClaimId", "AppUserTypeId", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "IsActive", "IsDeleted", "OperationClaimID", "PageID", "UpdatedDate", "UpdatedUserId", "UserTypeID" },
                values: new object[] { 3, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, true, false, 1, 4, null, null, 2 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PagePermissons",
                columns: new[] { "Id", "AppOperationClaimId", "AppUserTypeId", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "IsActive", "IsDeleted", "OperationClaimID", "PageID", "UpdatedDate", "UpdatedUserId", "UserTypeID" },
                values: new object[] { 10, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, true, false, 1, 11, null, null, 2 });

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
                name: "IX_PageLanguages_LanguageID",
                schema: "dbo",
                table: "PageLanguages",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_PageLanguages_PageID",
                schema: "dbo",
                table: "PageLanguages",
                column: "PageID");

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
                name: "PageLanguages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PagePermissons",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Languages",
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
