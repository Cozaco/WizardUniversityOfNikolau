using Contracts.Models;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSmart.Contracts.Services;
using UniSmart.Contracts.Exceptions;

namespace Service
{
    public class CourseService : ICourseService 
    {
        public async Task<Course> CreateAsync(string name,int comission)
        {
            InputCheck(name, comission);
            Course course = new Course(name, comission);
            return await DataBase.GetInstance().courseRepository.CreateAsync(course);       
        }

        public async Task DeleteAsync(int id)
        {
            await DataBase.GetInstance().courseRepository.DeleteAsync(id);
        }

        public async Task<Course> UpdateAsync(string newName,int newComission,int idCourse)
        {
            InputCheck(newName, newComission);
            Course course = new Course(newName, newComission,idCourse);
            return await DataBase.GetInstance().courseRepository.UpdateAsync(course);    
        }

        public async Task<Course> GetByIdAsync(int idCourse)
        {
            return await DataBase.GetInstance().courseRepository.GetByIdAsync(idCourse);
        }

        public async Task<List<Student>> GetStudentsAsync(int idCourse)
        {
            return await DataBase.GetInstance().studentRepository.GetCourseStudentsAsync(idCourse);
        }

        public async Task<List<Professor>> GetProfessorsAsync(int idCourse)
        {
            return await DataBase.GetInstance().professorRepository.GetStudentProfessorsAsync(idCourse);
        }

        public async Task SubscribeProfessorAsync(int idProfessor, int idCourse)
        {
            await DataBase.GetInstance().professorRepository.TakeCourseAsync(idProfessor, idCourse);
        }
        //Inscribir alumno en la materia. Primero se cuenta cuantas materias cursa, se chequea con el máximo de materias disponibles y de pasar,
        //se inscribe al alumno en la materia.
        public async Task SubscribeStudentAsync(int idStudent, int idCourse)
        {
            int? materiasCursadas = (int)await DataBase.GetInstance().studentRepository.CountCoursesAsync(idStudent);

            if (materiasCursadas.HasValue && materiasCursadas >= 2)
            {
                throw new TooManyCoursesException();
            }
            await DataBase.GetInstance().studentRepository.TakeCourseAsync(idStudent, idCourse);
        }

        public async Task UnsubscribeProfessorAsync(int idProfessor, int idCourse)
        {
            await DataBase.GetInstance().professorRepository.LeaveCourseAsync(idProfessor, idCourse);
        }

        public async Task UnsubscribeStudentAsync(int idStudent, int idCourse)
        {
            await DataBase.GetInstance().studentRepository.LeaveCourseAsync(idStudent, idCourse);
        }
        public void InputCheck(string name, int comission)
        {
            if (name == "")
            {
                throw new Exception("You must complete the name space");
            }
            if (comission < 1)
            {
                throw new Exception("The comission number must be greater than 0");
            }
        }
    }
}
