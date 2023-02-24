using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.DAL.Migrations
{
    public partial class UpdatedCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "534dabf1-6072-416f-a5bb-a91a4bef7371");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5946f4cb-d5a1-4210-99f8-0d5a9cef03f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "679ad42d-28ef-4159-9816-b163a1d14d36");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00cf5380-1eb3-4350-b71e-e21086c8a093", "a14a9b61-5b2c-406a-bf0d-e278ee26e942", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ff67813-a193-4526-b1f1-c18894130b59", "483698e5-2160-41c7-ba33-cb44999fb0e6", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f0fff0da-8428-4c9e-ac7a-cf5e99e12a54", "2259514e-9878-4fd5-9527-094a0c554063", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00cf5380-1eb3-4350-b71e-e21086c8a093");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ff67813-a193-4526-b1f1-c18894130b59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0fff0da-8428-4c9e-ac7a-cf5e99e12a54");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "534dabf1-6072-416f-a5bb-a91a4bef7371", "b6020a42-2333-4e29-830e-06c3dff5ab40", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5946f4cb-d5a1-4210-99f8-0d5a9cef03f6", "ad8914d2-8593-43fc-8b66-86ad07f63f08", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "679ad42d-28ef-4159-9816-b163a1d14d36", "7e3749d8-0830-4b1f-bc86-b5963b57757b", "User", "USER" });
        }
    }
}
