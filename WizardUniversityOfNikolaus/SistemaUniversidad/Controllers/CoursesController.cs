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
            return Ok(output);
        }

        [HttpGet("{idCourse}/professors")]
        public async Task<List<ProfessorDTO>> GetProfessors(int idCourse)
        {
            List<Professor> professors = await ServiceSingleton.GetInstance().courseService.GetProfessorsAsync(idCourse);
            List<ProfessorDTO> output = new List<ProfessorDTO>();  
            foreach (Professor professor in professors)
            {
                output.Add(new ProfessorDTO(professor.Name,professor.Age,professor.Id.Value));
            }
            return output;
        }


        [HttpPost] 
        public async Task<CourseDTO> CreateAsync([FromBody]CourseCreateDTO dto)
        {
            Course course = await ServiceSingleton.GetInstance().courseService.CreateAsync(dto.Name, dto.Comission);
            CourseDTO output= new CourseDTO(course.Name,course.Comission,course.Id);
            return output;
        }

        [HttpPost("{idCourse}/students")]
        public async Task SubscribeStudentAsync(int idCourse, [FromBody]StudentDTO dto)
        {
            await ServiceSingleton.GetInstance().courseService.SubscribeStudentAsync(idCourse, dto.Id);
        }

        [HttpPost("{idCourse}/professors")]
        public async Task SubscribeProfessorAsync(int idCourse, [FromBody]ProfessorDTO dto)
        {
            await ServiceSingleton.GetInstance().courseService.SubscribeProfessorAsync (idCourse, dto.Id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id) 
        {
            await ServiceSingleton.GetInstance().courseService.DeleteAsync(id);
        }

        [HttpDelete("{idCourse}/students/{idStudent}")] 
        public async Task UnsubscribeStudent(int idCourse, int idStudent)
        {
            await ServiceSingleton.GetInstance().courseService.UnsubscribeStudentAsync(idCourse, idStudent);
        }

        [HttpDelete("{idCourse}/professors/{idProfessor}")] // TODO Porque en DELETE pasamos Id y en POST pasamos el dto entero. Esta bien esto que hicimos? O cual de las 2 maneras esta mejor?
        public async Task UnsubscribeProfessor(int idCourse, int idProfesor)
        {
            await ServiceSingleton.GetInstance().courseService.UnsubscribeProfessorAsync(idCourse, idProfesor);
        }

        [HttpPut("{id}")]

        public async Task<CourseDTO> UpdateAsync(CourseCreateDTO dto,int id)
        {
            Course course = await ServiceSingleton.GetInstance().courseService.UpdateAsync(dto.Name,dto.Comission,id);
            CourseDTO output= new CourseDTO(dto.Name,dto.Comission,id);
            return output;
        }

    }
}
