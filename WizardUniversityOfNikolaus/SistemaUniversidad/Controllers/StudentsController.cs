using Microsoft.AspNetCore.Mvc;
using Contracts.Models;
using Service; // es todo service lo que hay q importar? O podemos solo llamar a student service? por que a cualquier de las 2 posibilidades
using UniSmart.API.DTOs;
using System.Net.Cache;

namespace SistemaUniversidad.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentsController : ControllerBase
    {
        private StudentService _studentService;

        [HttpPost]
        public async Task<StudentDTO> CreateAsync([FromBody] StudentDTO dto)
        {
            Student student = await _studentService.CreateAsync(dto.GetName(), dto.GetAge());
            StudentDTO studentdto = new StudentDTO(student.GetName(), student.GetAge(), student.GetId());
            return studentdto;
        }


        // TODO hacer GetId en repository y service y agregarlo aca. Agregar las demas funciones
    }
}