using AutoMapper;
using Quizzes_System.DTOs.Instructor;
using Quizzes_System.ViewModels.Course;
using Quizzes_System.ViewModels.Instructor;

namespace Quizzes_System.DTOs.Course
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            //GetAll
            CreateMap<Quizzes_System.Models.Course, GetAllCoursesDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(scr => scr.Title));
            CreateMap< GetAllCoursesDTO  , GetAllCoursesViewModels>().ReverseMap();

            //Add
            CreateMap<AddCourseDTO, Quizzes_System.Models.Course>();

            //Update
            CreateMap<UpdateCourseRequestDTO, Quizzes_System.Models.Course>();
        }
    }
}
