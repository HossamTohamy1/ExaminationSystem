using AutoMapper;
using Quizzes_System.Models;
using Quizzes_System.ViewModels.Question;

namespace Quizzes_System.DTOs.Question
{
    public class QuestionProfile:Profile
    {
        public QuestionProfile()
        {
            CreateMap<AddQuestionDTO, Quizzes_System.Models.Question>();
            CreateMap<UpdateQuestionDTO, Quizzes_System.Models.Question>();


            CreateMap<QuizQuestions, GetQuestionsWithDetailsByQuizIdDTO>()
                         .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.Question.Id))
                       .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Question.Text))
                       .ForMember(dest => dest.Marks, opt => opt.MapFrom(src => src.Question.Marks));
        }
    }
}
