using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class first : Migration
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
                name: "Resources",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceValue = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ResourceGroup = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Languages_LanguageID",
                        column: x => x.LanguageID,
                        principalSchema: "dbo",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "AppUserTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceID = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_AppUserTypes_Resources_ResourceID",
                        column: x => x.ResourceID,
                        principalSchema: "dbo",
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserTypeId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_AppUsers_AppUserTypes_AppUserTypeId",
                        column: x => x.AppUserTypeId,
                        principalSchema: "dbo",
                        principalTable: "AppUserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                table: "AppUsers",
                columns: new[] { "Id", "AppUserTypeId", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "Email", "FirstName", "GsmNumber", "IsActive", "IsDeleted", "LastName", "PasswordHash", "PasswordSalt", "ProfileImageUrl", "RefreshToken", "UpdatedDate", "UpdatedUserId", "UserName", "UserTypeID" },
                values: new object[] { -1, null, new DateTime(2023, 1, 23, 2, 50, 15, 754, DateTimeKind.Local).AddTicks(1740), 1, null, null, "sadmin@gmail.com", "System", "", true, false, "Admin", new byte[] { 30, 103, 28, 48, 83, 172, 224, 90, 47, 49, 179, 113, 238, 94, 134, 47, 10, 156, 90, 3, 88, 238, 108, 228, 24, 15, 106, 105, 141, 35, 204, 160, 31, 246, 173, 234, 40, 127, 158, 200, 83, 38, 52, 114, 114, 191, 244, 174, 135, 21, 32, 127, 92, 154, 127, 126, 99, 250, 32, 29, 114, 159, 145, 154 }, new byte[] { 157, 104, 189, 34, 7, 26, 107, 102, 251, 32, 122, 19, 31, 13, 42, 6, 48, 0, 51, 253, 193, 124, 229, 81, 221, 32, 138, 42, 135, 70, 96, 65, 123, 34, 149, 178, 95, 148, 37, 47, 130, 62, 20, 94, 136, 212, 55, 160, 197, 78, 106, 237, 207, 64, 64, 222, 226, 67, 50, 226, 105, 52, 236, 236, 14, 93, 124, 11, 255, 50, 94, 223, 113, 47, 241, 187, 102, 80, 100, 124, 45, 153, 127, 9, 60, 224, 50, 206, 46, 169, 22, 113, 81, 123, 113, 237, 40, 174, 160, 198, 171, 91, 165, 119, 189, 66, 97, 150, 41, 162, 228, 21, 191, 38, 110, 202, 215, 83, 7, 231, 146, 198, 105, 29, 120, 161, 180, 97 }, "", new Guid("1380b524-0572-46fa-afc2-0f673554b660"), null, null, "sadmin", 1 });

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
                table: "Pages",
                columns: new[] { "Id", "DisplayOrder", "IsActive", "MetaDescription", "MetaKeywords", "MetaTitle", "PageName", "PageSeoURL", "PageTypeID", "PageURL", "ParentID" },
                values: new object[,]
                {
                    { 16, 1, false, "", "", "", "Sayfalar", "", 1, "/Admin/Page/Detail", 12 },
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
                    { 17, 1, true, "", "", "", "Sayfa Yetkileri", "", 1, "/Admin/PagePermisson/List", 1 },
                    { 35, 1, false, "", "", "", "Hakkımızda", "", 1, "/Admin/Contact/Detail", 30 },
                    { 15, 1, false, "", "", "", "Sayfalar", "", 1, "/Admin/Page/Delete", 12 },
                    { 1, 3, true, "", "", "", "Sistem Ayarları", "", 1, "#", null },
                    { 2, 1, true, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUser/List", 1 },
                    { 3, 1, false, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUser/Add", 2 },
                    { 4, 1, false, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUser/Update", 2 },
                    { 5, 1, false, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUser/Delete", 2 },
                    { 6, 1, false, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUser/Detail", 2 },
                    { 34, 1, false, "", "", "", "Hakkımızda", "", 1, "/Admin/Contact/Delete", 30 },
                    { 7, 1, true, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserType/List", 1 },
                    { 9, 1, false, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserType/Update", 7 },
                    { 10, 1, false, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserType/Delete", 7 },
                    { 11, 1, false, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserType/Detail", 7 },
                    { 12, 1, true, "", "", "", "Sayfalar", "", 1, "/Admin/Page/List", 1 },
                    { 13, 1, false, "", "", "", "Sayfalar", "", 1, "/Admin/Page/Add", 12 },
                    { 14, 1, false, "", "", "", "Sayfalar", "", 1, "/Admin/Page/Update", 12 },
                    { 8, 1, false, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserType/Add", 7 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Resources",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "IsActive", "IsDeleted", "LanguageID", "ResourceGroup", "ResourceValue", "UpdatedDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, true, false, 2, "AppUserType", "System Admin", null, null },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, true, false, 1, "AppUserType", "System Admin", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypes",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "IsActive", "IsDeleted", "ResourceID", "UpdatedDate", "UpdatedUserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, true, false, 1, null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypes",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "IsActive", "IsDeleted", "ResourceID", "UpdatedDate", "UpdatedUserId" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, true, false, 2, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_AppUserTypeId",
                schema: "dbo",
                table: "AppUsers",
                column: "AppUserTypeId");

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
                name: "IX_AppUserTypes_ResourceID",
                schema: "dbo",
                table: "AppUserTypes",
                column: "ResourceID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Resources_LanguageID",
                schema: "dbo",
                table: "Resources",
                column: "LanguageID");
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
                name: "Resources",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PageTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "dbo");
        }
    }
}
