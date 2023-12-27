using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IProfessorRepository
    {
        public Task CrearAsync(Professor profesor);
        public Task<bool> DeleteAsync(int idProfesor);

        public Task<bool> UpdateAsync(Professor profesor);

        public Task ProfesoresDeAlumnoAsync(int idAlumno);

        public Task ProfesoresDeMateriaAsync(int idMateria);

        public Task<bool> AsingnarAMateriaAsync(int idProfesor, int idMateria);

        public Task<bool> DejarMateria(int idProfesor, int idMateria);
    }
}
