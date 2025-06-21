namespace Quizzes_System.Models
{
    public class Result : BaseEntity
    {
        public decimal TotalMarks { get; set; }
        public decimal ObtainedMarks { get; set; }
        public decimal Percentage { get; set; }
        public string Grade { get; set; }
        public string Remarks { get; set; }

        public int StudentExamId { get; set; }

        public StudentExam StudentExam { get; set; }
    }
}
