using Quizzes_System.Models.Enum;

namespace Quizzes_System.Models
{
    public class StudentExam : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? Score { get; set; }
        public ExamStatus Status { get; set; }

        public int StudentId { get; set; }
        public int QuizId { get; set; }

        public Student Student { get; set; }
        public Quizzes Quiz { get; set; }
        public ICollection<StudentAnswer> Answers { get; set; } = new HashSet<StudentAnswer>();
        public Result Result { get; set; }
    }

   
}
