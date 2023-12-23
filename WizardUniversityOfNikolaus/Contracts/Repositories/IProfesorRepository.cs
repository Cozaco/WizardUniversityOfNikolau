using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IProfesorRepository
    {
        public Task CrearAsync(Profesor profesor);
        public Task<bool> DeleteAsync(int idProfesor);

        public Task<bool> UpdateAsync(Profesor profesor);

        public Task ProfesoresDeAlumnoAsync(int idAlumno);

        public Task ProfesoresDeMateriaAsync(int idMateria);

        public Task<bool> AsingnarAMateriaAsync(int idProfesor, int idMateria);
    }
}
