using Contracts.Models;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UniSmart.Contracts.Services;

namespace Service
{
    public class ProfessorService : IProfessorService
    {
        public async Task<Professor> CreateAsync(string name, int age)
        {
            InputCheck(name, age);
            Professor professor = new Professor(name, age);
            return await DataBase.GetInstance().professorRepository.CreateAsync(professor);
        }

        public async Task DeleteAsync(int id)
        {
            await DataBase.GetInstance().professorRepository.DeleteAsync(id);
        }

        public async Task<Professor> UpdateAsync(string newName, int newAge, int idProfessor)
        {
            InputCheck(newName, newAge);
            Professor professor = new Professor(newName, newAge, idProfessor );
            return await DataBase.GetInstance().professorRepository.UpdateAsync(professor); //Cambia las caracteristicas de professor?         
        }
        public async Task<Professor> GetByIdAsync(int id)
        {
            return await DataBase.GetInstance().professorRepository.GetByIdAsync(id);
        }
        public async Task<List<Student>> GetStudentsAsync(int idProfessor)
        {
            return await DataBase.GetInstance().studentRepository.GetProfessorStudentsAsync(idProfessor);
        }
        public async Task<List<Course>> GetCoursesAsync(int idProfessor)
        {
            return await DataBase.GetInstance().courseRepository.GetProfessorCoursesAsync(idProfessor);
        }
        public void InputCheck(string name, int age)
        {
            if (name == "")
            {
                throw new Exception("You must complete the name space");
            }
            if (age < 18)
            {
                throw new Exception("The age number must be more than 18. If not, it is child labour! Call 911");
            }
        }
    }
}
