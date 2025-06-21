namespace Quizzes_System.ViewModels.Choices
{
    public class UpdateChosicseViewModel
    {
        public string Id { get; set; }

        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
