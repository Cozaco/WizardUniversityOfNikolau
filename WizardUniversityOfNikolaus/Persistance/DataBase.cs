using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Models;
using Contracts.Repositories;
using Npgsql;
using Persistance.Repositories;

namespace Persistance
{
    public class DataBase : IDisposable
    {
        private static DataBase? dataBaseInstance;
        private static readonly NpgsqlDataSource dataSource = NpgsqlDataSource.Create("Host=127.0.0.1;Username=postgres;Password=0802;Database=postgres");
        public static IAlumnoRepository alumnoRepository;
        public static IProfesorRepository profesorRepository;
        public static IMateriaRepository materiaRepository;


        private DataBase()
        {
            alumnoRepository= new AlumnoRepository(dataSource);
            profesorRepository=new ProfesorRepository(dataSource);
            materiaRepository= new MateriaRepository(dataSource); 
        }

        public static DataBase GetInstance()
        {
            if (dataBaseInstance == null)
            {
                dataBaseInstance = new DataBase();
                return dataBaseInstance;
            }
            return dataBaseInstance;
        }
        
        public void Dispose()
        {
            if (dataBaseInstance != null)
            {
                return;
            }
            dataSource.Dispose();
        }
    }
}
