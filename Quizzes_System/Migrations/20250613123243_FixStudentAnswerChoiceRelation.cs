using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizzes_System.Migrations
{
    /// <inheritdoc />
    public partial class FixStudentAnswerChoiceRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Choices_SelectedChoiceId",
                table: "StudentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_SelectedChoiceId",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "SelectedChoiceId",
                table: "StudentAnswers");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_ChoiceId",
                table: "StudentAnswers",
                column: "ChoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Choices_ChoiceId",
                table: "StudentAnswers",
                column: "ChoiceId",
                principalTable: "Choices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Choices_ChoiceId",
                table: "StudentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_ChoiceId",
                table: "StudentAnswers");

            migrationBuilder.AddColumn<int>(
                name: "SelectedChoiceId",
                table: "StudentAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_SelectedChoiceId",
                table: "StudentAnswers",
                column: "SelectedChoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Choices_SelectedChoiceId",
                table: "StudentAnswers",
                column: "SelectedChoiceId",
                principalTable: "Choices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
