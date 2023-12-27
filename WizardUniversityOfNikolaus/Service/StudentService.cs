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
        public async Task CreateAsync(Student alumno) //TODO Pasar los datos directamente y hacer el chequeo ahi
        {
            await DataBase.GetInstance().alumnoRepository.CrearAsync(alumno);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return  await DataBase.GetInstance().alumnoRepository.DeleteAsync(id);
        }

        public async Task<bool> UpdateAsync(Student alumno)
        {
            return await DataBase.GetInstance().alumnoRepository.UpdateAsync(alumno);
        }

        public async Task AlumnosEnLaMateriaAsync(int idMateria)
        {
            await DataBase.GetInstance().alumnoRepository.AlumnosEnLaMateriaAsync(idMateria);
        }

        public async Task AlumnosDeProfesorAsync(int idProfesor)
        {
            await DataBase.GetInstance().alumnoRepository.AlumnosDeProfesorAsync(idProfesor);
        }

        //Inscribir alumno en la materia. Primero se cuenta cuantas materias cursa, se chequea con el máximo de materias disponibles y de pasar,
        //se inscribe al alumno en la materia.
        public async Task<bool> InscribirAMateriaAsync(int idAlumno, int idMateria)
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
            int? materiasCursadas = (int)await DataBase.GetInstance().alumnoRepository.CountMateriasAsync(idAlumno);

            if (materiasCursadas.HasValue && materiasCursadas >= 2)
            {
                return false;
            }
            return await DataBase.GetInstance().alumnoRepository.InsertAlumnoEnMateriaAsync(idAlumno, idMateria);
        }


        public async Task<bool> DesinscribirAMateriaAsync(int idAlumno, int idMateria)
        {
            return await DataBase.GetInstance().alumnoRepository.DesinscribirAMateriaAsync(idAlumno, idMateria);
        }
    }
}
