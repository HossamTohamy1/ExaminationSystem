namespace Quizzes_System.DTOs.Choices
{
    public class UpdateChosicseDTO
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
