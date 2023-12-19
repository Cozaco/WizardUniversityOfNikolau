using Persistance;
using Npgsql;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using Contracts.Models;

namespace WizardUniversityOfNikolaus
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            DataBase tabla = DataBase.GetInstance();

            Materia sae = new Materia("Biologia", 1);

            await DataBase.materiaRepository.CrearAsync(sae);

        }
    }
}