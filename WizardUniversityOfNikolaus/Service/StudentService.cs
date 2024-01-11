using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Contracts.Models;
using Npgsql;
using Persistance;
using UniSmart.Contracts.Services;

namespace Service
{
    public class StudentService : IStudentService
    {
        public async Task<Student> CreateAsync(string name, int age) 
        {
            InputCheck(name, age);
            Student student = new Student (name, age);
            return await DataBase.GetInstance().studentRepository.CreateAsync(student);
        }

        public async Task DeleteAsync(int id)
        {
            await DataBase.GetInstance().studentRepository.DeleteAsync(id);
        }

        public async Task<Student> UpdateAsync(string newName, int newAge, int id)
        {
            InputCheck(newName, newAge);
            Student student = new Student(newName, newAge, id);
            return await DataBase.GetInstance().studentRepository.UpdateAsync(student);
        }
        
        public async Task<Student> GetByIdAsync(int id)
        {
            return await DataBase.GetInstance().studentRepository.GetByIdAsync(id);
        }
        public async Task<List<Course>> GetCoursesAsync(int idStudent)
        {
            return await DataBase.GetInstance().courseRepository.GetStudentCoursesAsync(idStudent);
        }

        public async Task<List<Professor>> GetProfessorsAsync(int idStudent)
        {
            return await DataBase.GetInstance().professorRepository.GetStudentProfessorsAsync(idStudent);
        }

        public void InputCheck(string name, int age)
        {
            if (name == "")
            {
                throw new Exception("You must complete the name space");
            }
            if (age < 18)
            {
                throw new Exception("The age number must be more than 18. If not, this child is a Genius! Also call 911. He knows too much!");
            }
        }
    }
}
