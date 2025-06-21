namespace Quizzes_System.DTOs.Question
{
    public class AddQuestionToQuizDTO
    {
        public int QuizId { get; set; }
        public List<int> QuestionIds { get; set; }
    }
}
