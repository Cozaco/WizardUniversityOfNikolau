using Persistance;
using Npgsql;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using Contracts.Models;
using Service;

namespace WizardUniversityOfNikolaus
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //DataBase tabla = DataBase.GetInstance().GetInstance();

            //Materia sae = new Materia("Biologia", 1);

            //await DataBase.GetInstance().materiaRepository.CrearAsync(sae);

            //Alumno lolo= new Alumno("Pablo Lorenzo Battaglini",25);

            StudentService alumnoService = new StudentService();

            //await alumnoService.CreateAsync(lolo);//TODO jajajaja dale boca

            Course matematica1 = new Course("Matemática", 1);

            Course matematica2 = new Course("Matemática", 2);

            Course matematica3 = new Course("Matemática", 3);

            CourseService materiaService= new CourseService();

            //await materiaService.CreateAsync(matematica1);

            //await materiaService.CreateAsync(matematica2);

            //await materiaService.CreateAsync(matematica3);


            await alumnoService.TakeCourseAsync(1, 2);

            await alumnoService.TakeCourseAsync(1, 3);



        }
    }
}