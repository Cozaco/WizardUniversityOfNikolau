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
        //private readonly int contadorMaterias;
        public async Task CreateAsync(Student student) //TODO Pasar los datos directamente y hacer el chequeo ahi
        {
            await DataBase.GetInstance().studentRepository.CrearAsync(student);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return  await DataBase.GetInstance().studentRepository.DeleteAsync(id);
        }

        public async Task<bool> UpdateAsync(Student student)//TODO pasar datos
        {
            return await DataBase.GetInstance().studentRepository.UpdateAsync(student);
        }

        public async Task GetCourseStudentsAsync(int idCourse)
        {
            await DataBase.GetInstance().studentRepository.GetCourseStudentsAsync(idCourse);
        }

        public async Task GetProfessorStudentsAsync(int idProfessor)
        {
            await DataBase.GetInstance().studentRepository.GetProfessorStudentsAsync(idProfessor);
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
