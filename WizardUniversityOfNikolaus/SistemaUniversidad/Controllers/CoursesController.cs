using Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniSmart.API.DTOs.Requests;
using UniSmart.API.DTOs.Responses;
using Service;
using UniSmart.Service;
using UniSmart.Contracts.Exceptions;

namespace UniSmart.API.ControllersSS
{
    [ApiController]
    [Route("courses")]
    public class CoursesController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> GetByIdAsync(int id)
        {
            Course course = await ServiceSingleton.GetInstance().courseService.GetByIdAsync(id);
            CourseDTO output = new CourseDTO(course.Name,course.Comission,course.Id);
            return Ok(output);     
        }

        [HttpGet("{idCourse}/students")]
        public async Task<ActionResult<List<StudentDTO>>> GetStudents(int idCourse)
        {
            List<Student> students = await ServiceSingleton.GetInstance().courseService.GetStudentsAsync(idCourse);
            List<StudentDTO> output = new List<StudentDTO>();
            foreach (Student student in students)
            {
                output.Add(new StudentDTO(student.Name,student.Age,student.Id.Value));
            }
            return Ok(output);//OK
        }

        [HttpGet("{idCourse}/professors")] //TODO FRAN
        public async Task<List<ProfessorDTO>> GetProfessors(int idCourse)
        {

        }


        [HttpPost] 
        public async Task<CourseDTO> CreateAsync([FromBody]CourseCreateDTO dto)
        {
            Course course = await ServiceSingleton.GetInstance().courseService.CreateAsync(dto.Name, dto.Comission);
            CourseDTO output= new CourseDTO(course.Name,course.Comission,course.Id);
            return output;
        }

        [HttpPost("{idCourse}/students/")]//TODO va con o sin la barrita al final?
        public async Task<StudentDTO> SubscribeStudentAsync(int idCourse, [FromBody]StudentDTO dto)
        {

        }

        [HttpPost("{idCourse}/professors/")]
        public async Task<StudentDTO> SubscribeProfessorAsync(int idCourse, [FromBody]ProfessorDTO dto)
        {

        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id) 
        {

        }

        [HttpDelete("{idCourse}/students/{idStudent}")] 
        public async Task<bool> UnsubscribeStudent(int idCourse, int idStudent)
        {

        }

        [HttpDelete("{idCourse}/professors/{idProfessor}")]
        public async Task<bool> UnsubscribeProfessor(int idCourse, int idProfesor)
        {

        }

        [HttpPut("{id}")]

        public async Task<CourseDTO> UpdateAsync(int id)//TODO o le paso un CourseUpdateDto que tiene solo el id? 
        {

        }

    }
}
