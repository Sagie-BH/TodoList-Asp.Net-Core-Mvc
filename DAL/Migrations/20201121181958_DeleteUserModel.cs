using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoList.Migrations
{
    public partial class DeleteUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodosTable_Users_UserModelID",
                table: "TodosTable");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TodosTable_UserModelID",
                table: "TodosTable");

            migrationBuilder.DropColumn(
                name: "UserModelID",
                table: "TodosTable");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TodosTable",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "City" },
                values: new object[] { "c18f3fdb-e8ca-4b8b-a9bf-b4c730576067", 0, "001d1acb-8191-4d92-90c5-a803418c0d0f", "ApplicationUser", "sagie@gmail.com", false, false, null, null, null, "12345", null, false, "947826f6-59ae-42e7-ac53-4280c7764ff9", false, "Sagie", null });

            migrationBuilder.CreateIndex(
                name: "IX_TodosTable_ApplicationUserId",
                table: "TodosTable",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodosTable_AspNetUsers_ApplicationUserId",
                table: "TodosTable",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodosTable_AspNetUsers_ApplicationUserId",
                table: "TodosTable");

            migrationBuilder.DropIndex(
                name: "IX_TodosTable_ApplicationUserId",
                table: "TodosTable");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c18f3fdb-e8ca-4b8b-a9bf-b4c730576067");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TodosTable");

            migrationBuilder.AddColumn<int>(
                name: "UserModelID",
                table: "TodosTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email", "Password", "Role", "Name" },
                values: new object[] { 1, "sagie@gmail.com", "12345", "admin", "Sagie" });

            migrationBuilder.CreateIndex(
                name: "IX_TodosTable_UserModelID",
                table: "TodosTable",
                column: "UserModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_TodosTable_Users_UserModelID",
                table: "TodosTable",
                column: "UserModelID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
