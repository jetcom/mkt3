using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mkt3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    examID = table.Column<string>(type: "text", nullable: false),
                    courseName = table.Column<string>(type: "text", nullable: false),
                    courseNumber = table.Column<string>(type: "text", nullable: false),
                    examName = table.Column<string>(type: "text", nullable: false),
                    maxPoints = table.Column<int>(type: "integer", nullable: true),
                    instructor = table.Column<string>(type: "text", nullable: true),
                    term = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    useCheckboxes = table.Column<bool>(type: "boolean", nullable: false),
                    defaultPoints = table.Column<int>(type: "integer", nullable: false),
                    defaultSolutionSpace = table.Column<string>(type: "text", nullable: false),
                    defaultLineLength = table.Column<string>(type: "text", nullable: false),
                    department = table.Column<string>(type: "text", nullable: true),
                    school = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.examID);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionID = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    Prompt = table.Column<string>(type: "text", nullable: false),
                    Points = table.Column<int>(type: "integer", nullable: false),
                    Solutions = table.Column<List<string>>(type: "text[]", nullable: false),
                    WrongAnswers = table.Column<List<string>>(type: "text[]", nullable: false),
                    ExamTags = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
