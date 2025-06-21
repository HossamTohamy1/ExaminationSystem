using Microsoft.EntityFrameworkCore;
using Quizzes_System.Data;
using Quizzes_System.Models;
using AutoMapper.QueryableExtensions;
using Quizzes_System.DTOs.Question;
using AutoMapper;

namespace Quizzes_System.Repositories
{
    public class QuestionRepository<Question> where Question : BaseEntity
    {
        QuizzesDbContext _context;
        IMapper _mapper;
        public QuestionRepository(QuizzesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper= mapper;
            

        }

        public IQueryable<QuizQuestions> GetQuestionsWithDetailsByQuizId(int quizId)
        {
            return _context.QuizQuestions.Where(q => q.QuizId == quizId);
        }



        public async Task AddQuestionsToQuizAsync(int quizId, List<int> questionIds)
        {
            foreach (var questionId in questionIds)
            {
                var quizQuestion = new QuizQuestions
                {
                    QuizId = quizId,
                    QuestionId = questionId
                };

                _context.QuizQuestions.Add(quizQuestion);
            }

            await _context.SaveChangesAsync();
        }
    }
}
