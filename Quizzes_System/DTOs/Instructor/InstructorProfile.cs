using AutoMapper;
using Quizzes_System.ViewModels.Instructor;
using System.Security.Cryptography;

namespace Quizzes_System.DTOs.Instructor
{
    public class InstructorProfile:Profile
    {
        public InstructorProfile()
        {
            CreateMap<Quizzes_System.Models.Instructor, GetInstructorInfoDTO>()
                    .ForMember(Dst => Dst.SpecializationInstru, Opt => Opt.MapFrom(Scr => Scr.Specialization))
                    .ReverseMap();
            CreateMap<GetInstructorInfoDTO, GetInstuctorInfoViewModel>().ReverseMap();
        }
    }
}
