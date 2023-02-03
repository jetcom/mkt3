using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mkt3.Migrations
{
    /// <inheritdoc />
    public partial class groups2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupID",
                table: "Questions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupID",
                table: "Questions");
        }
    }
}
