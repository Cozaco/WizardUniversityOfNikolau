using UniSmart.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using UniSmart.API.DTOs.Responses;

namespace UniSmart.API.InterfaceControllers
{
    public interface IStudentsController
    {
        public Task<StudentDTO> CreateAsync([FromBody] StudentDTO studentDto);

        public Task<bool> DeleteAsync(int idStudent);

        public Task<Student> UpdateAsync([FromBody] StudentDTO studentDto);

        public Task<List<Student>> GetCourseStudentsAsync(int idMateria);

        public Task<List<Student>> GetProfessorStudentsAsync(int idProfessor);

        public Task<bool> TakeCourseAsync(int idStudent, int idMateria);

        public Task<bool> LeaveCourseAsync(int idStudent, int idMateria);

    }
}
