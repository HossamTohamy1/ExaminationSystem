namespace Quizzes_System.DTOs.QuizParticipation
{
    public class QuizWithQuestionsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationMinutes { get; set; }
        public ICollection<QuestionWithChoicesDTO> Questions { get; set; }
    }
}
