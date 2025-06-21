using AutoMapper;
using Quizzes_System.Models;

namespace Quizzes_System.DTOs.Quiz
{using Quizzes_System.Models.Enum;

    public class QuizProfile:Profile
    {
        public QuizProfile()
        {  // Add
            CreateMap<AddQuizDTO, Quizzes_System.Models.Quizzes>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name));


            // update

            CreateMap<UpdateQuizDTO, Quizzes_System.Models.Quizzes>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(scr => scr.Name));
        }
    }
}
