using Quizzes_System.DTOs.Instructor;
using Quizzes_System.ViewModels.Instructor;

namespace Quizzes_System.ViewModels.Course
{
    public class GetAllCoursesViewModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public GetInstuctorInfoViewModel Instructor { get; set; }
    }
}
