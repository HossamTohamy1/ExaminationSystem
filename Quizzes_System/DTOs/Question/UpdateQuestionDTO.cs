using Quizzes_System.Models.Enum;

namespace Quizzes_System.DTOs.Question
{
    public class UpdateQuestionDTO
    {
        public int id { get; set; }

        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public decimal Marks { get; set; }
    }
}
