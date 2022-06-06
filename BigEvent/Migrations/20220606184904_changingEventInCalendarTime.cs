using Microsoft.EntityFrameworkCore.Migrations;

namespace BigEvent.Migrations
{
    public partial class changingEventInCalendarTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventsInCalendar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsInCalendar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventsInCalendar_BasicUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "BasicUsers",
                        principalColumn: "BasicUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsInCalendar_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventsInCalendar_EventId",
                table: "EventsInCalendar",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsInCalendar_UserId",
                table: "EventsInCalendar",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsInCalendar");
        }
    }
}
