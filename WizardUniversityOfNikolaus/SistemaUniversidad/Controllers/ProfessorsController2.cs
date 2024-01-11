using Microsoft.AspNetCore.Mvc;
using Contracts.Models;
using Service; // es todo service lo que hay q importar? O podemos solo llamar a student service? por que a cualquier de las 2 posibilidades
using System.Net.Cache;
using UniSmart.API.InterfaceControllers;
using UniSmart.Service;
using UniSmart.API.DTOs.Responses;
using UniSmart.API.DTOs.Requests;

namespace UniSmart.API.Controllers
{
    [ApiController]
    [Route("professors")]
    public class ProfessorsControler2 : ControllerBase
    {
        [HttpGet("{idProfessor}")]
        public async Task<ProfessorDTO> GetProfessorAsync(int idProfessor)//TODO Es para devolver un profesor?
        {

        }
        
        [HttpGet("{idProfessor}/students")]
        public async Task<List<StudentDTO>> GetStudents(int idProfessor)
        {

        }

        [HttpGet("{idProfessor}/courses")]
        public async Task<List<CourseDTO>> GetCourses(int idProfessor)
        {

        }

        [HttpPost]
        public async Task<ProfessorDTO> CreateAsync([FromBody] ProfessorCreateDTO dto)
        {

        }

        [HttpDelete("{id}")]   
        public async Task<bool> DeleteAsync(int id)
        {
            return await ServiceSingleton.GetInstance().professorService.DeleteAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ProfessorDTO> UpdateAsync([FromBody] ProfessorCreateDTO dto,int id) 
        {
            Professor professor = await ServiceSingleton.GetInstance().professorService.UpdateAsync(id, dto.Name, dto.Age);
            return new ProfessorDTO(); //TODO terminar esto
        }
    }
}
