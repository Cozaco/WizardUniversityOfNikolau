using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IStudentRepository //TODO Agregar un existbyid para chequear si la id que me psan está.Usar SELECT EXISTS (query)(execute scalar (bool)) 
    {
        public Task<Student> CreateAsync(Student student);
        
        public Task<bool> DeleteAsync(int idStudent);

        public Task<Student> UpdateAsync(Student student);

        public Task<List<Student>> GetCourseStudentsAsync(int idCourse);

        public Task<List<Student>> GetProfessorStudentsAsync(int idProfessor);

        public Task<long> CountCoursesAsync(int idStudent);

        public Task<bool> TakeCourseAsync(int idStudent, int idCourse);

        public Task<bool> LeaveCourseAsync(int idStudent, int idCourse);

        public Task<bool> ValidateInfoAsync(int idStudent, string name, int age);

        public Task<Student> GetByIdAsync(int idStudent);
        public Task<bool> CheckPasswordAsync(string user, string password);

    }
}
