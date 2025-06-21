using AutoMapper;
using Quizzes_System.DTOs.Question;
using Quizzes_System.DTOs.QuizParticipation;

namespace Quizzes_System.DTOs.Choices
{
    public class ChoiceProfile:Profile
    {
        public ChoiceProfile()
        {
            {
                CreateMap<Quizzes_System.Models.Choices, ChoiceDTO>();

                CreateMap<Quizzes_System.Models.Question, QuestionWithChoicesDTO>()
                    .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.Choices));
            }
            CreateMap<AddChoicesDTO, Quizzes_System.Models.Choices > ();
            CreateMap<Quizzes_System.Models.Question, GetQuestionDTo>();

            CreateMap<UpdateChosicseDTO, Quizzes_System.Models.Choices>();
        }
    }
}
