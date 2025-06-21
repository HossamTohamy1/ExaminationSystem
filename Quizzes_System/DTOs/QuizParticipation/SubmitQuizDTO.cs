using Quizzes_System.Models.Enum;

namespace Quizzes_System.DTOs.QuizParticipation
{
    public class SubmitQuizDTO
    {
        public int QuizId { get; set; }
        public int StudentId { get; set; }
        public int Status { get; set; }

        public List<SubmitAnswerDTO> Answers { get; set; }
    }
}
