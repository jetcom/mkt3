using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mkt3.Migrations
{
    /// <inheritdoc />
    public partial class QuestionTopic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionTopics",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "integer", nullable: false),
                    TopicID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTopics", x => new { x.QuestionID, x.TopicID });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionTopics");
        }
    }
}
