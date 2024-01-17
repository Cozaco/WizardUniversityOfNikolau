using Microsoft.AspNetCore.Mvc;
using UniSmart.Contracts.Models;
using UniSmart.API.DTOs.Responses;
using UniSmart.API.DTOs.Requests;
using UniSmart.Contracts.Services;

namespace UniSmart.API.Controllers
{
    [ApiController]
    [Route("/api/professors")]
    public class ProfessorsController : ControllerBase
    {
        public IProfessorService professorService;

        public ProfessorsController(IProfessorService professorService)
        {
            this.professorService = professorService;
        }

        [HttpGet("{idProfessor}")]
        public async Task<ProfessorDTO> GetByIdAsync(int idProfessor)
        {
            Professor professor =await this.professorService.GetByIdAsync(idProfessor);  
            ProfessorDTO output= new ProfessorDTO(professor.Name,professor.Age,professor.Id.Value);
            return output;
        }
        
        [HttpGet("{idProfessor}/students")]
        public async Task<List<StudentDTO>> GetStudents(int idProfessor)
        {
            List<Student> students=await this.professorService.GetStudentsAsync(idProfessor);
            List<StudentDTO> output=new List<StudentDTO>();
            foreach (Student student in students)
            {
                output.Add(new StudentDTO(student.Name,student.Age,student.Id.Value));
            }
            return output;
        }

        [HttpGet("{idProfessor}/courses")]
        public async Task<List<CourseDTO>> GetCourses(int idProfessor)
        {
            List<Course> courses = await this.professorService.GetCoursesAsync(idProfessor);
            List<CourseDTO> output = new List<CourseDTO>();
            foreach (Course course in courses)
            {
                output.Add(new CourseDTO(course.Name, course.Comission,course.Id.Value));
            }
            return output;
        }

        [HttpPost]
        public async Task<ProfessorDTO> CreateAsync([FromBody] ProfessorCreateDTO dto)
        {
            Professor professor = await this.professorService.CreateAsync(dto.Name, dto.Age);
            ProfessorDTO output = new ProfessorDTO(professor.Name, professor.Age, professor.Id.Value);
            return output;
        }

        [HttpDelete("{id}")]   
        public async Task DeleteAsync(int id)
        {
            await this.professorService.DeleteAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ProfessorDTO> UpdateAsync([FromBody] ProfessorCreateDTO dto,int id) 
        {
            Professor professor = await this.professorService.UpdateAsync(dto.Name, dto.Age, id);
            ProfessorDTO output = new ProfessorDTO(professor.Name, professor.Age, professor.Id.Value);
            return output; 
        }
    }
}
