using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizzes_System.DTOs.Quiz;
using Quizzes_System.DTOs.QuizParticipation;
using Quizzes_System.Mapping;
using Quizzes_System.Models;
using Quizzes_System.Models.Enum;
using Quizzes_System.Services;
using Quizzes_System.ViewModels;

namespace Quizzes_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        QuizService _quizService;
        IMapperService _mapperService;
        public QuizController(QuizService quizService, IMapperService mapperService)
        {
            _quizService = quizService;
            _mapperService = mapperService;
        }




        [HttpGet("GetQuizzesByCourseId")]
        public ResponseViewModel<IEnumerable<Quizzes>> GetQuizByCourseId(int id)
        {
            var res = _quizService.GetQuizByCourseId(id);

            if (res == null || !res.Any())
                return new ErrorResponseViewModel<IEnumerable<Quizzes>>(null, ErrorCode.ValidationError);

            return new SuccessResponseViewModel<IEnumerable<Quizzes>>(res, "Quiz retrieved successfully.");
        }

        [HttpPost]
        public async Task<ResponseViewModel<string>> Add(AddQuizDTO QuizDTO)
        {
            if (!ModelState.IsValid)
            {
                return new ErrorResponseViewModel<string>("Add Is InValid", ErrorCode.ValidationError);
            }

            await _quizService.Add(QuizDTO); 
            return new SuccessResponseViewModel<string>(null, " Added Successfully");
        }
        [HttpPut]
        public async Task<ResponseViewModel<string>> Update (UpdateQuizDTO QuizDTO)
        {
            if (!ModelState.IsValid)
            {
                return new ErrorResponseViewModel<string>("Invalid process", ErrorCode.ValidationError);
            }

            await _quizService.Update(QuizDTO);

            return new SuccessResponseViewModel<string>(null, "Update Successfully");
        }
        [HttpDelete]
        public async Task<ResponseViewModel<string>> Delete (int id)
        {
            if(!ModelState.IsValid)
            {
                return new ErrorResponseViewModel<string>("Delete invalid", ErrorCode.ValidationError);
            }
            await _quizService.Delete(id);

            return new SuccessResponseViewModel<string>(null, "Deleted successfully");
        }

    }
}
