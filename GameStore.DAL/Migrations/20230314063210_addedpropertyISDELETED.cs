using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.DAL.Migrations
{
    public partial class addedpropertyISDELETED : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98540fd5-b401-4e57-ac82-8b9a965c081e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adae435c-1aba-4146-8c11-41fbdd7ce9a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b51c1482-8aa5-46c9-bda2-3f25adaba1d8");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98540fd5-b401-4e57-ac82-8b9a965c081e", "ecb3910a-2966-48b2-bccc-a6adda9e7975", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "adae435c-1aba-4146-8c11-41fbdd7ce9a1", "ba1f32f4-10c6-4cfa-addd-e907ebdd1e0d", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b51c1482-8aa5-46c9-bda2-3f25adaba1d8", "adb53d25-c690-47e0-8a85-1e9378d152ca", "Administrator", "ADMINISTRATOR" });
        }
    }
}
