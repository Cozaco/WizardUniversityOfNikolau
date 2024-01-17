using UniSmart.Contracts.Repositories;
using UniSmart.Persistance;
using UniSmart.Persistance.Repositories;
using UniSmart.Service;
using UniSmart.API.Middleware;
using UniSmart.Contracts.Services;

namespace SistemaUniversidad

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<ICourseService, CourseService>();
            builder.Services.AddTransient<IStudentService, StudentService>();
            builder.Services.AddTransient<IProfessorService,ProfessorService>();
            builder.Services.AddTransient<ICourseRepository , CourseRepository>();
            builder.Services.AddTransient<IStudentRepository, StudentRepository>();
            builder.Services.AddTransient<IProfessorRepository, ProfessorRepository>();
            builder.Services.AddTransient<IDataSource, SqlDataSource>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            var app = builder.Build();

            app.UseMiddleware<HandleExceptionMiddleware>();//OJO es importante el orden , el try tiene que ir primero porque el otro middleware tiene excepciones
            app.UseMiddleware<AuthenticationMiddleware>();
            
            // Configure the HTTP request pipeline.
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