using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.DAL.Migrations
{
    public partial class ModifiedCommentTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6756a449-eef8-468c-8953-e3b199312dc8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2ea1e08-6e79-436d-82a4-712164e8e74f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9b3c01e-9bc7-420a-a7c1-5f0d6748a6de");

            migrationBuilder.DropColumn(
                name: "GameeeeId",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52bd7c6b-b655-42da-9dd5-60f9dcdb0702", "be955eb9-74d4-44a2-94bd-014f5fac26b1", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b66f1021-ab67-4167-a1fb-75984dcf909b", "f56b1b68-7407-4f41-9e5c-e3cb25a20878", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3510a3b-5260-4436-81e9-b7d113fcb2c6", "49e7feb7-d400-4781-817e-e9e394f9654d", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52bd7c6b-b655-42da-9dd5-60f9dcdb0702");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b66f1021-ab67-4167-a1fb-75984dcf909b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3510a3b-5260-4436-81e9-b7d113fcb2c6");

            migrationBuilder.AddColumn<Guid>(
                name: "GameeeeId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6756a449-eef8-468c-8953-e3b199312dc8", "6b744849-eed2-43f7-b04b-202e2a0944f3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b2ea1e08-6e79-436d-82a4-712164e8e74f", "4a1a8e33-4a26-4fad-9c41-fa41829d5e25", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9b3c01e-9bc7-420a-a7c1-5f0d6748a6de", "a44efdcf-d607-4672-8311-b5d6a8f6ea1c", "Administrator", "ADMINISTRATOR" });
        }
    }
}
