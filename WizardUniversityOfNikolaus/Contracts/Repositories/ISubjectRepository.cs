using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface ISubjectRepository
    {
        public Task CrearAsync(Subject materia);
        public Task<bool> DeleteAsync(int idMateria);
        public Task<bool> UpdateAsync(Subject materia);

        public Task MateriasDeAlumnoAsync(int idAlumno);

        public Task MateriasDeProfesorAsync(int idProfesor);
    }
}
