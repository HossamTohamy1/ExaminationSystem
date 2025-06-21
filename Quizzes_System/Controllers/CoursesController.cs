using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PredicateExtensions;
using Quizzes_System.Data;
using Quizzes_System.DTOs.Course;
using Quizzes_System.Mapping;
using Quizzes_System.Models;
using Quizzes_System.Models.Enum;
using Quizzes_System.Repositories;
using Quizzes_System.Services;
using Quizzes_System.ViewModels;
using Quizzes_System.ViewModels.Course;
using System.Linq.Expressions;

namespace Quizzes_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        CourseService _courseService;
        GeneralRepository<Course> _generalRepository;
        IMapperService _mapperService;

        public CoursesController(QuizzesDbContext context , CourseService courseService, IMapperService mapperService)
        {
            _generalRepository = new GeneralRepository<Course>(context);
            _courseService = courseService;
            _mapperService = mapperService;

        }

        [HttpGet("all")]

        public ResponseViewModel<IEnumerable<GetAllCoursesViewModels>>GetAll()
        {
            var query = _courseService.GetAll();
           var res = _mapperService.Map<IEnumerable<GetAllCoursesViewModels>>(query);
            // ==> transfer query(DataType:IEnumerable<Course>) to IEnumerable<GetAllCoursesViewModels>
            return new SuccessResponseViewModel<IEnumerable<GetAllCoursesViewModels>>(res, "");
            
        }

        [HttpGet("id")]
        public async Task<Course> GetById(int id)
        {
          var res = await _courseService.GetById(id);
            return res;
        }
        [HttpGet("identifiyCourses")]
        public IList <Course> Get()
        {
            var res = _courseService.Get();
            return res;
        }
        [HttpGet("search")]
        public IEnumerable<Course> Get(int CourseId, string CourseName, int CourseHoure)
        {
            var predicate = MyPredicateBuilder(CourseId, CourseName, CourseHoure);
            return _generalRepository.Get(predicate).ToList();
        }
        private Expression<Func<Course, bool>> MyPredicateBuilder(int? CourseId, string CourseName, int? CourseHoure)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Course>(true);
            if (CourseId.HasValue)
            {
                predicate = predicate.And(x => x.Id == CourseId);
            }
            if (!string.IsNullOrEmpty(CourseName))
            {
                predicate = predicate.And(x => x.Title == CourseName);
            }
            if (CourseHoure.HasValue)
            {
                predicate = predicate.And(x => x.CreditHours == CourseHoure);
            }
            return predicate;
        }


        [HttpPost]
        public async Task<ResponseViewModel<string>> Add( AddCourseDTO courseDto)
        {
            if (!ModelState.IsValid)
            {
                return new ErrorResponseViewModel<string>("Invalid course data", ErrorCode.ValidationError);
            }

            await _courseService.Add(courseDto);

            return new SuccessResponseViewModel<string>(null, "Course added successfully");
        }



        [HttpPut]
        public async Task<ResponseViewModel<string>> Update(UpdateCourseRequestDTO courseDto)
        {
            if (!ModelState.IsValid)
            {
                return new ErrorResponseViewModel<string>("Invalid course data", ErrorCode.ValidationError);
            }

            var updated = await _courseService.Update(courseDto);
            if (!updated)
            {
                return new ErrorResponseViewModel<string>("Course not found", ErrorCode.NotFound);
            }

            return new SuccessResponseViewModel<string>(null, "Course updated successfully");
        }
        // Soft Delete
        [HttpDelete]
        public async Task<ResponseViewModel<bool>> Delete(int id)
        {
            if (id <= 0)
            {
                return new ErrorResponseViewModel<bool>("Invalid course ID", ErrorCode.ValidationError);
            }

            var deleted = await _courseService.Delete(id);
            if (!deleted)
            {
                return new ErrorResponseViewModel<bool>("Course not found", ErrorCode.NotFound);
            }

            return new SuccessResponseViewModel<bool>(true, "Course deleted successfully");
        }


        //[HttpPut("bulk")]
        //public async Task<IActionResult> BulkUpdate([FromBody] List<Course> courses)
        //{
        //    if (courses == null || !courses.Any())
        //        return BadRequest("No courses provided for update.");

        //    await _generalRepository.BulkUpdate(courses);
        //    return Ok("Bulk update completed successfully.");
        //}



    }
}
