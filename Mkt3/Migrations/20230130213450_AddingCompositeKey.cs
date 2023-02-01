using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mkt3.Migrations
{
    /// <inheritdoc />
    public partial class AddingCompositeKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                columns: new[] { "examID", "courseNumber" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "examID");
        }
    }
}
