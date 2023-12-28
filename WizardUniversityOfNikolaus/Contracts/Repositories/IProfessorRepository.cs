using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IProfessorRepository
    {
        public Task Create(Professor professor);
        public Task<bool> DeleteAsync(int idProfessor);

        public Task<bool> UpdateAsync(Professor professor);

        public Task GetStudentProfessorsAsync(int idStudent);

        public Task GetCourseProfessorsAsync(int idCourse);

        public Task<bool> TakeCourseAsync(int idProfessor, int idCourse);

        public Task<bool> LeaveCourseAsync(int idProfessor, int idCourse);
    }
}
