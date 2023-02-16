using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.DAL.Migrations
{
    public partial class UpdateAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1aa1091c-f48d-410c-9a4c-074269da0ca1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5d5504d-65f6-43bf-bdb7-ad4e4f86b3f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc7d1523-2366-49b7-bb67-96cd4e4a696d");

            migrationBuilder.AddColumn<string>(
                name: "PhotoFileName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "11abae3a-91d8-414c-82be-66bdd2e1f3be", "c2e8eacc-1962-4a28-affd-3357129e85e2", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "12cafd69-e098-4fe1-86b1-0ba1d63b05e6", "bb751a4c-2b00-4216-a018-81f1e2af7fcd", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "381e2e2b-e51a-47fd-93c5-8a9135afff0f", "e8f2e194-7379-4798-807d-e908653f9fe9", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11abae3a-91d8-414c-82be-66bdd2e1f3be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12cafd69-e098-4fe1-86b1-0ba1d63b05e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "381e2e2b-e51a-47fd-93c5-8a9135afff0f");

            migrationBuilder.DropColumn(
                name: "PhotoFileName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1aa1091c-f48d-410c-9a4c-074269da0ca1", "51f15145-112d-4c17-abd2-5fe2ef905b07", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5d5504d-65f6-43bf-bdb7-ad4e4f86b3f7", "5f08caf1-c32b-4202-999b-f05150b008ec", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc7d1523-2366-49b7-bb67-96cd4e4a696d", "67bb345d-94f7-48ac-bd3b-0d0fb17277b2", "Administrator", "ADMINISTRATOR" });
        }
    }
}
