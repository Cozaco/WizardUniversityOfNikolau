using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSmart.Contracts.Repositories;

namespace Contracts.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        //public Task CreateAsync(Course course); 
        public Task<bool> DeleteAsync(int idCourse);
        public Task UpdateAsync(Course course);

        public Task GetStudentCoursesAsync(int idStudent);

        public Task GetProfessorCoursesAsync(int idProfessor);

        public Task<bool> ValidateInfo(int id, string name, int comission);
    }
}
