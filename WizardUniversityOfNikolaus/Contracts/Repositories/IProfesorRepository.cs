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
        public Task TomarMateriaAsync(Profesor profesor, Materia materia);
        public Task DeleteAsync(Profesor profesor);
        public Task ConocerMateriaAsync(Profesor profesor);
        public Task ConocerAlumnos(Profesor profesor);
    }
}
