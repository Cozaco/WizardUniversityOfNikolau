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
        public async Task<ProfessorDTO> GetByIdAsync(int idProfessor)
        {
            Professor professor =await ServiceSingleton.GetInstance().professorService.GetByIdAsync(idProfessor);  
            ProfessorDTO output= new ProfessorDTO(professor.Name,professor.Age,professor.Id.Value);
            return output;
        }
        
        [HttpGet("{idProfessor}/students")]
        public async Task<List<StudentDTO>> GetStudents(int idProfessor)
        {
            List<Student> students=await ServiceSingleton.GetInstance().professorService.GetStudentsAsync(idProfessor);
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
            List<Course> courses = await ServiceSingleton.GetInstance().professorService.GetCoursesAsync(idProfessor);
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
            Professor professor = await ServiceSingleton.GetInstance().professorService.CreateAsync(dto.Name, dto.Age);
            ProfessorDTO output = new ProfessorDTO(professor.Name, professor.Age, professor.Id.Value);
            return output;
        }

        [HttpDelete("{id}")]   
        public async Task DeleteAsync(int id)
        {
            await ServiceSingleton.GetInstance().professorService.DeleteAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ProfessorDTO> UpdateAsync([FromBody] ProfessorCreateDTO dto,int id) 
        {
            Professor professor = await ServiceSingleton.GetInstance().professorService.UpdateAsync(dto.Name, dto.Age, id);
            ProfessorDTO output = new ProfessorDTO(professor.Name, professor.Age, professor.Id.Value);
            return output; 
        }
    }
}
