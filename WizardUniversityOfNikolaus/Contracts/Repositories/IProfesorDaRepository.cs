using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IProfesorDaRepository
    {
        public Task ConocerProfesoresAsync(Materia materia);
        public Task ConocerMateriasAsync(Profesor profesor);
        public Task ConocerAlumnos(Profesor profesor);
    }
}
