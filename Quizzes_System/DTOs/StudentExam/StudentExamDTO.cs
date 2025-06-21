namespace Quizzes_System.DTOs.StudentExam
{
    public class StudentExamDTO
    {
        
            public int ExamId { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public decimal Score { get; set; }
            public string Status { get; set; }
        

    }
}
