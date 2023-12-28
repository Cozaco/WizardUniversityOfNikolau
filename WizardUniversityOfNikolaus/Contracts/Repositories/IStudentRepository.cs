using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IStudentRepository
    {
        public Task CrearAsync(Student student);
        
        public Task<bool> DeleteAsync(int idStudent);

        public Task<bool> UpdateAsync(Student student);

        public Task GetCourseStudentsAsync(int idMateria);

        public Task GetProfessorStudentsAsync(int idProfessor);

        public Task<long> CountCoursesAsync(int idStudent);

        public Task<bool> TakeCourseAsync(int idStudent, int idMateria);

        public Task<bool> LeaveCourseAsync(int idStudent, int idMateria);

    }
}
