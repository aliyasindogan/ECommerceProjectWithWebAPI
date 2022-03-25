using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "AppOperationClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefreshToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTypeAppOperationClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "char(4)", maxLength: 4, nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTypeAppOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserTypeAppOperationClaims_AppOperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalSchema: "dbo",
                        principalTable: "AppOperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserTypeAppOperationClaims_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "dbo",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUserTypeAppOperationClaims_AppUserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalSchema: "dbo",
                        principalTable: "AppUserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppOperationClaims",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "AppUser" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypes",
                columns: new[] { "Id", "UserTypeName" },
                values: new object[,]
                {
                    { 1, "System Admin" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUsers",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "Email", "FirstName", "GsmNumber", "IsDeleted", "LastName", "PasswordHash", "PasswordSalt", "ProfileImageUrl", "RefreshToken", "UpdatedDate", "UpdatedUserId", "UserName", "UserTypeId" },
                values: new object[] { 1, new DateTime(2022, 3, 25, 23, 8, 13, 960, DateTimeKind.Local).AddTicks(4912), 1, null, null, "ali@gmail.com", "Ali Yasin", "", false, "Doğan", new byte[] { 2, 42, 139, 34, 254, 191, 85, 175, 99, 175, 5, 104, 21, 179, 125, 97, 248, 136, 228, 52, 30, 172, 134, 242, 73, 93, 143, 242, 114, 204, 206, 202, 197, 223, 248, 181, 139, 178, 99, 197, 136, 77, 113, 75, 138, 234, 109, 131, 37, 27, 3, 83, 208, 95, 58, 192, 151, 15, 8, 41, 44, 226, 29, 101 }, new byte[] { 244, 183, 176, 211, 117, 75, 181, 109, 2, 213, 84, 57, 107, 21, 17, 56, 76, 207, 91, 97, 250, 138, 253, 181, 21, 244, 173, 246, 123, 184, 69, 24, 67, 179, 36, 103, 173, 100, 240, 73, 17, 26, 114, 123, 172, 97, 170, 110, 215, 46, 153, 79, 138, 94, 209, 127, 90, 26, 35, 28, 236, 14, 145, 202, 177, 31, 115, 81, 106, 141, 6, 238, 208, 195, 172, 149, 17, 188, 50, 33, 2, 0, 166, 43, 176, 120, 23, 25, 184, 231, 158, 187, 247, 131, 124, 0, 236, 109, 184, 15, 6, 101, 129, 241, 5, 45, 6, 36, 230, 7, 95, 21, 27, 254, 237, 181, 89, 115, 8, 199, 103, 114, 236, 90, 67, 220, 86, 233 }, "", new Guid("b4489d7f-739a-435f-a645-95ec5aa7739c"), null, null, "aliyasin", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                columns: new[] { "Id", "AppUserId", "OperationClaimId", "Status", "UpdatedDate", "UpdatedUserId", "UserTypeId" },
                values: new object[] { -1, null, 1, "1111", null, null, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTypeAppOperationClaims_AppUserId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTypeAppOperationClaims_OperationClaimId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTypeAppOperationClaims_UserTypeId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserTypeAppOperationClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppOperationClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppUsers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppUserTypes",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 9, 0, 55, 13, 983, DateTimeKind.Local).AddTicks(7403)),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "CreatedUserId", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "Password", "UpdatedDate", "UpdatedUserId", "UserName" },
                values: new object[] { 1, "İSTANBUL", new DateTime(2021, 7, 9, 0, 55, 14, 0, DateTimeKind.Local).AddTicks(393), 1, new DateTime(1979, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali@gmail.com", "Ali Yasin", true, "Doğan", "12345", null, null, "aliyasin" });
        }
    }
}
