using Contracts.Repositories;
using Npgsql;
using Persistance;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSmart.Service
{
    public class ServiceSingleton //TODO Hacer singleton como en Database
    {
        private static ServiceSingleton? serviceInstance;
        public StudentService studentService;
        public ProfessorService professorService;
        public CourseService courseService;

        private ServiceSingleton()
        {
            this.studentService = new StudentService();
            this.courseService = new CourseService();
            this.professorService= new ProfessorService();
        }

        public static ServiceSingleton GetInstance()
        {
            if (serviceInstance == null)
            {
                serviceInstance = new ServiceSingleton();
                return serviceInstance;
            }
            return serviceInstance;
        }
    }
}
