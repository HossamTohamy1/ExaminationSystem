namespace Quizzes_System.ViewModels.Quiz
{
    public class AddQuizViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DurationMinutes { get; set; }
        public decimal TotalMarks { get; set; }
        public int CourseId { get; set; }
    }
}
