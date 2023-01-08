using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class initial : Migration
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTypes", x => x.Id);
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
                values: new object[] { -1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, true, false, null, null, "System Admin" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUsers",
                columns: new[] { "Id", "AppUserTypeId", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "Email", "FirstName", "GsmNumber", "IsActive", "IsDeleted", "LastName", "PasswordHash", "PasswordSalt", "ProfileImageUrl", "RefreshToken", "UpdatedDate", "UpdatedUserId", "UserName", "UserTypeID" },
                values: new object[] { -1, null, new DateTime(2023, 1, 8, 4, 6, 18, 451, DateTimeKind.Local).AddTicks(6990), 1, null, null, "sadmin@gmail.com", "System", "", true, false, "Admin", new byte[] { 205, 51, 117, 241, 80, 186, 134, 199, 56, 72, 134, 212, 93, 20, 244, 104, 121, 24, 128, 202, 19, 120, 87, 148, 187, 139, 230, 135, 53, 255, 111, 245, 239, 38, 113, 4, 17, 64, 149, 217, 125, 59, 103, 130, 34, 77, 228, 8, 3, 196, 73, 211, 116, 178, 110, 106, 92, 239, 213, 229, 107, 176, 178, 204 }, new byte[] { 115, 155, 5, 104, 160, 152, 205, 197, 12, 46, 27, 77, 222, 253, 204, 185, 66, 233, 31, 154, 35, 133, 189, 49, 111, 168, 104, 39, 33, 238, 108, 12, 2, 108, 56, 241, 10, 165, 203, 101, 111, 187, 89, 75, 17, 141, 119, 105, 164, 32, 194, 112, 98, 248, 210, 212, 255, 5, 115, 25, 1, 121, 106, 180, 76, 27, 110, 54, 152, 158, 57, 33, 105, 33, 124, 251, 160, 6, 164, 28, 147, 140, 104, 146, 28, 210, 220, 83, 154, 2, 201, 29, 20, 139, 129, 25, 160, 14, 164, 146, 60, 113, 48, 234, 22, 235, 82, 50, 217, 247, 181, 183, 227, 94, 136, 147, 165, 116, 127, 45, 45, 125, 134, 121, 194, 33, 174, 239 }, "", new Guid("59f1cb02-a792-4fa7-af08-173b6c039354"), null, null, "sadmin", -1 });

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
                    { 1, 1, true, "", "", "", "Sistem Ayarları", "", 1, "#", null },
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
                    { 21, 1, false, "", "", "", "Ürünler", "", 1, "/Admin/Products/Update", 19 },
                    { 20, 1, false, "", "", "", "Ürünler", "", 1, "/Admin/Products/Add", 19 },
                    { 19, 1, true, "", "", "", "Ürünler", "", 1, "/Admin/Products/List", 18 },
                    { 18, 1, true, "", "", "", "Ürün", "", 1, "#", null },
                    { 17, 1, true, "", "", "", "Sayfa Yetkileri", "", 1, "/Admin/PagePermissons/List", 1 },
                    { 16, 1, false, "", "", "", "Sayfalar", "", 1, "/Admin/Pages/Detail", 12 },
                    { 2, 1, true, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUsers/List", 1 },
                    { 3, 1, false, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUsers/Add", 2 },
                    { 4, 1, false, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUsers/Update", 2 },
                    { 5, 1, false, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUsers/Delete", 2 },
                    { 6, 1, false, "", "", "", "Kullanıcılar", "", 1, "/Admin/AppUsers/Detail", 2 },
                    { 7, 1, true, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserTypes/List", 1 },
                    { 34, 1, false, "", "", "", "Hakkımızda", "", 1, "/Admin/Contacts/Delete", 30 },
                    { 8, 1, false, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserTypes/Add", 7 },
                    { 10, 1, false, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserTypes/Delete", 7 },
                    { 11, 1, false, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserTypes/Detail", 7 },
                    { 12, 1, true, "", "", "", "Sayfalar", "", 1, "/Admin/Pages/List", 1 },
                    { 13, 1, false, "", "", "", "Sayfalar", "", 1, "/Admin/Pages/Add", 12 },
                    { 14, 1, false, "", "", "", "Sayfalar", "", 1, "/Admin/Pages/Update", 12 },
                    { 15, 1, false, "", "", "", "Sayfalar", "", 1, "/Admin/Pages/Delete", 12 },
                    { 9, 1, false, "", "", "", "Kullanıcı Tipleri", "", 1, "/Admin/AppUserTypes/Update", 7 },
                    { 35, 1, false, "", "", "", "Hakkımızda", "", 1, "/Admin/Contacts/Detail", 30 }
                });

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
