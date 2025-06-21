using AutoMapper;
using NetTopologySuite.IO;
using Quizzes_System.Data;
using Quizzes_System.Models;

namespace Quizzes_System.Repositories
{
    public class ChoiceRepository<T> where T : BaseEntity
    {
        QuizzesDbContext _context;
        IMapper _mapper;
        public ChoiceRepository(QuizzesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IQueryable<Choices> GetChoicesByQuestionId(int questionId)
        {
            return _context.Choices
                .Where(c => c.QuestionId == questionId && !c.IsDeleted);
        }

    }
}
