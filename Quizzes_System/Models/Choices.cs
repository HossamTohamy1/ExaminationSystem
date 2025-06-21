namespace Quizzes_System.Models
{
    public class Choices : BaseEntity
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
