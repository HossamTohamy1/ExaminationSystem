namespace Quizzes_System.Data
{
    using Microsoft.AspNetCore.Identity;
    using Quizzes_System.Models;

    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ProfilePicture { get; set; }

        public virtual Instructor? Instructor { get; set; }
        public virtual Student? Student { get; set; }
    }
}
