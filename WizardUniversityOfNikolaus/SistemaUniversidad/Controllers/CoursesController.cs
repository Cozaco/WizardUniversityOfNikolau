using UniSmart.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using UniSmart.API.DTOs.Requests;
using UniSmart.API.DTOs.Responses;
using UniSmart.Contracts.Services;

namespace UniSmart.API.ControllersSS
{
    [ApiController]
    [Route("/api/courses")]
    public class CoursesController : ControllerBase
    {
        ICourseService courseService;
        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> GetByIdAsync(int id)
        {
            Course course = await this.courseService.GetByIdAsync(id);
            CourseDTO output = new CourseDTO(course.Name,course.Comission,course.Id);
            return Ok(output);     
        }

        [HttpGet("{idCourse}/students")]
        public async Task<ActionResult<List<StudentDTO>>> GetStudents(int idCourse)
        {
            List<Student> students = await this.courseService.GetStudentsAsync(idCourse);
            List<StudentDTO> output = new List<StudentDTO>();
            foreach (Student student in students)
            {
                output.Add(new StudentDTO(student.Name,student.Age,student.Id.Value));
            }
            return Ok(output);
        }

        [HttpGet("{idCourse}/professors")]
        public async Task<ActionResult<List<ProfessorDTO>>> GetProfessors(int idCourse) 
        {
            List<Professor> professors = await this.courseService.GetProfessorsAsync(idCourse);
            List<ProfessorDTO> output = new List<ProfessorDTO>();  
            foreach (Professor professor in professors)
            {
                output.Add(new ProfessorDTO(professor.Name,professor.Age,professor.Id.Value));
            }
            return Ok(output);
        }


        [HttpPost] 
        public async Task<CourseDTO> CreateAsync([FromBody]CourseCreateDTO dto)
        {
            Course course = await this.courseService.CreateAsync(dto.Name, dto.Comission);
            CourseDTO output= new CourseDTO(course.Name,course.Comission,course.Id);
            return output;
        }

        [HttpPost("{idCourse}/students")]
        public async Task SubscribeStudentAsync(int idCourse, [FromBody]StudentDTO dto)
        {
            await this.courseService.SubscribeStudentAsync(dto.Id, idCourse);
        }

        [HttpPost("{idCourse}/professors")]
        public async Task SubscribeProfessorAsync(int idCourse, [FromBody]ProfessorDTO dto)
        {
            await this.courseService.SubscribeProfessorAsync (dto.Id, idCourse);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id) 
        {
            await this.courseService.DeleteAsync(id);
        }

        [HttpDelete("{idCourse}/students/{idStudent}")]
        public async Task UnsubscribeStudent(int idStudent, int idCourse)
        {
            await this.courseService.UnsubscribeStudentAsync(idStudent, idCourse);
        }

        [HttpDelete("{idCourse}/professors/{idProfessor}")] // TODO Porque en DELETE pasamos Id y en POST pasamos el dto entero. Esta bien esto que hicimos? O cual de las 2 maneras esta mejor?
        public async Task UnsubscribeProfessor(int idCourse, int idProfessor)
        {
            await this.courseService.UnsubscribeProfessorAsync(idProfessor, idCourse);
        }

        [HttpPut("{id}")]

        public async Task<CourseDTO> UpdateAsync(CourseCreateDTO dto,int id)
        {
            Course course = await this.courseService.UpdateAsync(dto.Name,dto.Comission,id);
            CourseDTO output= new CourseDTO(dto.Name,dto.Comission,id);
            return output;
        }

    }
}
