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

            AlumnoService alumnoService = new AlumnoService();

            //await alumnoService.CreateAsync(lolo);//TODO jajajaja dale boca

            Materia matematica1 = new Materia("Matemática", 1);

            Materia matematica2 = new Materia("Matemática", 2);

            Materia matematica3 = new Materia("Matemática", 3);

            MateriaService materiaService= new MateriaService();

            //await materiaService.CreateAsync(matematica1);

            //await materiaService.CreateAsync(matematica2);

            //await materiaService.CreateAsync(matematica3);


            await alumnoService.InscribirAMateriaAsync(1, 2);

            await alumnoService.InscribirAMateriaAsync(1, 3);



        }
    }
}