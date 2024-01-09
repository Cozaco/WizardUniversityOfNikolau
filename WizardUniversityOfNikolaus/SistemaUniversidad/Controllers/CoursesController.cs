using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniSmart.API.DTOs.Requests;
using UniSmart.API.DTOs.Responses;

namespace UniSmart.API.ControllersSS
{
    [ApiController]
    [Route("courses")]
    public class CoursesController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<CourseDTO> GetCourseAsync(int id)
        {

        }

        [HttpGet("{idCourse}/students/{idStudent}")]
        public async Task<StudentDTO> GetStudent(int idCourse, int idStudent)
        {

        }

        [HttpGet("{idCourse}/professors/{idProfessor}")]
        public async Task<ProfessorDTO> GetProfessor(int idCourse, int idProfessor)
        {

        }

        [HttpPost] 
        public async Task<CourseDTO> CreateAsync([FromBody]CourseCreateDTO dto)
        {

        }

        [HttpPost("{idCourse}/students/")]
        public async Task<StudentDTO> SuscribeStudentAsync(int idCourse, [FromBody]StudentDTO dto)
        {

        }

        [HttpPost("{idCourse}/professors/")]
        public async Task<StudentDTO> SuscribeProfessorAsync(int idCourse, [FromBody]ProfessorDTO)
        {

        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id) 
        {

        }

        [HttpDelete("{idCourse}/students/{idStudent}")] 
        public async Task<bool> UnsuscribeStudent(int idCourse, int idStudent)
        {

        }

        [HttpDelete("{idCourse}/professors/{idProfessor}")]
        public async Task<bool> UnsuscribeProfessor(int idCourse, int idProfesor)

        [HttpPut("{id}")]

    }
}
