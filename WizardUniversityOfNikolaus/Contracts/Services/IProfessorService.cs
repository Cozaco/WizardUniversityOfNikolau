using UniSmart.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSmart.Contracts.Services
{
    public interface IProfessorService
    {
        public Task<Professor> CreateAsync(string name, int age);
        public Task<Professor> UpdateAsync(string name, int age, int id);
        public Task DeleteAsync(int id);
        public Task<Professor> GetByIdAsync(int id);
        public Task<List<Student>> GetStudentsAsync(int id);
        public Task<List<Course>> GetCoursesAsync(int id);
        public void InputCheck(string name, int age);
        public Task<bool> CheckPasswordAsync(string user, string password);
    }
}
