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
        private static readonly NpgsqlDataSource dataSource = NpgsqlDataSource.Create("Host=127.0.0.1;Username=postgres;Password=loba2110;Database=postgres");
        public IStudentRepository studentRepository;
        public IProfessorRepository professorRepository;
        public ICourseRepository courseRepository;


        private DataBase()
        {
            studentRepository= new StudentRepository(dataSource);
            professorRepository=new ProfessorRepository(dataSource);
            courseRepository= new CourseRepository(dataSource); 
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
