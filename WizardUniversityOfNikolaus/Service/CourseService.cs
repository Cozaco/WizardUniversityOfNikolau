using Contracts.Models;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CourseService 
    {
        public async Task<List<Student>> GetCourseStudentsAsync(int idCourse)
        {
            return await DataBase.GetInstance().studentRepository.GetCourseStudentsAsync(idCourse);
        }
        public async Task<List<Professor>> GetCourseProfessorsAsync(int idCourse)
        {
            return await DataBase.GetInstance().professorRepository.GetCourseProfessorsAsync(idCourse);
        }
        private bool InputCheck(string name,int comission)
        {
            if (name == "")
            {
                throw new Exception("You must complete the name space");
            }
            if (comission < 1)
            {
                throw new Exception("The comission number must be greater than 0");
            }
            return true;
        }
        
        public async Task<Course> CreateAsync(string name,int comission)//TODO Check
        {
            if (!InputCheck(name, comission)) { throw new Exception(); }
            Course course = new Course(name, comission);
            return await DataBase.GetInstance().courseRepository.CreateAsync(course);
            
        }

        public async Task<bool> DeleteAsync(int id, string name, int comission)
        {
            if (!await DataBase.GetInstance().courseRepository.ValidateInfoAsync(id, name, comission))
            { 
                throw new Exception("The input is wrong, please check the info provided"); 
            }
            return await DataBase.GetInstance().courseRepository.DeleteAsync(id);
        }

        public async Task<Course> UpdateAsync(string oldName,int oldComission,string newName,int newComission,int idCourse)//TODO check
        {
            if(!await DataBase.GetInstance().courseRepository.ValidateInfoAsync(idCourse, oldName, oldComission))
            {
                throw new Exception("The input is wrong, please check the info provided");//TODO como le hago llegar eso al usuario?
            }
            if (!InputCheck(newName, newComission)) { throw new Exception(); }
            Course course = new Course(newName, newComission,idCourse);
            return await DataBase.GetInstance().courseRepository.UpdateAsync(course);
            
        }

        public async Task<bool> SubscribeProfessorAsync(int idProfessor, int idCourse)
        {
            return await DataBase.GetInstance().professorRepository.TakeCourseAsync(idProfessor, idCourse);
        }

        public async Task<bool> UnsubscribeProfessorAsync(int idProfessor, int idCourse)
        {
            return await DataBase.GetInstance().professorRepository.LeaveCourseAsync(idProfessor, idCourse);
        }

        //Inscribir alumno en la materia. Primero se cuenta cuantas materias cursa, se chequea con el máximo de materias disponibles y de pasar,
        //se inscribe al alumno en la materia.
        public async Task<bool> SubscribeStudentAsync(int idStudent, int idCourse)//TODO mirar lo del try
        {
            int? materiasCursadas = (int)await DataBase.GetInstance().studentRepository.CountCoursesAsync(idStudent);

            if (materiasCursadas.HasValue && materiasCursadas >= 2)
            {
                return false;
            }
            return await DataBase.GetInstance().studentRepository.TakeCourseAsync(idStudent, idCourse);
        }


        public async Task<bool> UnsubscribeStudentAsync(int idAlumno, int idMateria)
        {
            return await DataBase.GetInstance().studentRepository.LeaveCourseAsync(idAlumno, idMateria);
        }

        public async Task<Course> GetCourseAsync(int idCourse)
        {
            return await DataBase.GetInstance().courseRepository.GetCourseAsync(idCourse);  
        }

        public async Task<List<Student>> GetStudents(int idCourse)
        {
            return await DataBase.GetInstance().studentRepository.GetCourseStudentsAsync(idCourse);
        }

        public async Task<List<Professor>> GetProfessors(int idCourse)
        {
            return await DataBase.GetInstance().professorRepository.GetStudentProfessorsAsync(idCourse);
        }
    }
}
