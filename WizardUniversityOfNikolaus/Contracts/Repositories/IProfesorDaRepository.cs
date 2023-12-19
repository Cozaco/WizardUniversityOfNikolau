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
        public Task ConocerProfdeMateriaAsync(int idMateria);
        public Task ConocerMateriasAsync(int idProfesor);
        public Task ConocerAlumnosdeProfesorAsync(int idProfesor);

        public Task ContratarProfesorenMateriaAsync(int idProfesor, int idMateria);
    }
}
