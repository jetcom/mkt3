using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mkt3.Migrations
{
    /// <inheritdoc />
    public partial class linelength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LineLength",
                table: "Questions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "customLineLength",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LineLength",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "customLineLength",
                table: "Questions");
        }
    }
}
