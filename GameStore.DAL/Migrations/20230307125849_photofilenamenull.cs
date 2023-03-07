using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.DAL.Migrations
{
    public partial class photofilenamenull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2591cd3-1c82-4312-8553-71ac2ee98023");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f416802d-b987-47f1-8fca-924b516f8f85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcbca4d8-7cc5-409e-9d78-116f9a5a1f2a");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoFileName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d2ff6fc-f78b-442d-a717-bdbf5e60ef55", "3d4a8832-c2fe-441d-a39a-19fd6c44e18f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "411968d9-ae08-4c14-a8ec-475fd8494ca8", "b42c882d-436a-4bf0-8771-d9511b2f7207", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "802b7468-ea90-4a7f-9d49-714ddbc3022c", "d284bc88-5e3b-431e-a0de-c6c5edeaf581", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d2ff6fc-f78b-442d-a717-bdbf5e60ef55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "411968d9-ae08-4c14-a8ec-475fd8494ca8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "802b7468-ea90-4a7f-9d49-714ddbc3022c");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoFileName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b2591cd3-1c82-4312-8553-71ac2ee98023", "5478e39a-8aab-418e-83aa-0d7b7b69ba42", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f416802d-b987-47f1-8fca-924b516f8f85", "b1b2b7a6-5944-4ff7-8050-d5ce14f6070c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fcbca4d8-7cc5-409e-9d78-116f9a5a1f2a", "3667f343-2dcb-4326-9326-cb7358867694", "Manager", "MANAGER" });
        }
    }
}
