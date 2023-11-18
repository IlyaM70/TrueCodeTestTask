using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UsersManager.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TagToUser",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagToUser", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_TagToUser_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagToUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Value" },
                values: new object[,]
                {
                    { new Guid("10ed2873-ff9d-4951-9346-1c71bd0ac0de"), "User" },
                    { new Guid("11ed2873-ff9d-4951-9346-1c71bd0ac0de"), "Moderator" },
                    { new Guid("12ed2873-ff9d-4951-9346-1c71bd0ac0de"), "NewUser" },
                    { new Guid("13ed2873-ff9d-4951-9346-1c71bd0ac0de"), "RegularUser" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Domain", "Name" },
                values: new object[,]
                {
                    { new Guid("10fd2873-ff9d-4951-9346-1c71bd0ac0de"), "first.com", "Alex" },
                    { new Guid("11fd2873-ff9d-4951-9346-1c71bd0ac0de"), "second.com", "Sam" },
                    { new Guid("12fd2873-ff9d-4951-9346-1c71bd0ac0de"), "first.com", "Dmitriy" },
                    { new Guid("13fd2873-ff9d-4951-9346-1c71bd0ac0de"), "second.com", "Victor" },
                    { new Guid("14fd2873-ff9d-4951-9346-1c71bd0ac0de"), "first.com", "Azat" },
                    { new Guid("15fd2873-ff9d-4951-9346-1c71bd0ac0de"), "second.com", "Arthur" }
                });

            migrationBuilder.InsertData(
                table: "TagToUser",
                columns: new[] { "EntityId", "TagId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2c2e557f-a2e9-4deb-9718-670f7cfa56e9"), new Guid("10ed2873-ff9d-4951-9346-1c71bd0ac0de"), new Guid("10fd2873-ff9d-4951-9346-1c71bd0ac0de") },
                    { new Guid("34299d77-1913-4672-979b-c3a2dae2012e"), new Guid("13ed2873-ff9d-4951-9346-1c71bd0ac0de"), new Guid("11fd2873-ff9d-4951-9346-1c71bd0ac0de") },
                    { new Guid("42f82055-972b-4973-9d09-171abb2d9cd0"), new Guid("12ed2873-ff9d-4951-9346-1c71bd0ac0de"), new Guid("10fd2873-ff9d-4951-9346-1c71bd0ac0de") },
                    { new Guid("5dfd5f9e-8095-4d6e-a9e3-4c180385c58a"), new Guid("10ed2873-ff9d-4951-9346-1c71bd0ac0de"), new Guid("11fd2873-ff9d-4951-9346-1c71bd0ac0de") },
                    { new Guid("72307b4a-4f2b-4a5f-95f7-522e3c47a767"), new Guid("10ed2873-ff9d-4951-9346-1c71bd0ac0de"), new Guid("12fd2873-ff9d-4951-9346-1c71bd0ac0de") },
                    { new Guid("747e719a-7a1a-4adc-bb70-1720390156dc"), new Guid("12ed2873-ff9d-4951-9346-1c71bd0ac0de"), new Guid("14fd2873-ff9d-4951-9346-1c71bd0ac0de") },
                    { new Guid("821052f9-e3e6-4276-8eed-ebc0d30e46ba"), new Guid("13ed2873-ff9d-4951-9346-1c71bd0ac0de"), new Guid("13fd2873-ff9d-4951-9346-1c71bd0ac0de") },
                    { new Guid("831e003a-fa2a-4516-8e44-2ed4a757f1ac"), new Guid("11ed2873-ff9d-4951-9346-1c71bd0ac0de"), new Guid("13fd2873-ff9d-4951-9346-1c71bd0ac0de") },
                    { new Guid("a808dd7c-cb8c-40ba-a143-a862af02e93c"), new Guid("13ed2873-ff9d-4951-9346-1c71bd0ac0de"), new Guid("15fd2873-ff9d-4951-9346-1c71bd0ac0de") },
                    { new Guid("bf6df672-b7de-41d7-bc28-4ac88bab3159"), new Guid("11ed2873-ff9d-4951-9346-1c71bd0ac0de"), new Guid("14fd2873-ff9d-4951-9346-1c71bd0ac0de") },
                    { new Guid("da6dff99-d615-4773-b38b-d0d5d2b48b07"), new Guid("13ed2873-ff9d-4951-9346-1c71bd0ac0de"), new Guid("12fd2873-ff9d-4951-9346-1c71bd0ac0de") },
                    { new Guid("e5651ea4-a9c4-4357-be55-4ac88f676a53"), new Guid("10ed2873-ff9d-4951-9346-1c71bd0ac0de"), new Guid("15fd2873-ff9d-4951-9346-1c71bd0ac0de") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagToUser_TagId",
                table: "TagToUser",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TagToUser_UserId",
                table: "TagToUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagToUser");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
