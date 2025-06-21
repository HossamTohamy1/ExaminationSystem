using Quizzes_System.Models.Enum;

namespace Quizzes_System.DTOs.Quiz
{
    public class AddQuizDTO
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
