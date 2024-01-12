using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vibez.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEventProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CordinatesLatitude",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CordinatesLongitude",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "EventTime",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventTime",
                table: "Events");

            migrationBuilder.AddColumn<double>(
                name: "CordinatesLatitude",
                table: "Events",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CordinatesLongitude",
                table: "Events",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
