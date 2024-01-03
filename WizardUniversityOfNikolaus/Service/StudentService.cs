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

        public async Task<Student> UpdateAsync(int id, string oldName, int oldAge, string newName, int newAge)//TODO pasar datos
        {
            if (!await DataBase.GetInstance().studentRepository.ValidateInfoAsync(id, oldName, oldAge))
            {
                throw new Exception("The student you want to update doesn't exist!!! He could be in another university, because he want to learn seriously!");
            }
            if(!InputCheck(newName, newAge)) {  throw new Exception(); }
            Student student = new Student(newName, newAge, id);
            return await DataBase.GetInstance().studentRepository.UpdateAsync(student);
        }

        public async Task<List<Student>> GetCourseStudentsAsync(int idCourse)
        {
            return await DataBase.GetInstance().studentRepository.GetCourseStudentsAsync(idCourse);
        }

        public async Task<List<Student>> GetProfessorStudentsAsync(int idProfessor)
        {
           return await DataBase.GetInstance().studentRepository.GetProfessorStudentsAsync(idProfessor);
        }

        //Inscribir alumno en la materia. Primero se cuenta cuantas materias cursa, se chequea con el máximo de materias disponibles y de pasar,
        //se inscribe al alumno en la materia.
        public async Task<bool> TakeCourseAsync(int idStudent, int idCourse)//TODO mirar lo del try
        {
            //try
            //{
            //    int? materiasCursadas =(int) await DataBase.GetInstance().alumnoRepository.CountMateriasAsync(idAlumno);

            //    if (materiasCursadas.HasValue && materiasCursadas >= 2)
            //    {
            //        return false;
            //    }
            //}
            //catch
            //{
            //    return false;
            //}
            //return await DataBase.GetInstance().alumnoRepository.InsertAlumnoEnMateriaAsync(idAlumno, idMateria);
            int? materiasCursadas = (int)await DataBase.GetInstance().studentRepository.CountCoursesAsync(idStudent);

            if (materiasCursadas.HasValue && materiasCursadas >= 2)
            {
                return false;
            }
            return await DataBase.GetInstance().studentRepository.TakeCourseAsync(idStudent, idCourse);
        }


        public async Task<bool> LeaveCourseAsync(int idAlumno, int idMateria)
        {
            return await DataBase.GetInstance().studentRepository.LeaveCourseAsync(idAlumno, idMateria);
        }
    }
}
