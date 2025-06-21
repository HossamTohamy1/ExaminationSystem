namespace Quizzes_System.Models
{
    public class QuizQuestions 
    {
        public int QuizId { get; set; }
        public Quizzes Quiz { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
