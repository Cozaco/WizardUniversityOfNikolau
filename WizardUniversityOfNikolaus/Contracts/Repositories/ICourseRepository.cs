using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSmart.Contracts.Repositories;

namespace Contracts.Repositories
{
    public interface ICourseRepository /*: IRepository<Course>*/
    {
        public Task<Course> CreateAsync(Course course); 
        public Task<bool> DeleteAsync(int idCourse);
        public Task<Course> UpdateAsync(Course course);

        public Task<List<Course>> GetStudentCoursesAsync(int idStudent);

        public Task<List<Course>> GetProfessorCoursesAsync(int idProfessor);

        public Task<bool> ValidateInfoAsync(int id, string name, int comission);

        public Task<Course> GetByIdAsync(int idCourse);
    }
}
