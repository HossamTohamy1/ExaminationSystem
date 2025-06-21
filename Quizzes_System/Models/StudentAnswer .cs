namespace Quizzes_System.Models
{
    public class StudentAnswer : BaseEntity
    {
        public string AnswerText { get; set; }
        public decimal? MarksObtained { get; set; }

        
        public int StudentExamId { get; set; }
        public int QuestionId { get; set; }
        public int? ChoiceId { get; set; } 

        
        public StudentExam StudentExam { get; set; }
        public Question Question { get; set; }
        public Choices SelectedChoice { get; set; }
    }
}
