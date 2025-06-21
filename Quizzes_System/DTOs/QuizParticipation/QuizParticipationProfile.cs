using AutoMapper;
using Quizzes_System.Models;

namespace Quizzes_System.DTOs.QuizParticipation

{
    using Quizzes_System.Models.Enum;

    public class QuizParticipationProfile:Profile
    {
        public QuizParticipationProfile()
        {
            



            CreateMap<SubmitQuizDTO, Quizzes_System.Models.StudentExam>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (ExamStatus)src.Status))
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers));

            CreateMap<SubmitAnswerDTO, StudentAnswer>()
                .ForMember(dest => dest.MarksObtained, opt => opt.Ignore()); // later

            CreateMap<Quizzes_System.Models.Choices, ChoiceDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<Quizzes_System.Models.Question, QuestionWithChoicesDTO>()
                .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.Choices));

            CreateMap<QuizQuestions, QuestionWithChoicesDTO>()
                .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.Question.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Question.Text))
                .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.Question.Choices));

            CreateMap<Quizzes, QuizWithQuestionsDTO>()
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.QuizQuestions));

        }
    }
}
