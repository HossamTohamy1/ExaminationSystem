using Quizzes_System.DTOs.StudentExam;
using Quizzes_System.Mapping;
using Quizzes_System.Models;
using Quizzes_System.Repositories;

namespace Quizzes_System.Services
{
    public class ResultServices
    {
        GeneralRepository<StudentExam> _generalRepository;
        QuizRepositories<Quizzes> _quizRepositories;
        IMapperService _mapperService;
        public ResultServices(GeneralRepository<StudentExam> generalRepository, IMapperService mapperService, QuizRepositories<Quizzes> quizRepositories)
        {
            _mapperService = mapperService;
            _generalRepository = generalRepository;
            _quizRepositories = quizRepositories;
        }
        public IEnumerable <StudentExamDTO> GetResultByStudent(int id)
        {
            var Exam = _quizRepositories.GetExamsByStudentIdAsync(id);
            return _mapperService.Map<List<StudentExamDTO>>(Exam);
        }
         public IEnumerable<StudentExamDTO> GetResultByQuizId(int id)
        {
            var Exam = _quizRepositories.GetExamsByQuizId(id);
            return _mapperService.Map<List<StudentExamDTO>>(Exam);
        }
    }
}
