namespace Quizzes_System.DTOs.Question
{
    public class GetQuestionsWithDetailsByQuizIdDTO
    {
        public int QuestionId { get; set; }
        public decimal Marks { get; set; }
        public string Text { get; set; }
    }
}
