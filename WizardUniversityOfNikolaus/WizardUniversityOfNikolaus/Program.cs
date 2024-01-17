using UniSmart.Persistance;
using Npgsql;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using UniSmart.Contracts.Models;
using UniSmart.Service;
using Microsoft.Extensions.Hosting;
using UniSmart.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;
using UniSmart.Persistance.Repositories;
using UniSmart.Contracts.Services;


namespace WizardUniversityOfNikolaus
{
    internal class Program
    {
        
        static async Task Main(string[] args)
        {
            
            
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddTransient<ICourseService, CourseService>();
            builder.Services.AddTransient<IStudentService, StudentService>();
            builder.Services.AddTransient<IProfessorService, ProfessorService>();
            builder.Services.AddTransient<ICourseRepository, CourseRepository>();
            builder.Services.AddTransient<IStudentRepository, StudentRepository>();
            builder.Services.AddTransient<IProfessorRepository, ProfessorRepository>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IDataSource, SqlDataSource>();
            using IHost host = builder.Build();
            

            //DataBase tabla = DataBase.GetInstance().GetInstance();

            //Materia sae = new Materia("Biologia", 1);

            //await DataBase.GetInstance().materiaRepository.CrearAsync(sae);

            //Alumno lolo= new Alumno("Pablo Lorenzo Battaglini",25);

            IStudentService alumnoService = host.Services.GetService<IStudentService>()!;

            //await alumnoService.CreateAsync(lolo);//TODO jajajaja dale boca

            Course matematica1 = new Course("Matemática", 1);

            Course matematica2 = new Course("Matemática", 2);

            Course matematica3 = new Course("Matemática", 3);

            ICourseService materiaService= host.Services.GetService<ICourseService>()!;

            //await materiaService.CreateAsync(matematica1);

            //await materiaService.CreateAsync(matematica2);

            //await materiaService.CreateAsync(matematica3);


            await alumnoService.GetByIdAsync(1);



        }
    }
}