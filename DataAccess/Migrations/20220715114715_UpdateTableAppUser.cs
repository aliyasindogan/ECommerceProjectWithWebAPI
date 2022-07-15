using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateTableAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserTypeAppOperationClaims_AppUsers_AppUserId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims");

            migrationBuilder.DropIndex(
                name: "IX_AppUserTypeAppOperationClaims_AppUserId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppOperationClaims",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "AppUserTypeAppOperationClaim" },
                    { 3, "AppUserType" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                keyColumn: "Id",
                keyValue: -1,
                column: "UserTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2022, 7, 15, 14, 47, 14, 153, DateTimeKind.Local).AddTicks(2127), new byte[] { 80, 132, 110, 179, 236, 9, 253, 177, 22, 153, 183, 26, 186, 195, 7, 87, 103, 206, 120, 233, 9, 194, 35, 134, 190, 35, 97, 97, 44, 150, 247, 78, 32, 241, 108, 118, 195, 208, 188, 213, 76, 251, 60, 127, 173, 215, 216, 12, 183, 150, 72, 132, 236, 218, 198, 35, 239, 171, 74, 92, 241, 17, 139, 106 }, new byte[] { 182, 3, 95, 30, 6, 183, 218, 36, 136, 32, 44, 72, 30, 25, 37, 231, 176, 159, 136, 13, 188, 102, 32, 58, 87, 148, 99, 231, 207, 94, 134, 91, 229, 111, 123, 250, 136, 30, 14, 50, 140, 194, 224, 41, 126, 154, 228, 30, 184, 206, 77, 159, 85, 89, 149, 109, 80, 50, 158, 123, 195, 88, 147, 55, 103, 73, 121, 239, 4, 69, 218, 127, 146, 171, 104, 1, 183, 101, 20, 99, 77, 1, 254, 116, 62, 191, 227, 85, 180, 72, 71, 69, 112, 226, 170, 138, 85, 97, 217, 173, 201, 173, 128, 204, 158, 74, 236, 222, 249, 183, 244, 13, 229, 89, 105, 105, 134, 170, 34, 245, 103, 189, 218, 213, 150, 254, 197, 230 }, new Guid("352e2e2f-051d-437e-929f-e489677113ba") });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "Status", "UpdatedDate", "UpdatedUserId", "UserTypeId" },
                values: new object[] { -2, 2, "1111", null, null, 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "Status", "UpdatedDate", "UpdatedUserId", "UserTypeId" },
                values: new object[] { -3, 3, "1111", null, null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AppOperationClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AppOperationClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                keyColumn: "Id",
                keyValue: -1,
                column: "UserTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2022, 3, 25, 23, 8, 13, 960, DateTimeKind.Local).AddTicks(4912), new byte[] { 2, 42, 139, 34, 254, 191, 85, 175, 99, 175, 5, 104, 21, 179, 125, 97, 248, 136, 228, 52, 30, 172, 134, 242, 73, 93, 143, 242, 114, 204, 206, 202, 197, 223, 248, 181, 139, 178, 99, 197, 136, 77, 113, 75, 138, 234, 109, 131, 37, 27, 3, 83, 208, 95, 58, 192, 151, 15, 8, 41, 44, 226, 29, 101 }, new byte[] { 244, 183, 176, 211, 117, 75, 181, 109, 2, 213, 84, 57, 107, 21, 17, 56, 76, 207, 91, 97, 250, 138, 253, 181, 21, 244, 173, 246, 123, 184, 69, 24, 67, 179, 36, 103, 173, 100, 240, 73, 17, 26, 114, 123, 172, 97, 170, 110, 215, 46, 153, 79, 138, 94, 209, 127, 90, 26, 35, 28, 236, 14, 145, 202, 177, 31, 115, 81, 106, 141, 6, 238, 208, 195, 172, 149, 17, 188, 50, 33, 2, 0, 166, 43, 176, 120, 23, 25, 184, 231, 158, 187, 247, 131, 124, 0, 236, 109, 184, 15, 6, 101, 129, 241, 5, 45, 6, 36, 230, 7, 95, 21, 27, 254, 237, 181, 89, 115, 8, 199, 103, 114, 236, 90, 67, 220, 86, 233 }, new Guid("b4489d7f-739a-435f-a645-95ec5aa7739c") });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTypeAppOperationClaims_AppUserId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserTypeAppOperationClaims_AppUsers_AppUserId",
                schema: "dbo",
                table: "AppUserTypeAppOperationClaims",
                column: "AppUserId",
                principalSchema: "dbo",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
