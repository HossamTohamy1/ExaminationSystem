using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quizzes_System.Models;
using System.Diagnostics;

namespace Quizzes_System.Data
{
    public class QuizzesDbContext : IdentityDbContext<ApplicationUser>
    {
        public QuizzesDbContext(DbContextOptions<QuizzesDbContext> options)
         : base(options)
        {
        }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Quizzes> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choices> Choices { get; set; }
        public DbSet<StudentExam> StudentExams { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<QuizQuestions> QuizQuestions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentInstructor>()
                .HasKey(si => new { si.StudentId, si.InstructorId });

            modelBuilder.Entity<StudentInstructor>()
                .HasOne(si => si.Student)
                .WithMany(s => s.StudentInstructors)
                .HasForeignKey(si => si.StudentId)
                .OnDelete(DeleteBehavior.Restrict);  

            modelBuilder.Entity<StudentInstructor>()
                .HasOne(si => si.Instructor)
                .WithMany(i => i.StudentInstructors)
                .HasForeignKey(si => si.InstructorId)
                .OnDelete(DeleteBehavior.Restrict); 

           
            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.HasOne(i => i.User)
                      .WithOne(u => u.Instructor)
                      .HasForeignKey<Instructor>(i => i.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => e.StudentId).IsUnique();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.EnrollmentDate).HasDefaultValueSql("GETUTCDATE()");
                entity.HasOne(s => s.User)
                      .WithOne(u => u.Student)
                      .HasForeignKey<Student>(s => s.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasIndex(e => e.Code).IsUnique();
                entity.HasOne(c => c.Instructor)
                      .WithMany(i => i.Courses)
                      .HasForeignKey(c => c.InstructorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Quizzes>(entity =>
            {
                entity.HasOne(q => q.Course)
                      .WithMany(c => c.Quizzes)
                      .HasForeignKey(q => q.CourseId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<QuizQuestions>()
                .HasKey(qq => new { qq.QuizId, qq.QuestionId });

            modelBuilder.Entity<QuizQuestions>()
                .HasOne(qq => qq.Quiz)
                .WithMany(q => q.QuizQuestions)
                .HasForeignKey(qq => qq.QuizId);

            modelBuilder.Entity<QuizQuestions>()
                .HasOne(qq => qq.Question)
                .WithMany(q => q.QuizQuestions)
                .HasForeignKey(qq => qq.QuestionId);

            modelBuilder.Entity<Choices>(entity =>
            {
                entity.HasOne(c => c.Question)
                      .WithMany(q => q.Choices)
                      .HasForeignKey(c => c.QuestionId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity.HasOne(sc => sc.Student)
                      .WithMany(s => s.Courses)
                      .HasForeignKey(sc => sc.StudentId);

                entity.HasOne(sc => sc.Course)
                      .WithMany(c => c.Students)
                      .HasForeignKey(sc => sc.CourseId);
            });

            modelBuilder.Entity<StudentExam>(entity =>
            {
                entity.HasOne(se => se.Student)
                      .WithMany(s => s.Exams)
                      .HasForeignKey(se => se.StudentId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(se => se.Quiz)
                      .WithMany(q => q.StudentExams)
                      .HasForeignKey(se => se.QuizId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StudentAnswer>(entity =>
            {
                entity.HasOne(sa => sa.StudentExam)
                      .WithMany(se => se.Answers)
                      .HasForeignKey(sa => sa.StudentExamId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(sa => sa.Question)
                      .WithMany(q => q.StudentAnswers)
                      .HasForeignKey(sa => sa.QuestionId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sa => sa.SelectedChoice)
                      .WithMany()
                      .HasForeignKey(sa => sa.ChoiceId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasOne(r => r.StudentExam)
                      .WithOne(se => se.Result)
                      .HasForeignKey<Result>(r => r.StudentExamId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(BaseEntity.CreatedAt))
                        .HasDefaultValueSql("GETUTCDATE()");

                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(BaseEntity.IsActive))
                        .HasDefaultValue(true);

                    
                    var method = typeof(QuizzesDbContext)
                        .GetMethod(nameof(SetSoftDeleteFilter), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                        ?.MakeGenericMethod(entityType.ClrType);

                    method?.Invoke(null, new object[] { modelBuilder });
                }
            }
        }

        private static void SetSoftDeleteFilter<TEntity>(ModelBuilder modelBuilder) where TEntity : BaseEntity
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(e => !e.IsDeleted);
        }

    }
}
