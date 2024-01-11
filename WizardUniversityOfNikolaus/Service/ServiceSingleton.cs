﻿using Contracts.Models;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UniSmart.Contracts.Services;
using Service;

namespace UniSmart.Service
{
    public class ServiceSingleton //TODO Hacer singleton como en Database
    {
        private static ServiceSingleton? serviceInstance;
        public IStudentService studentService;
        public IProfessorService professorService;
        public ICourseService courseService;

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
