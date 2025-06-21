namespace Quizzes_System.DTOs.Choices
{
    public class AddChoicesDTO
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
