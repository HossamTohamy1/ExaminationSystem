using Quizzes_System.Data;

namespace Quizzes_System.Models
{
    public class Instructor : BaseEntity
    {
        public string UserId { get; set; } 
        public string Department { get; set; }
        public string? Specialization { get; set; }
        public DateTime HireDate { get; set; } = DateTime.UtcNow;

        public ApplicationUser User { get; set; }
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        public ICollection<StudentInstructor> StudentInstructors { get; set; } = new HashSet<StudentInstructor>();

    }
}
