using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vibez.Data.Migrations
{
    /// <inheritdoc />
    public partial class SolvedModelErrors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserEvents_Events_EventsId",
                table: "ApplicationUserEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserEvents",
                table: "ApplicationUserEvents");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserEvents_EventsId",
                table: "ApplicationUserEvents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventsId",
                table: "ApplicationUserEvents");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EventsEventId",
                table: "ApplicationUserEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserEvents",
                table: "ApplicationUserEvents",
                columns: new[] { "ApplicationUsersId", "EventsEventId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserEvents_EventsEventId",
                table: "ApplicationUserEvents",
                column: "EventsEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserEvents_Events_EventsEventId",
                table: "ApplicationUserEvents",
                column: "EventsEventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserEvents_Events_EventsEventId",
                table: "ApplicationUserEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserEvents",
                table: "ApplicationUserEvents");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserEvents_EventsEventId",
                table: "ApplicationUserEvents");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventsEventId",
                table: "ApplicationUserEvents");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Events",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventsId",
                table: "ApplicationUserEvents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserEvents",
                table: "ApplicationUserEvents",
                columns: new[] { "ApplicationUsersId", "EventsId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserEvents_EventsId",
                table: "ApplicationUserEvents",
                column: "EventsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserEvents_Events_EventsId",
                table: "ApplicationUserEvents",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
