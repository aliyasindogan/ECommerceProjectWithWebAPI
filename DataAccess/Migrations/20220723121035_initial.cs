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
                values: new object[,]
                {
                    { 1, "AppUser" },
                    { 2, "AppUserTypeAppOperationClaim" },
                    { 3, "AppUserType" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypes",
                columns: new[] { "Id", "UserTypeName" },
                values: new object[,]
                {
                    { -1, "System Admin" },
                    { -2, "Admin" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUsers",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "Email", "FirstName", "GsmNumber", "IsDeleted", "LastName", "PasswordHash", "PasswordSalt", "ProfileImageUrl", "RefreshToken", "UpdatedDate", "UpdatedUserId", "UserName", "UserTypeId" },
                values: new object[,]
                {
                    { -1, new DateTime(2022, 7, 23, 15, 10, 33, 957, DateTimeKind.Local).AddTicks(7047), 1, null, null, "ali@gmail.com", "Ali Yasin", "", false, "Doğan", new byte[] { 203, 118, 128, 141, 193, 235, 163, 168, 249, 144, 166, 212, 154, 19, 208, 141, 121, 109, 98, 82, 111, 251, 79, 44, 24, 179, 64, 253, 125, 182, 78, 167, 251, 103, 27, 119, 192, 143, 40, 63, 139, 22, 211, 114, 39, 75, 145, 130, 156, 121, 62, 65, 241, 151, 92, 174, 139, 101, 7, 31, 174, 87, 37, 249 }, new byte[] { 184, 150, 200, 252, 217, 98, 187, 170, 66, 246, 46, 78, 14, 4, 93, 56, 173, 44, 188, 228, 156, 138, 132, 247, 98, 214, 97, 220, 3, 128, 77, 128, 126, 231, 209, 104, 139, 124, 104, 50, 61, 11, 247, 113, 149, 242, 150, 250, 119, 141, 112, 247, 155, 187, 207, 73, 66, 225, 123, 71, 156, 180, 118, 88, 244, 201, 46, 131, 173, 155, 125, 231, 168, 213, 213, 187, 239, 157, 24, 245, 28, 171, 212, 79, 165, 187, 193, 170, 9, 47, 50, 167, 10, 161, 143, 243, 85, 243, 60, 231, 95, 130, 146, 159, 165, 131, 152, 12, 134, 170, 205, 175, 232, 230, 178, 141, 177, 147, 43, 136, 129, 58, 27, 189, 66, 108, 201, 93 }, "", new Guid("8d7b733c-653d-4e3a-813f-76764dc95c6e"), null, null, "aliyasin", -1 },
                    { -2, new DateTime(2022, 7, 23, 15, 10, 33, 961, DateTimeKind.Local).AddTicks(1332), 1, null, null, "admin@gmail.com", "Admin", "", false, "ADMIN", new byte[] { 203, 118, 128, 141, 193, 235, 163, 168, 249, 144, 166, 212, 154, 19, 208, 141, 121, 109, 98, 82, 111, 251, 79, 44, 24, 179, 64, 253, 125, 182, 78, 167, 251, 103, 27, 119, 192, 143, 40, 63, 139, 22, 211, 114, 39, 75, 145, 130, 156, 121, 62, 65, 241, 151, 92, 174, 139, 101, 7, 31, 174, 87, 37, 249 }, new byte[] { 184, 150, 200, 252, 217, 98, 187, 170, 66, 246, 46, 78, 14, 4, 93, 56, 173, 44, 188, 228, 156, 138, 132, 247, 98, 214, 97, 220, 3, 128, 77, 128, 126, 231, 209, 104, 139, 124, 104, 50, 61, 11, 247, 113, 149, 242, 150, 250, 119, 141, 112, 247, 155, 187, 207, 73, 66, 225, 123, 71, 156, 180, 118, 88, 244, 201, 46, 131, 173, 155, 125, 231, 168, 213, 213, 187, 239, 157, 24, 245, 28, 171, 212, 79, 165, 187, 193, 170, 9, 47, 50, 167, 10, 161, 143, 243, 85, 243, 60, 231, 95, 130, 146, 159, 165, 131, 152, 12, 134, 170, 205, 175, 232, 230, 178, 141, 177, 147, 43, 136, 129, 58, 27, 189, 66, 108, 201, 93 }, "", new Guid("e04b19e5-9503-4d7b-afed-667b55e5b6d1"), null, null, "admin", -2 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "Status", "UpdatedDate", "UpdatedUserId", "UserTypeId" },
                values: new object[] { -1, 1, "1011", null, null, -2 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "Status", "UpdatedDate", "UpdatedUserId", "UserTypeId" },
                values: new object[] { -2, 2, "1111", null, null, -2 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "Status", "UpdatedDate", "UpdatedUserId", "UserTypeId" },
                values: new object[] { -3, 3, "1111", null, null, -2 });

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
                name: "AppUsers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppUserTypeAppOperationClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppOperationClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppUserTypes",
                schema: "dbo");
        }
    }
}
