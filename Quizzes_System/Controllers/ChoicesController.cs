using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizzes_System.DTOs.Choices;
using Quizzes_System.DTOs.Question;
using Quizzes_System.DTOs.QuizParticipation;
using Quizzes_System.Mapping;
using Quizzes_System.Models.Enum;
using Quizzes_System.Services;
using Quizzes_System.ViewModels;

namespace Quizzes_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoicesController : ControllerBase

    {
        ChoicesService _choicesService;
        IMapperService _mapperService;
        public ChoicesController(ChoicesService choicesService, IMapperService mapperService)
        {
            _choicesService = choicesService;
            _mapperService = mapperService;
        }


        [HttpGet("QuestionId")]
        public ResponseViewModel<IEnumerable<ChoiceDTO>> GetChoicesByQuestionId(int id)
        {
            var query = _choicesService.GetChoicesByQuestionId(id);

            if (query == null || !query.Any())
                return new ErrorResponseViewModel<IEnumerable<ChoiceDTO>>(null, ErrorCode.ValidationError);

            var resultDto = _mapperService.Map<IEnumerable<ChoiceDTO>>(query);

            return new SuccessResponseViewModel<IEnumerable<ChoiceDTO>>(resultDto, "Choices retrieved successfully.");
        }

        [HttpPost]
         
        public async Task<ResponseViewModel<string>> Add (AddChoicesDTO addChoicesDTO)
        {
            if (!ModelState.IsValid)
            {
                return new ErrorResponseViewModel<string>("Add Is InValid", ErrorCode.ValidationError);
            }

            await _choicesService.Add(addChoicesDTO);

            return new SuccessResponseViewModel<string>(null, " Added Successfully");
           
        }
        [HttpPut]
        
        public async Task <ResponseViewModel<string>> Update (UpdateChosicseDTO updateChosicseDTO)
        {
            if (!ModelState.IsValid)
            {
                return new ErrorResponseViewModel<string>("Update Is InValid", ErrorCode.ValidationError);
            }
            await _choicesService.Update(updateChosicseDTO);

            return new SuccessResponseViewModel<string>(null, " Updated Successfully");
        }
        [HttpDelete]
        public async Task<ResponseViewModel<string>> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return new ErrorResponseViewModel<string>("Delete invalid", ErrorCode.ValidationError);
            }
            await _choicesService.Delete(id);

            return new SuccessResponseViewModel<string>(null, "Deleted successfully");
        }
    }
}
