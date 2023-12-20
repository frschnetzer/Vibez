using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vibez.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedApplicationUserList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserEvents");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ApplicationUserId",
                table: "Events",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EventId",
                table: "AspNetUsers",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Events_EventId",
                table: "AspNetUsers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_ApplicationUserId",
                table: "Events",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Events_EventId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_ApplicationUserId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ApplicationUserId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EventId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "ApplicationUserEvents",
                columns: table => new
                {
                    ApplicationUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventsEventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserEvents", x => new { x.ApplicationUsersId, x.EventsEventId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserEvents_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserEvents_Events_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserEvents_EventsEventId",
                table: "ApplicationUserEvents",
                column: "EventsEventId");
        }
    }
}
