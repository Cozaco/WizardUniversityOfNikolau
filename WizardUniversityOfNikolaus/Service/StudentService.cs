using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Contracts.Models;
using Npgsql;
using Persistance;

namespace Service
{
    public class StudentService 
    {
        public async Task GetStudentCoursesAsync(int idStudent)
        {
            await DataBase.GetInstance().courseRepository.GetStudentCoursesAsync(idStudent);
        }

        public async Task<List<Professor>> GetStudentProfessorsAsync(int idStudent)
        {
            return await DataBase.GetInstance().professorRepository.GetStudentProfessorsAsync(idStudent);
        }

        private bool InputCheck(string name, int age)
        {
            if (name == "")
            {
                throw new Exception("You must complete the name space");
            }
            if (age < 18)
            {
                throw new Exception("The age number must be more than 18. If not, this child is a Genius! Also call 911. He knows too much!");
            }
            return true;
        }
        //private readonly int contadorMaterias;
        public async Task<Student> CreateAsync(string name, int age) //TODO Pasar los datos directamente y hacer el chequeo ahi
        {
            if(!InputCheck(name, age)) { throw new Exception(); }
            Student student = new Student (name, age);
            return await DataBase.GetInstance().studentRepository.CreateAsync(student);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return  await DataBase.GetInstance().studentRepository.DeleteAsync(id);
        }

        public async Task<Student> UpdateAsync(int id, string newName, int newAge)//TODO pasar datos
        {
            if (!InputCheck(newName, newAge)) { throw new Exception(); }
            Student student = new Student(newName, newAge, id);
            return await DataBase.GetInstance().studentRepository.UpdateAsync(student);
        }
        
    }
}
