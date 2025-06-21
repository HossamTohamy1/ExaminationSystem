using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizzes_System.DTOs.QuizParticipation;
using Quizzes_System.Mapping;
using Quizzes_System.Models.Enum;
using Quizzes_System.Services;
using Quizzes_System.ViewModels;

namespace Quizzes_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizParticipationController : ControllerBase
    {
        QuizService _quizService;
        IMapperService _mapperService;
        public QuizParticipationController(QuizService quizService, IMapperService mapperService)
        {
            _quizService = quizService;
            _mapperService = mapperService;
        }
        [HttpGet("TakeQuiz/{quizId}")]
        public ResponseViewModel<QuizWithQuestionsDTO> TakeQuiz(int quizId)
        {
            var quizDtos = _quizService.TakeQuizAsync(quizId);

            var quizDto = quizDtos.FirstOrDefault(); 

            if (quizDto == null)
            {
                return new ErrorResponseViewModel<QuizWithQuestionsDTO>("Get Invalid", ErrorCode.ValidationError);
            }

            return new SuccessResponseViewModel<QuizWithQuestionsDTO>(quizDto, "Results retrieved successfully");

        }
        
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitQuiz([FromBody] SubmitQuizDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _quizService.SubmitQuizAsync(dto);
                return Ok(new { message = "Quiz submitted successfully!" });
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException?.Message ?? ex.Message;
                return StatusCode(500, new { message = "An error occurred while submitting the quiz.", details = inner });
            }
        }
    }


    
}
