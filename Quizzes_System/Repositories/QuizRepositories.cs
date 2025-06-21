using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Quizzes_System.Data;
using Quizzes_System.DTOs.QuizParticipation;
using Quizzes_System.Models;

namespace Quizzes_System.Repositories
{
    public class QuizRepositories<T> where T : BaseEntity
    {
        QuizzesDbContext _context;
        DbSet<Quizzes> _dbset;
        IMapper _mapper;
        public QuizRepositories(QuizzesDbContext context, IMapper mapper)
        {
            _context = context;
            _dbset = _context.Set<Quizzes>();
            _mapper = mapper;

        }
        //ResultService
        public IQueryable <StudentExam> GetExamsByStudentIdAsync(int studentId)
        {
            return _context.StudentExams
                .Where(e => e.StudentId == studentId);
                
        }
        public IQueryable<StudentExam> GetExamsByQuizId(int studentId)
        {
            return _context.StudentExams
                .Where(e => e.QuizId == studentId);

        }
        public async Task<bool> HasStudentSubmittedAsync(int studentId, int quizId)
        {
            return await _context.StudentExams.AnyAsync(e => e.StudentId == studentId && e.QuizId == quizId);
        }
        public IQueryable<StudentExam> GetStudentExamByQuizId(int id)
        {
            return _context.StudentExams.Where(x => x.QuizId == id);
        }

        //-------


        // submit
        public async Task AddStudentExamAsync(StudentExam studentExam)
        {
            await _context.StudentExams.AddAsync(studentExam);
            await _context.SaveChangesAsync();

        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public IQueryable <Quizzes> GetQuizByCourseId(int id)
        {
            var res = _context.Quizzes.Where(x => x.CourseId == id);
            return res;
        }

        public IQueryable<QuizWithQuestionsDTO> GetQuizWithQuestionsDTOAsync(int quizId)
        {
            return _context.Quizzes
                .Where(q => q.Id == quizId)
                .ProjectTo<QuizWithQuestionsDTO>(_mapper.ConfigurationProvider);

        }

        // Submit Task 
        public async Task<Question> GetQuestionAsync(int questionId)
        {
            return await _context.Questions.FirstOrDefaultAsync(q => q.Id == questionId);
        }

        public async Task<List<Choices>> GetChoicesForQuestionAsync(int questionId)
        {
            return await _context.Choices
                .Where(c => c.QuestionId == questionId)
                .ToListAsync();
        }

    }
}
