using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoList.Migrations
{
    public partial class UserIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AuthenticationLevels_AuthLevelRefId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AuthenticationLevels");

            migrationBuilder.DropIndex(
                name: "IX_Users_AuthLevelRefId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthenticationLevels",
                columns: table => new
                {
                    AuthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationLevels", x => x.AuthId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AuthLevelRefId",
                table: "Users",
                column: "AuthLevelRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AuthenticationLevels_AuthLevelRefId",
                table: "Users",
                column: "AuthLevelRefId",
                principalTable: "AuthenticationLevels",
                principalColumn: "AuthId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
