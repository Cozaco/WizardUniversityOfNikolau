using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> InscribirAMateriaAsync(int idAlumno, int idMateria)
        {
            return await DataBase.alumnoRepository.InscribirAMateriaAsync(idAlumno, idMateria);
        }

        public async Task<bool> DesinscribirAMateriaAsync(int idAlumno, int idMateria)
        {
            return await DataBase.alumnoRepository.DesinscribirAMateriaAsync(idAlumno, idMateria);
        }
    }
}
