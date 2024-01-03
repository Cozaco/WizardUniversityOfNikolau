using Microsoft.AspNetCore.Mvc;
using Contracts.Models;
using Service; // es todo service lo que hay q importar? O podemos solo llamar a student service? por que a cualquier de las 2 posibilidades
using System.Net.Cache;
using UniSmart.API.InterfaceControllers;
using UniSmart.Service;
using UniSmart.API.DTOs.Responses;

namespace UniSmart.API.Controllers
{
    [ApiController]
    [Route("professors")]
    public class ProfessorsControler : ControllerBase //, IProfessorController
    {
        [HttpPost]
        public async Task<ProfessorDTO> CreateAsync([FromBody] ProfessorDTO dto)
        {
            Professor professor = await ServiceSingleton.GetInstance().professorService.CreateAsync(dto.Name, dto.Age);
            ProfessorDTO professorDto = new ProfessorDTO(professor.Name, professor.Age, professor.Id);
            return professorDto;
        }

        [HttpDelete("{idProfessor}/{name}/{age}")]//TODO como corno funciona.(el tema del parametro)        
        public async Task<bool> DeleteAsync(int idProfessor, string name, int age)
        {
            return await ServiceSingleton.GetInstance().professorService.DeleteAsync(idProfessor, name, age);
        }

        [HttpGet("course/{idCourse}")]
        public async Task<List<ProfessorDTO>> GetCourseProfessorsAsync(int idCourse) //TODO cambiar todos los students por studentsDTO
        {
            List<Professor> professors = await ServiceSingleton.GetInstance().professorService.GetCourseProfessorsAsync(idCourse);
            List<ProfessorDTO> professorsDto = new List<ProfessorDTO>();
            foreach (Professor professor in professors)
            {
                professorsDto.Add(new ProfessorDTO(professor));
            }
            return professorsDto;
        }

        [HttpGet("student/{idStudent}")]
        public async Task<List<ProfessorDTO>> GetStudentProfessorsAsync(int idStudent) //Malas formas
        {
            List<Professor> professors = await ServiceSingleton.GetInstance().professorService.GetStudentProfessorsAsync(idStudent);
            List<ProfessorDTO> professorsDto = new List<ProfessorDTO>();
            foreach (Professor professor in  professors)
            {
                professorsDto.Add(new ProfessorDTO(professor));
            }
            return professorsDto;
        }
        [HttpDelete("{idProfessor}/{idCourse}")]
        public async Task<bool> LeaveCourseAsync(int idStudent, int idCourse)
        {
            return await ServiceSingleton.GetInstance().professorService.LeaveCourseAsync(idStudent, idCourse);
        }

        [HttpPost("{idProfessor}/{idCourse}")]
        public async Task<bool> TakeCourseAsync(int idProfessor, int idCourse)
        {
            return await ServiceSingleton.GetInstance().professorService.TakeCourseAsync(idProfessor, idCourse);
        }

        [HttpPut("{id}/{oldName}/{oldAge}/{newName}/{newAge}")]

        public async Task<ProfessorDTO> UpdateAsync(int id, string oldName, int oldAge, string newName, int newAge)
        {
            Professor professor = await ServiceSingleton.GetInstance().professorService.UpdateAsync(id, oldName, oldAge, newName, newAge);
            ProfessorDTO professorDto = new ProfessorDTO(professor.Name, professor.Age, professor.Id);
            return professorDto;
        }
    }
}
