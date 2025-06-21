namespace Quizzes_System.Models
{
    public class Course : BaseEntity
    {
        public string Code { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreditHours { get; set; }

        public int InstructorId { get; set; }

        public Instructor Instructor { get; set; }
        public ICollection<Quizzes> Quizzes { get; set; } = new HashSet<Quizzes>();
        public ICollection<StudentCourse> Students { get; set; } = new HashSet<StudentCourse>();
    }
}
