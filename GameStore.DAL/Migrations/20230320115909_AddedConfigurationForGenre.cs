using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.DAL.Migrations
{
    public partial class AddedConfigurationForGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711",
                column: "ConcurrencyStamp",
                value: "dea96f0c-c812-47bc-b90e-33f70e6f54ba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "780e2e9a-eaba-4e94-ab0f-2371cfc37f0d", "AQAAAAEAACcQAAAAEDd+IDcRMvdDpkR6+7YvDxlJBj/IrXB7dzUIyfnaXqX9T6MAvSVfofmYYLyrKjR+ew==", "1e786091-79bc-4de4-bf68-09b5c1a66475" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreId", "Name", "ParenId" },
                values: new object[,]
                {
                    { new Guid("1b25d3b5-ffcf-4879-8b00-3a3f96edfbee"), null, "Strategy", null },
                    { new Guid("3a5de2ae-583c-41e5-b55d-9179f46cbbeb"), null, "Races", null },
                    { new Guid("63f2c980-4bce-4858-a7e3-28aeb4eb81d6"), null, "Adventure", null },
                    { new Guid("6e0dba34-f443-462f-9c3a-fd15d496f739"), null, "Others", null },
                    { new Guid("83ec58f5-0b16-4ed3-9931-a20c2600867c"), null, "Puzzle & Skill", null },
                    { new Guid("be8bfcc4-5b13-42ec-9fe1-2e0c747e7141"), null, "Action", null },
                    { new Guid("c335344e-cf89-4b73-9931-26e4e890000b"), null, "Sports", null },
                    { new Guid("e14e7ab7-6589-4a0e-8ff9-17db4aafd2a0"), null, "Rpg", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1b25d3b5-ffcf-4879-8b00-3a3f96edfbee"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3a5de2ae-583c-41e5-b55d-9179f46cbbeb"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("63f2c980-4bce-4858-a7e3-28aeb4eb81d6"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6e0dba34-f443-462f-9c3a-fd15d496f739"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("83ec58f5-0b16-4ed3-9931-a20c2600867c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("be8bfcc4-5b13-42ec-9fe1-2e0c747e7141"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c335344e-cf89-4b73-9931-26e4e890000b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e14e7ab7-6589-4a0e-8ff9-17db4aafd2a0"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711",
                column: "ConcurrencyStamp",
                value: "de8a28aa-3e79-414f-af3c-b2c1d076ffc2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "217d97d9-8db6-48fa-a657-773b396a72d1", "AQAAAAEAACcQAAAAEHhCYT/q+LK+oDz1ZNUSdxscHsykU5JmhfmlpofTtu7yAk4NtYgQkOQ4kT1impKBzA==", "1b393882-4b12-435b-b5a3-838cc99faf80" });
        }
    }
}
