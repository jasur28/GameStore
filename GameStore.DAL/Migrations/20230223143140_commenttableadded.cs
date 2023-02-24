using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.DAL.Migrations
{
    public partial class commenttableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_GameId",
                table: "Comments",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId1",
                table: "Comments",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

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
    }
}
