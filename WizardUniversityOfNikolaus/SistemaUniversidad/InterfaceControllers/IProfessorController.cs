using UniSmart.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using UniSmart.API.DTOs.Responses;

namespace UniSmart.API.InterfaceControllers
{
    public interface IProfessorController
    {
        public Task<ProfessorDTO> CreateAsync([FromBody] ProfessorDTO professor);
        public Task<bool> DeleteAsync(int idProfessor);

        public Task<ProfessorDTO> UpdateAsync([FromBody] ProfessorDTO professor);

        public Task<List<ProfessorDTO>> GetStudentProfessorsAsync(int idStudent);

        public Task<List<ProfessorDTO>> GetCourseProfessorsAsync(int idCourse);

        public Task<bool> TakeCourseAsync(int idProfessor, int idCourse);

        public Task<bool> LeaveCourseAsync(int idProfessor, int idCourse);
    }
}