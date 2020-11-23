using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoList.Migrations
{
    public partial class anaAref : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c18f3fdb-e8ca-4b8b-a9bf-b4c730576067");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "City" },
                values: new object[] { "dc69bb2e-8ce2-4279-8f19-5dd504e0e9b8", 0, "9b1c034f-77b7-4a4c-abf8-520592a649e2", "ApplicationUser", "sagie@gmail.com", false, false, null, null, null, "12345", null, false, "67f06aeb-1306-4c63-99b5-c39d666a4445", false, "Sagie", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc69bb2e-8ce2-4279-8f19-5dd504e0e9b8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "City" },
                values: new object[] { "c18f3fdb-e8ca-4b8b-a9bf-b4c730576067", 0, "001d1acb-8191-4d92-90c5-a803418c0d0f", "ApplicationUser", "sagie@gmail.com", false, false, null, null, null, "12345", null, false, "947826f6-59ae-42e7-ac53-4280c7764ff9", false, "Sagie", null });
        }
    }
}
