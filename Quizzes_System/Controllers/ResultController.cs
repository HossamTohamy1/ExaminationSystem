using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizzes_System.DTOs.StudentExam;
using Quizzes_System.Mapping;
using Quizzes_System.Models.Enum;
using Quizzes_System.Services;
using Quizzes_System.ViewModels;
using Quizzes_System.ViewModels.Course;

namespace Quizzes_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        ResultServices _resultService;
        IMapperService _mapperService;
        public ResultController(ResultServices resultService, IMapperService mapperService)
        {
            _resultService = resultService;
            _mapperService = mapperService;
        }
        [HttpGet("results/student/{studentId}")]
        public ResponseViewModel<IEnumerable<StudentExamDTO>> ViewResultsByStudent(int studentId)
        {
            var query = _resultService.GetResultByStudent(studentId);

            if (query == null || !query.Any())
                return new ErrorResponseViewModel<IEnumerable<StudentExamDTO>>(null, ErrorCode.ValidationError);

            var resultDto = _mapperService.Map<IEnumerable<StudentExamDTO>>(query);

            return new SuccessResponseViewModel<IEnumerable<StudentExamDTO>>(resultDto, "Results retrieved successfully.");
        }

        [HttpGet("results/Quiz/{QuizId}")]
        public ResponseViewModel<IEnumerable<StudentExamDTO>> ViewResultsByQuizId(int QuizId)
        {
            var query = _resultService.GetResultByQuizId(QuizId);

            if (query == null || !query.Any())
                return new ErrorResponseViewModel<IEnumerable<StudentExamDTO>>(null, ErrorCode.ValidationError);

            var resultDto = _mapperService.Map<IEnumerable<StudentExamDTO>>(query);

            return new SuccessResponseViewModel<IEnumerable<StudentExamDTO>>(resultDto, "Results retrieved successfully.");
        }

    }
}
