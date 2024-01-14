using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSmart.Contracts.Services
{
    public interface ICourseService
    {
        public Task<Course> CreateAsync(string name, int comission);
        public Task<Course> UpdateAsync(string name, int comission,int id);
        public Task DeleteAsync(int id);
        public Task<Course> GetByIdAsync(int id);
        public Task<List<Student>> GetStudentsAsync(int id);
        public Task<List<Professor>> GetProfessorsAsync(int id);
        public Task SubscribeStudentAsync(int idCourse, int idStudent);
        public Task SubscribeProfessorAsync(int idCourse, int idProfessor);
        public Task UnsubscribeStudentAsync(int idCourse, int idStudent);
        public Task UnsubscribeProfessorAsync(int idCourse, int idProfessor);
        public void InputCheck(string name, int comission);//TODO DATA ANOTATIONS (Fran y Lolo)

    }
}
