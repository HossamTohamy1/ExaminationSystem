using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quizzes_System.Data;
using Quizzes_System.Mapping;
using Quizzes_System.Repositories;
using Quizzes_System.Services;
using System.Diagnostics;

namespace Quizzes_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Identity Configuration
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<QuizzesDbContext>()
            .AddDefaultTokenProviders();

            // DbContext Configuration
            builder.Services.AddDbContext<QuizzesDbContext>(options =>
            {
                options
                    .UseSqlServer("Data Source=DESKTOP-JC03CE9;Initial Catalog=Quizzes2;Integrated Security=True;Encrypt=False;Trust Server Certificate=True")
                    .LogTo(message => Debug.WriteLine(message), LogLevel.Information)
                    .EnableSensitiveDataLogging(true)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            // Services Registration
            builder.Services.AddScoped(typeof(GeneralRepository<>));
            builder.Services.AddScoped(typeof(QuizRepositories<>));
            builder.Services.AddScoped(typeof(QuestionRepository<>));
            builder.Services.AddScoped(typeof(ChoiceRepository<>));

            builder.Services.AddScoped<CourseService>(); 
            builder.Services.AddScoped<QuizService>(); 
            builder.Services.AddScoped<QuestionService>(); 
            builder.Services.AddScoped<ChoicesService>(); 
            builder.Services.AddScoped<ResultServices>(); 

            builder.Services.AddScoped<IMapperService, AutoMapperService>();

            // AutoMapper and MVC
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(Program));

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
