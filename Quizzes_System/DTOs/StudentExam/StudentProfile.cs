using AutoMapper;

namespace Quizzes_System.DTOs.StudentExam
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<Quizzes_System.Models.StudentExam, StudentExamDTO>()
                .ForMember(dst=>dst.ExamId ,opt=>opt.MapFrom(scr=>scr.Id))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}
