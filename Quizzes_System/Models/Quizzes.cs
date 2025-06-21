namespace Quizzes_System.Models
{
    public class Quizzes : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DurationMinutes { get; set; }
        public decimal TotalMarks { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<QuizQuestions> QuizQuestions { get; set; } = new HashSet<QuizQuestions>();
        public ICollection<StudentExam> StudentExams { get; set; } = new HashSet<StudentExam>();
    }
}
