using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vibez.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserNickname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserNicknameIdentifier",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserNickname",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserNicknameIdentifier",
                table: "AspNetUsers",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);
        }
    }
}
