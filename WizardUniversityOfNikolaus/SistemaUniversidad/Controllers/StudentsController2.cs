using Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using UniSmart.API.DTOs.Responses;
using UniSmart.Service;

namespace UniSmart.API.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentsController2 : ControllerBase
    {
        [HttpGet]
        public async Task<StudentDTO> GetStudentAsync([FromBody] StudentDTO dto)
        {

        }
        [HttpPost]
        public async Task<StudentDTO> CreateAsync([FromBody] StudentDTO dto)
        {

        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await ServiceSingleton.GetInstance().studentService.DeleteAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<Student> UpdateAsync([FromBody] StudentDTO dto) //TODO que reciba un DTO [FromBody]
        {
            return await ServiceSingleton.GetInstance().studentService.UpdateAsync((int)dto.Id, dto.Name, dto.Age);
        }
    }
}
