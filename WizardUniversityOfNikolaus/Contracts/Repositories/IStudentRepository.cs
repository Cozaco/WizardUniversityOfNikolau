using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IStudentRepository
    {
        public Task CrearAsync(Student alumno);
        
        public Task<bool> DeleteAsync(int idAlumno);

        public Task<bool> UpdateAsync(Student alumno);

        public Task AlumnosEnLaMateriaAsync(int idMateria);

        public Task AlumnosDeProfesorAsync(int idProfesor);

        public Task<long> CountMateriasAsync(int idAlumno);

        public Task<bool> InsertAlumnoEnMateriaAsync(int idAlumno, int idMateria);

        public Task<bool> DesinscribirAMateriaAsync(int idAlumno, int idMateria);

    }
}
