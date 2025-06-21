using Quizzes_System.Data;

namespace Quizzes_System.Models
{
    public class Student : BaseEntity
    {
        public string UserId { get; set; } 
        public int StudentId { get; set; } 
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
        public string? AcademicLevel { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<StudentCourse> Courses { get; set; } = new HashSet<StudentCourse>();
        public ICollection<StudentExam> Exams { get; set; } = new HashSet<StudentExam>();
        public ICollection<StudentInstructor> StudentInstructors { get; set; } = new HashSet<StudentInstructor>();

    }
}
