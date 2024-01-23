using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vibez.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Address", "ApplicationUserId", "City", "CreatorName", "Date", "EventName", "EventTime", "Notes", "ParticipantCount", "Postcode" },
                values: new object[,]
                {
                    { 1, "123 Main St", null, "Sample City 1", "John Doe", new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Event 1", "12:00", "This is a sample event.", 50, 12345 },
                    { 2, "123 Sesame Stret", null, "Sample City 2", "Barack Obama", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Event 2", "15:00", "This is a sample event.", 20, 6800 },
                    { 3, "123 Secondary St", null, "Sample City 3", "Mike Tyson", new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Event 3", "20:00", "This is a sample event.", 35, 1234 },
                    { 4, "13 Main St", null, "Sample City 4", "Jon Jones", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Event 4", "18:00", "This is a sample event.", 12, 7777 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 4);
        }
    }
}
