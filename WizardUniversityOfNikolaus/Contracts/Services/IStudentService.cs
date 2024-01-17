using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSmart.Contracts.Services
{
    public interface IStudentService
    {
        public Task<Student> CreateAsync(string name, int age);
        public Task<Student> UpdateAsync(string name, int age, int id);
        public Task DeleteAsync(int id);
        public Task<Student> GetByIdAsync(int id);
        public Task<List<Course>> GetCoursesAsync(int id);
        public Task<List<Professor>> GetProfessorsAsync(int id);
        public void InputCheck(string name, int age);
        public Task<bool> CheckPasswordAsync(string user, string password);
    }
}
