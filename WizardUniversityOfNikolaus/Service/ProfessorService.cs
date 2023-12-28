using Contracts.Models;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProfessorService 
    {
        public async Task CreateAsync(Professor professor)//TODO le tengo que pasar los datos no un profesor
        {
            await DataBase.GetInstance().professorRepository.Create(professor);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return DataBase.GetInstance().professorRepository.DeleteAsync(id);
        }

        public Task<bool> UpdateAsync(Professor professor)//TODO Aca también los datos
        {
            return DataBase.GetInstance().professorRepository.UpdateAsync(professor);
        }

        public async Task GetStudentProfessorsAsync(int idStudent)
        {
            await DataBase.GetInstance().professorRepository.GetStudentProfessorsAsync(idStudent);
        }

        public async Task GetCourseProfessorsAsync(int idCourse)
        {
            await DataBase.GetInstance().professorRepository.GetCourseProfessorsAsync(idCourse);
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
