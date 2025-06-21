namespace Quizzes_System.DTOs.QuizParticipation
{
    public class QuestionWithChoicesDTO
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public ICollection<ChoiceDTO> Choices { get; set; }
    }
}
