using Microsoft.EntityFrameworkCore.Migrations;

namespace BigEvent.Migrations
{
    public partial class changingUserTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                newName: "BasicUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasicUsers",
                table: "BasicUsers",
                column: "BasicUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BasicUsers",
                table: "BasicUsers");

            migrationBuilder.RenameTable(
                name: "BasicUsers",
                newName: "AppUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers",
                column: "BasicUserId");
        }
    }
}
