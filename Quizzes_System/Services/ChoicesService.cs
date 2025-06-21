using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Quizzes_System.DTOs.Choices;
using Quizzes_System.DTOs.QuizParticipation;
using Quizzes_System.Mapping;
using Quizzes_System.Models;
using Quizzes_System.Repositories;

namespace Quizzes_System.Services
{
    public class ChoicesService
    {

        GeneralRepository<Choices> _generalRepository;
        ChoiceRepository<Choices> _choiceRepository;
        IMapperService _mapperService;

        public ChoicesService(GeneralRepository<Choices> generalRepository, IMapperService mapperService, ChoiceRepository<Choices> choiceRepository)
        {
            _mapperService = mapperService;
            _generalRepository = generalRepository;
            _choiceRepository = choiceRepository;

        }
        public  IEnumerable<ChoiceDTO> GetChoicesByQuestionId(int id)
        {
            var Query = _choiceRepository.GetChoicesByQuestionId(id);
            var Projected =
                Query.ProjectTo<ChoiceDTO>(_mapperService.ConfigurationProvider);
            return  Projected.ToList();

        }
        public async Task Add (AddChoicesDTO addChoicesDTO)
        {
            var query = _mapperService.Map<AddChoicesDTO, Choices>(addChoicesDTO);
            await _generalRepository.Add(query);
        }
        public async Task <bool> Update(UpdateChosicseDTO updateChosicseDTO)
        {
            var Query = _mapperService.Map<UpdateChosicseDTO, Choices>(updateChosicseDTO);
           var Update= await _generalRepository.UpdateInclude(Query,nameof(Choices.Text), nameof(Choices.IsCorrect), nameof(Choices.QuestionId));
            return Update;
        }
        public async Task<bool> Delete(int id)
        {
            await _generalRepository.Delete(id);

            return true;
        }
    }
}
