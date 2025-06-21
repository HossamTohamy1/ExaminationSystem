using AutoMapper.QueryableExtensions;
using Quizzes_System.DTOs.Question;
using Quizzes_System.Mapping;
using Quizzes_System.Models;
using Quizzes_System.Repositories;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Quizzes_System.Services
{
    public class QuestionService
    {
        GeneralRepository<Question> _generalRepository;
        QuestionRepository<Question> _questionRepository;
        IMapperService _mapperService;
        
        public QuestionService(GeneralRepository<Question> generalRepository, IMapperService mapperService, QuestionRepository<Question> questionRepository)
        {
            _mapperService = mapperService;
            _generalRepository = generalRepository;
            _questionRepository = questionRepository;
            
        }
        public async Task<List<GetQuestionsWithDetailsByQuizIdDTO>> GetQuestionsWithDetailsByQuizId(int id)
        {
            var questionsQuery = _questionRepository.GetQuestionsWithDetailsByQuizId(id);
            var projected = questionsQuery
                .ProjectTo<GetQuestionsWithDetailsByQuizIdDTO>(_mapperService.ConfigurationProvider);
            return await projected.ToListAsync();
        }



        public async Task AddQuestionsToQuizAsync(AddQuestionToQuizDTO dto)
        {
            await _questionRepository.AddQuestionsToQuizAsync(dto.QuizId, dto.QuestionIds);
        }

        public async Task Add(AddQuestionDTO addQuestionDTO) 
        {
            var query = _mapperService.Map<AddQuestionDTO,Question>(addQuestionDTO);
            await _generalRepository.Add(query);
        }
        public async Task<bool> Update (UpdateQuestionDTO updateQuestionDTO)
        {
            var query = _mapperService.Map<UpdateQuestionDTO, Question>(updateQuestionDTO);
            var Update = await _generalRepository.UpdateInclude(query , nameof(Question.Text) , nameof(Question.Type) , nameof(Question.Marks)) ;
            return Update;
        }
        public async Task<bool> Delete(int id)
        {
            await _generalRepository.Delete(id);

            return true;
        }
    }
}
