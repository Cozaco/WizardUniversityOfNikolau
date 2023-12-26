using Contracts.Models;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MateriaService 
    {
        public async Task CreateAsync(Materia materia)
        {
            await DataBase.materiaRepository.CrearAsync(materia);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return DataBase.materiaRepository.DeleteAsync(id);
        }

        public Task<bool> UpdateAsync(Materia materia)
        {
            return DataBase.materiaRepository.UpdateAsync(materia);
        }

        public async Task MateriasDeAlumnoAsync(int idAlumno)
        {
            await DataBase.materiaRepository.MateriasDeAlumnoAsync(idAlumno);
        }

        public async Task MateriasDeProfesorAsync(int idProfesor)
        {
            await DataBase.materiaRepository.MateriasDeProfesorAsync(idProfesor);
        }
    }
}
