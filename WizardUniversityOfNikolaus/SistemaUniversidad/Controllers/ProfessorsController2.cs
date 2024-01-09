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
        [HttpGet]
        public async Task<StudentDTO> GetProfessorAsync([FromBody] StudentDTO dto)
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
        public async Task<ProfessorDTO> UpdateAsync([FromBody] ProfessorDTO dto) //TODO devuelve un professor, deberia devolver un DTO?
        {
            Professor professor = await ServiceSingleton.GetInstance().professorService.UpdateAsync((int)dto.Id, dto.Name, dto.Age);
            return new ProfessorDTO(); //TODO terminar esto
        }
    }
}
