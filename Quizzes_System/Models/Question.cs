using Quizzes_System.Models.Enum;

namespace Quizzes_System.Models
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public decimal Marks { get; set; }

        public ICollection<Choices> Choices { get; set; } = new HashSet<Choices>();
        public ICollection<StudentAnswer> StudentAnswers { get; set; } = new HashSet<StudentAnswer>();

        public ICollection<QuizQuestions> QuizQuestions { get; set; } = new HashSet<QuizQuestions>();
    }

   
}
