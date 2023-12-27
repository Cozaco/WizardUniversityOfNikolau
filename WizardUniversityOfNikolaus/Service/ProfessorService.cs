using Contracts.Models;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProfessorService 
    {
        public async Task CreateAsync(Professor profesor)
        {
            await DataBase.profesorRepository.CrearAsync(profesor);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return DataBase.profesorRepository.DeleteAsync(id);
        }

        public Task<bool> UpdateAsync(Professor profesor)
        {
            return DataBase.profesorRepository.UpdateAsync(profesor);
        }

        public async Task ProfesoresDeAlumnoAsync(int idAlumno)
        {
            await DataBase.profesorRepository.ProfesoresDeAlumnoAsync(idAlumno);
        }

        public async Task ProfesoresDeMateriaAsync(int idMateria)
        {
            await DataBase.profesorRepository.ProfesoresDeMateriaAsync(idMateria);
        }

        public async Task<bool> AsingnarAMateriaAsync(int idProfesor, int idMateria)
        {
            return await DataBase.profesorRepository.AsingnarAMateriaAsync(idProfesor, idMateria);
        }

        public async Task<bool> DejarMateria(int idProfesor, int idMateria)
        {
            return await DataBase.profesorRepository.DejarMateria(idProfesor,idMateria);
        }
    }
}
