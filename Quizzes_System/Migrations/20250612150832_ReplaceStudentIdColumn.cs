using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizzes_System.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceStudentIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Choices_ChoiceId",
                table: "StudentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_ChoiceId",
                table: "StudentAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_ChoiceId",
                table: "StudentAnswers",
                column: "ChoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Choices_ChoiceId",
                table: "StudentAnswers",
                column: "ChoiceId",
                principalTable: "Choices",
                principalColumn: "Id");
        }
    }
}
