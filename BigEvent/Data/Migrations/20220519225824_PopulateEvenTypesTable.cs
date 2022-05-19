using Microsoft.EntityFrameworkCore.Migrations;

namespace BigEvent.Data.Migrations
{
    public partial class PopulateEvenTypesTable : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder
                .InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "music gig" });

            migrationBuilder
                .InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "business meeting" });

            migrationBuilder
                .InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "self-development meeting" });

            migrationBuilder
                .InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "developers meeting" });

            migrationBuilder
                .InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "yoga" });



        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "EventTypes", keyColumn: "Id", keyValue: 1);
            migrationBuilder.DeleteData(table: "EventTypes", keyColumn: "Id", keyValue: 2);
            migrationBuilder.DeleteData(table: "EventTypes", keyColumn: "Id", keyValue: 3);
            migrationBuilder.DeleteData(table: "EventTypes", keyColumn: "Id", keyValue: 4);
            migrationBuilder.DeleteData(table: "EventTypes", keyColumn: "Id", keyValue: 5);
            migrationBuilder.DeleteData(table: "EventTypes", keyColumn: "Id", keyValue: 6);
        }

    }
}
