using Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using UniSmart.API.DTOs.Responses;
using UniSmart.API.DTOs.Requests;
using UniSmart.Service;

namespace UniSmart.API.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentsController2 : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            Student student= await ServiceSingleton.GetInstance().studentService.GetByIdAsync(id);
            StudentDTO output = new StudentDTO(student.Name,student.Age,student.Id.Value);
            return output;
        }


        [HttpGet("{idStudent}/professors")]
        public async Task<List<ProfessorDTO>> GetProfessors(int idStudent)
        {
            List<Professor> professors=await ServiceSingleton.GetInstance().studentService.GetProfessorsAsync(idStudent);
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
            List<Course> courses= await ServiceSingleton.GetInstance().studentService.GetCoursesAsync(idStudent);
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
            Student student = await ServiceSingleton.GetInstance().studentService.CreateAsync(dto.Name, dto.Age);
            StudentDTO output= new StudentDTO(student.Name,student.Age,student.Id.Value);
            return output;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id) //TODO FRAN
        {
            
        }

        [HttpPut("{id}")]
        public async Task<Student> UpdateAsync([FromBody] StudentDTO dto) //TODO Que cambiarías FRAN?
        {
            return await ServiceSingleton.GetInstance().studentService.UpdateAsync( dto.Name, dto.Age, (int)dto.Id);
        }
    }
}
