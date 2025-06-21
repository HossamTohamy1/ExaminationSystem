using Quizzes_System.DTOs.Course;
using Quizzes_System.Mapping;
using Quizzes_System.Models;
using Quizzes_System.Repositories;

namespace Quizzes_System.Services
{
    public class CourseService
    {
        GeneralRepository<Course> _generalRepository;
        private readonly IMapperService _mapperService;
        public CourseService(GeneralRepository<Course> generalRepository, IMapperService mapperService)
        {
            _mapperService = mapperService;
            _generalRepository = generalRepository;
        }


        public IEnumerable<GetAllCoursesDTO> GetAll()
        {
            var query = _mapperService.ProjectTo<Course, GetAllCoursesDTO>(_generalRepository.GetAll());
            return query.ToList();
        }
        public async Task<Course> GetById(int id)
        {
            var res = await _generalRepository.GetById(id);
            return res;
        }
        public IList<Course> Get()
        {
            var res = _generalRepository.Get(x => x.CreditHours < 40 && x.Title.Contains("C#"));
            return res.ToList();
        }
        public async Task<Course> GetByIdWithTracking(int id)
        {
            var res = await _generalRepository.GetByIdWithTracking(id);
            return res;
        }
        public async Task Add(AddCourseDTO CourseDto)
        {
            var query = _mapperService.Map<AddCourseDTO, Course>(CourseDto);
            await _generalRepository.Add(query);

        }
        public async Task<bool> Update(UpdateCourseRequestDTO courseDto)
        {
            var entity = _mapperService.Map<UpdateCourseRequestDTO, Course>(courseDto);

            var updated = await _generalRepository.UpdateInclude(entity,nameof(Course.Title),nameof(Course.Description));

            return updated;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                
                var entity = await _generalRepository.GetById(id);
                if (entity == null)
                {
                    return false; 
                }

                
                await _generalRepository.Delete(id);

                return true;
            }
            catch (Exception ex)
            {
                
                
                throw; 
            }
        }


    }
}
