using Quizzes_System.Models.Enum;

namespace Quizzes_System.ViewModels.Question
{
    public class UpdateQuestionViewModel
    {
        public int id { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public decimal Marks { get; set; }
    }
}
