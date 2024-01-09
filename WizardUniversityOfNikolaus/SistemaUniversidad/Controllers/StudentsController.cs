using Microsoft.AspNetCore.Mvc;
using Contracts.Models;
using Service; // es todo service lo que hay q importar? O podemos solo llamar a student service? por que a cualquier de las 2 posibilidades
using System.Net.Cache;
using UniSmart.API.InterfaceControllers;
using UniSmart.Service;
using UniSmart.API.DTOs.Responses;

namespace SistemaUniversidad.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentsController : ControllerBase/*,IStudentsController*/
    {
        //TODO el controller necesita constructor?, Porque esto no funciona
        //private readonly ServiceSingleton _service;

        //public StudentsController(StudentService studentService)
        //{
        //    _service = ServiceSingleton.GetInstance();
        //}


        [HttpPost]
        public async Task<StudentDTO> CreateAsync([FromBody] StudentDTO dto)
        {
            Student student = await ServiceSingleton.GetInstance().studentService.CreateAsync(dto.Name, dto.Age);
            StudentDTO studentdto = new StudentDTO(student.Name, student.Age, student.Id);
        }

        [HttpDelete("{idStudent}")]     
        public async Task<bool> DeleteAsync(int idStudent)
        {
            return await ServiceSingleton.GetInstance().studentService.DeleteAsync(idStudent);
        }

        [HttpGet("courses/{idCourse}")]
        public async Task<List<Student>> GetCourseStudentsAsync(int idCourse) //TODO cambiar todos los students por studentsDTO
        {
            var list = await ServiceSingleton.GetInstance().studentService.GetCourseStudentsAsync(idCourse);
            return list;
        }

        [HttpGet("professors/{idProfessor}")]
        public async Task<List<Student>> GetProfessorStudentsAsync(int idProfessor)
        {
            return await ServiceSingleton.GetInstance().studentService.GetProfessorStudentsAsync(idProfessor);
        }

        [HttpDelete("{idStudent}/courses/{idCourse}")]
        public async Task<bool> LeaveCourseAsync(int idStudent, int idCourse)
        {
            return await ServiceSingleton.GetInstance().studentService.LeaveCourseAsync(idStudent, idCourse); 
        }

        [HttpPost("{idStudent}/{idCourse}")]
        public async Task<bool> TakeCourseAsync(int idStudent, int idCourse)
        {
            return await ServiceSingleton.GetInstance().studentService.TakeCourseAsync(idStudent, idCourse);
        }

        [HttpPut("{id}")]
        public async Task<Student> UpdateAsync([FromBody] StudentDTO dto) //TODO puse el DTO, como veo si el ID esta bien
        {
            return await ServiceSingleton.GetInstance().studentService.UpdateAsync((int)dto.Id, dto.Name, dto.Age);
        }

        // TODO hacer GetId en repository y service y agregarlo aca. Agregar las demas funciones
    }
}