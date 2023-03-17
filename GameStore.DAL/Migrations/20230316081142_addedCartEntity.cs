using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.DAL.Migrations
{
    public partial class addedCartEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0400fb39-16b3-45c3-ba41-c8be9eddf999");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46f7b525-2cfd-4517-9dc3-e3067914e46e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0900d2e-977b-4c04-8525-5e9ef2afb909");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78df3fae-8163-4ee0-8277-5a8c6059834b", "33d2943d-4f4b-494a-acc7-158105714182", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f19cadc-4c69-4054-a2b0-59896479951d", "9aa33081-d6dd-49f0-a60f-a31d54d32730", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e6a207b6-e510-45a0-aafa-7cf450427f8c", "61ca433d-035c-4053-aa68-2a8ddc5254e0", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78df3fae-8163-4ee0-8277-5a8c6059834b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f19cadc-4c69-4054-a2b0-59896479951d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6a207b6-e510-45a0-aafa-7cf450427f8c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0400fb39-16b3-45c3-ba41-c8be9eddf999", "ba9a4ce7-f50a-4775-a630-09bb00d2b7bb", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "46f7b525-2cfd-4517-9dc3-e3067914e46e", "38e4eefd-615a-4fa4-ac2a-e6587aaab49b", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0900d2e-977b-4c04-8525-5e9ef2afb909", "b97f6631-adc2-41bd-989c-a504d816ff4d", "Manager", "MANAGER" });
        }
    }
}
