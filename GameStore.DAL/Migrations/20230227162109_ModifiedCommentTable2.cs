using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.DAL.Migrations
{
    public partial class ModifiedCommentTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38a766ca-4cf8-417b-a8df-36cb271585af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a89f96b-97a0-45c7-8552-2033df165252");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5a165dd-433c-4423-90c4-9124744f919c");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "38a766ca-4cf8-417b-a8df-36cb271585af", "9034b065-cedc-415f-8afa-96247b126bdd", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4a89f96b-97a0-45c7-8552-2033df165252", "8be1a36a-2dc7-4d6b-8fa3-201a792dfe50", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5a165dd-433c-4423-90c4-9124744f919c", "ed8d172c-94e1-4592-8778-a5a4b4f48541", "Manager", "MANAGER" });
        }
    }
}
