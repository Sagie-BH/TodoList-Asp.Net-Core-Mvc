using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoList.Migrations
{
    public partial class UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc69bb2e-8ce2-4279-8f19-5dd504e0e9b8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "City" },
                values: new object[] { "9ad4bc0c-73a9-4172-9bf2-b3301402e95b", 0, "136f9cd3-a747-41be-ae3f-644321ae76f5", "ApplicationUser", "sagie@gmail.com", false, false, null, null, null, "12345", null, false, "56230941-9e68-4d66-94c2-9922aa024447", false, "Sagie", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ad4bc0c-73a9-4172-9bf2-b3301402e95b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "City" },
                values: new object[] { "dc69bb2e-8ce2-4279-8f19-5dd504e0e9b8", 0, "9b1c034f-77b7-4a4c-abf8-520592a649e2", "ApplicationUser", "sagie@gmail.com", false, false, null, null, null, "12345", null, false, "67f06aeb-1306-4c63-99b5-c39d666a4445", false, "Sagie", null });
        }
    }
}
