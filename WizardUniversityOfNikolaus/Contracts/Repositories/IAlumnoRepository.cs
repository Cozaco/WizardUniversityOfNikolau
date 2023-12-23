using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IAlumnoRepository
    {
        public Task CrearAsync(Alumno alumno);
        
        public Task<bool> DeleteAsync(int idAlumno);

        public Task<bool> UpdateAsync(Alumno alumno);

        public Task AlumnosEnLaMateriaAsync(int idMateria);

        public Task AlumnosDeProfesorAsync(int idProfesor);

        public Task<bool> InscribirAMateriaAsync(int idAlumno, int idMateria);

    }
}
