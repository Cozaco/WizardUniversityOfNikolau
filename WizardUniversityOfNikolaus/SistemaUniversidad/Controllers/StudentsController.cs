using Microsoft.AspNetCore.Mvc;
using Contracts.Models;
using Service; // es todo service lo que hay q importar? O podemos solo llamar a student service? por que a cualquier de las 2 posibilidades
using UniSmart.API.DTOs;
using System.Net.Cache;
using UniSmart.API.Controllers;
using UniSmart.Service;

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
            Student student = await ServiceSingleton.GetInstance().studentService.CreateAsync(dto.GetName(), dto.GetAge());
            StudentDTO studentdto = new StudentDTO(student.GetName(), student.GetAge(), student.GetId());
            return studentdto;
        }

        [HttpDelete("{idStudent}")]//TODO como corno funciona.(el tema del parametro)        
        public async Task<bool> DeleteAsync(int idStudent)
        {
            return await ServiceSingleton.GetInstance().studentService.DeleteAsync(idStudent);
        }

        [HttpGet("course/{idCourse}")]
        public async Task<List<Student>> GetCourseStudentsAsync(int idCourse)
        {
            return await ServiceSingleton.GetInstance().studentService.GetCourseStudentsAsync(idCourse);
        }

        [HttpGet("profesor/{idProfessor}")]
        public async Task<List<Student>> GetProfessorStudentsAsync(int idProfessor)
        {
            return await ServiceSingleton.GetInstance().studentService.GetProfessorStudentsAsync(idProfessor);
        }
        [HttpDelete("{idStudent}/{idCourse}")]
        public async Task<bool> LeaveCourseAsync(int idStudent, int idCourse)
        {
            return await ServiceSingleton.GetInstance().studentService.LeaveCourseAsync(idStudent, idCourse); 
        }

        [HttpPost("{idStudent}/{idCourse}")]
        public async Task<bool> TakeCourseAsync(int idStudent, int idCourse)
        {
            return await ServiceSingleton.GetInstance().studentService.TakeCourseAsync(idStudent, idCourse);
        }

        [HttpPut("{id}/{oldName}/{oldAge}/{newName}/{newAge}")]

        public async Task<Student> UpdateAsync(int id, string oldName, int oldAge, string newName, int newAge)
        {
            return await ServiceSingleton.GetInstance().studentService.UpdateAsync(id,oldName,oldAge,newName,newAge);
        }

        // TODO hacer GetId en repository y service y agregarlo aca. Agregar las demas funciones
    }
}