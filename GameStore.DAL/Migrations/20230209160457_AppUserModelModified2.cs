using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.DAL.Migrations
{
    public partial class AppUserModelModified2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
