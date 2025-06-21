namespace Quizzes_System.ViewModels.Quiz
{
    public class UpdateQuizViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
    }
}
