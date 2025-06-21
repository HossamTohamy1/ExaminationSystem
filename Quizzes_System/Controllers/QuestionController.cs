using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizzes_System.DTOs.Question;
using Quizzes_System.Mapping;
using Quizzes_System.Models;
using Quizzes_System.Models.Enum;
using Quizzes_System.Repositories;
using Quizzes_System.Services;
using Quizzes_System.ViewModels;

namespace Quizzes_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        QuestionService _questionService;
        IMapperService _mapperService;
        public QuestionController(QuestionService questionService, IMapperService mapperService)
        {
            _questionService = questionService;
            _mapperService = mapperService;
        }


        [HttpGet("GET QuestionByQuizId")]
        public async Task<ActionResult<List<GetQuestionsWithDetailsByQuizIdDTO>>> GetQuestionsWithDetailsByQuizId(int id)
        {
            var result = await _questionService.GetQuestionsWithDetailsByQuizId(id);

            if (result == null || result.Count == 0)
            {
                return NotFound($"No questions found for quiz with ID = {id}");
            }

            return Ok(result);
        }


        [HttpPost("AddQuestionsToQuiz")]
        public async Task<ResponseViewModel<string>> AddQuestionsToQuiz ( AddQuestionToQuizDTO addQuestionToQuizDTO)
        {
            if (!ModelState.IsValid)
            {
                return new ErrorResponseViewModel<string>("Add invalid", ErrorCode.ValidationError);
            }

            await _questionService.AddQuestionsToQuizAsync(addQuestionToQuizDTO);

            return new  SuccessResponseViewModel<string>(null, " Add successfully");
        }

        [HttpPost("AddQuestions")]
        public async Task<ResponseViewModel<string>> AddQuestions(AddQuestionDTO addQuestionDTO)
        {
            if (!ModelState.IsValid)
            {
                return new ErrorResponseViewModel<string>("Add invalid", ErrorCode.ValidationError);
            }

            await _questionService.Add(addQuestionDTO);

            return new SuccessResponseViewModel<string>(null, " Add successfully");
        }
        [HttpPut]
        public async Task<ResponseViewModel<string>> Update(UpdateQuestionDTO updateQuestionDTO)
        {
            if (!ModelState.IsValid)
            {
                return new ErrorResponseViewModel<string>("Invalid course data", ErrorCode.ValidationError);
            }


            await _questionService.Update(updateQuestionDTO);
            return new SuccessResponseViewModel<string>(null, "Update Successfully");
        }
        [HttpDelete]
        public async Task<ResponseViewModel<string>> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return new ErrorResponseViewModel<string>("Delete invalid", ErrorCode.ValidationError);
            }
            await _questionService.Delete(id);

            return new SuccessResponseViewModel<string>(null, "Deleted successfully");
        }
    }
}
