using UniSmart.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using UniSmart.API.DTOs.Responses;
using UniSmart.API.DTOs.Requests;
using UniSmart.Service;
using UniSmart.Contracts.Services;

namespace UniSmart.API.Controllers
{
    [ApiController]
    [Route("/api/students")]
    public class StudentsController : ControllerBase
    {
        public IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("{id}")]
        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            Student student= await this.studentService.GetByIdAsync(id);
            StudentDTO output = new StudentDTO(student.Name,student.Age,student.Id.Value);
            return output;
        }


        [HttpGet("{idStudent}/professors")]
        public async Task<List<ProfessorDTO>> GetProfessors(int idStudent)
        {
            List<Professor> professors=await this.studentService.GetProfessorsAsync(idStudent);
            List<ProfessorDTO> output= new List<ProfessorDTO>();
            foreach(Professor professor in professors)
            {
                output.Add(new ProfessorDTO(professor.Name,professor.Age,professor.Id.Value));  
            }
            return output;
        }

        [HttpGet("{idStudent}/courses")]
        public async Task<List<CourseDTO>> GetCourses(int idStudent)
        {
            List<Course> courses= await this.studentService.GetCoursesAsync(idStudent);
            List<CourseDTO> output= new List<CourseDTO>();
            foreach(Course course in courses)
            {
                output.Add(new CourseDTO(course.Name,course.Comission,course.Id.Value));
            }
            return output;
        }

        [HttpPost]
        public async Task<StudentDTO> CreateAsync([FromBody] StudentCreateDTO dto)
        {
            Student student = await this.studentService.CreateAsync(dto.Name, dto.Age);
            StudentDTO output= new StudentDTO(student.Name,student.Age,student.Id.Value);
            return output;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await this.studentService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<StudentDTO> UpdateAsync([FromBody] StudentCreateDTO dto, int id)
        {
            Student student = await this.studentService.UpdateAsync( dto.Name, dto.Age, id);
            StudentDTO output = new StudentDTO(student.Name, student.Age, student.Id.Value);
            return output;
        }
    }
}
