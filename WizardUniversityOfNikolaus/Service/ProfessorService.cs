using Contracts.Models;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service
{
    public class ProfessorService 
    {
        private bool InputCheck(string name, int age)
        {
            if (name == "")
            {
                throw new Exception("You must complete the name space");
            }
            if (age < 18)
            {
                throw new Exception("The age number must be more than 18. If not, it is child labour! Call 911");
            }
            return true;
        }

        public async Task<Professor> CreateAsync(string name, int age)//TODO le tengo que pasar los datos no un profesor
        {
            if(!InputCheck(name, age)) { throw new Exception(); }
            Professor professor = new Professor(name, age);
            return await DataBase.GetInstance().professorRepository.CreateAsync(professor);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await DataBase.GetInstance().professorRepository.DeleteAsync(id);
        }

        public async Task<Professor> UpdateAsync(int idProfessor, string newName, int newAge)//TODO Aca también los datos
        {
            if(!InputCheck(newName, newAge)) { throw new Exception(); }
            Professor professor = new Professor(newName, newAge, idProfessor );
            return await DataBase.GetInstance().professorRepository.UpdateAsync(professor); //Cambia las caracteristicas de professor?
            
        }

        public async Task<List<Professor>> GetStudentProfessorsAsync(int idStudent)
        {
            return await DataBase.GetInstance().professorRepository.GetStudentProfessorsAsync(idStudent);
        }

        public async Task<List<Professor>> GetCourseProfessorsAsync(int idCourse)
        {
            return await DataBase.GetInstance().professorRepository.GetCourseProfessorsAsync(idCourse);
        }

        public async Task<bool> TakeCourseAsync(int idProfessor, int idCourse)
        {
            return await DataBase.GetInstance().professorRepository.TakeCourseAsync(idProfessor, idCourse);
        }

        public async Task<bool> LeaveCourseAsync(int idProfessor, int idCourse)
        {
            return await DataBase.GetInstance().professorRepository.LeaveCourseAsync(idProfessor,idCourse);
        }
    }
}
