using Contracts.Models;
using Contracts.Repositories;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UniSmart.Contracts.Services;

namespace Service
{
    public class ProfessorService : IProfessorService
    {
        public IProfessorRepository professorRepository;
        public IStudentRepository studentRepository;
        public ICourseRepository courseRepository;

        public ProfessorService(IProfessorRepository professorRepository, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            this.professorRepository = professorRepository;
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
        }

        public async Task<Professor> CreateAsync(string name, int age)
        {
            InputCheck(name, age);
            Professor professor = new Professor(name, age);
            return await this.professorRepository.CreateAsync(professor);
        }

        public async Task DeleteAsync(int id)
        {
            await this.professorRepository.DeleteAsync(id);
        }

        public async Task<Professor> UpdateAsync(string newName, int newAge, int idProfessor)
        {
            InputCheck(newName, newAge);
            Professor professor = new Professor(newName, newAge, idProfessor );
            return await this.professorRepository.UpdateAsync(professor); //Cambia las caracteristicas de professor?         
        }
        public async Task<Professor> GetByIdAsync(int id)
        {
            return await this.professorRepository.GetByIdAsync(id);
        }
        public async Task<List<Student>> GetStudentsAsync(int idProfessor)
        {
            return await this.studentRepository.GetProfessorStudentsAsync(idProfessor);
        }
        public async Task<List<Course>> GetCoursesAsync(int idProfessor)
        {
            return await this.courseRepository.GetProfessorCoursesAsync(idProfessor);
        }
        public void InputCheck(string name, int age)
        {
            if (name == "")
            {
                throw new Exception("You must complete the name space");
            }
            if (age < 18)
            {
                throw new Exception("The age number must be more than 18. If not, it is child labour! Call 911");
            }
        }
    }
}
