using Quizzes_System.Models.Enum;

namespace Quizzes_System.DTOs.Question
{
    public class AddQuestionDTO
    {
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public decimal Marks { get; set; }
    }
}
