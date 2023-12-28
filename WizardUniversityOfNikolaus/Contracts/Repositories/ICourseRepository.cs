using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface ICourseRepository
    {
        public Task CreateAsync(Course course);
        public Task<bool> DeleteAsync(int idCourse);
        public Task<bool> UpdateAsync(Course course);

        public Task GetStudentCoursesAsync(int idStudent);

        public Task GetProfessorCoursesAsync(int idProfessor);
    }
}
