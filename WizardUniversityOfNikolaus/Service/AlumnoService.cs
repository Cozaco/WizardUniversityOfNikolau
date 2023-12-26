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
    public class AlumnoService 
    {
        //private readonly int contadorMaterias;
        public async Task CreateAsync(Alumno alumno)
        {
            await DataBase.alumnoRepository.CrearAsync(alumno);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return  await DataBase.alumnoRepository.DeleteAsync(id);
        }

        public async Task<bool> UpdateAsync(Alumno alumno)
        {
            return await DataBase.alumnoRepository.UpdateAsync(alumno);
        }

        public async Task AlumnosEnLaMateriaAsync(int idMateria)
        {
            await DataBase.alumnoRepository.AlumnosEnLaMateriaAsync(idMateria);
        }

        public async Task AlumnosDeProfesorAsync(int idProfesor)
        {
            await DataBase.alumnoRepository.AlumnosDeProfesorAsync(idProfesor);
        }

        //Inscribir alumno en la materia. Primero se cuenta cuantas materias cursa, se chequea con el máximo de materias disponibles y de pasar,
        //se inscribe al alumno en la materia.
        public async Task<bool> InscribirAMateriaAsync(int idAlumno, int idMateria)
        {
            try
            {
                int? materiasCursadas = await DataBase.alumnoRepository.CountMateriasAsync(idAlumno);

                if (materiasCursadas.HasValue && materiasCursadas >= 2)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return await DataBase.alumnoRepository.InsertAlumnoEnMateriaAsync(idAlumno, idMateria);
        }


        public async Task<bool> DesinscribirAMateriaAsync(int idAlumno, int idMateria)
        {
            return await DataBase.alumnoRepository.DesinscribirAMateriaAsync(idAlumno, idMateria);
        }
    }
}
