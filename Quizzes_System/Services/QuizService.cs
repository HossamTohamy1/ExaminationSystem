using Quizzes_System.DTOs.Quiz;
using Quizzes_System.DTOs.QuizParticipation;
using Quizzes_System.Mapping;
using Quizzes_System.Models;
using Quizzes_System.Models.Enum;
using Quizzes_System.Repositories;

namespace Quizzes_System.Services
{
   
    public class QuizService
    {
        GeneralRepository<Quizzes> _generalRepository;
        QuizRepositories<Quizzes> _quizRepositories;
        IMapperService _mapperService;
        public QuizService( GeneralRepository<Quizzes> generalRepository,IMapperService mapperService, QuizRepositories<Quizzes> quizRepositories)
        {
            _mapperService = mapperService;
            _generalRepository = generalRepository;
            _quizRepositories = quizRepositories;

        }

        public IEnumerable<Quizzes> GetQuizByCourseId(int id)
        {
            var res =  _quizRepositories.GetQuizByCourseId(id);
            return res;
        }
        public async Task Add(AddQuizDTO QuizDTO)
        {
            var query = _mapperService.Map<AddQuizDTO, Quizzes>(QuizDTO);
            await _generalRepository.Add(query);
        }
        public async Task <bool> Update( UpdateQuizDTO QuizDTO)
        {
           var query= _mapperService.Map<UpdateQuizDTO, Quizzes>(QuizDTO);
           var Update= await _generalRepository.UpdateInclude(query, nameof(Quizzes.Title), nameof(Quizzes.Description), nameof(Quizzes.CourseId));
            return Update;
        }
        public async Task<bool> Delete(int id)
        {
            await _generalRepository.Delete(id);

            return true;
        }
        public IEnumerable<QuizWithQuestionsDTO> TakeQuizAsync(int quizId)
        {
            return _quizRepositories.GetQuizWithQuestionsDTOAsync(quizId);
        }
        public async Task SubmitQuizAsync(SubmitQuizDTO dto)
        {
            var exam = _mapperService.Map<StudentExam>(dto);
            exam.StartTime = DateTime.Now;
            
            exam.Answers = new List<StudentAnswer>();

            decimal totalScore = 0;

            foreach (var ansDto in dto.Answers)
            {
                var question = await _quizRepositories.GetQuestionAsync(ansDto.QuestionId);
                if (question == null) continue;

                var choices = await _quizRepositories.GetChoicesForQuestionAsync(ansDto.QuestionId);
                decimal mark = 0;

                if (ansDto.ChoiceId.HasValue)
                {
                    var selected = choices.FirstOrDefault(c => c.Id == ansDto.ChoiceId.Value);
                    if (selected != null && selected.IsCorrect)
                        mark = 1;
                }
                else if (!string.IsNullOrWhiteSpace(ansDto.AnswerText))
                {
                    var correctAnswer = choices.FirstOrDefault(c => c.IsCorrect);
                    if (correctAnswer != null &&
                        correctAnswer.Text.Trim().ToLower() == ansDto.AnswerText.Trim().ToLower())
                        mark = 1;
                }

                var answer = new StudentAnswer
                {
                    QuestionId = ansDto.QuestionId,
                    MarksObtained = mark
                };

                if (question.Type == QuestionType.MultipleChoice)
                {
                    answer.ChoiceId = ansDto.ChoiceId;
                    answer.AnswerText = null;
                }
                else if (question.Type == QuestionType.ShortAnswer)
                {
                    answer.ChoiceId = null;
                    answer.AnswerText = ansDto.AnswerText;
                }

                exam.Answers.Add(answer);
                totalScore += mark;
            }

            exam.EndTime = DateTime.Now;
            exam.Score = totalScore;

            await _quizRepositories.AddStudentExamAsync(exam);
        }

    }
}
