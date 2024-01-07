using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domains.FormCheck.Migrations
{
    /// <inheritdoc />
    public partial class HeaderDescriptionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FormChecks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "FormChecks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FormChecks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FormChecks");

            migrationBuilder.DropColumn(
                name: "Header",
                table: "FormChecks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FormChecks");
        }
    }
}
