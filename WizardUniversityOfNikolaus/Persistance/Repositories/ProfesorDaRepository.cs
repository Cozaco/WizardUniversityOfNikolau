using Contracts.Repositories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    internal class ProfesorDaRepository : IProfesorDaRepository
    {
        public NpgsqlDataSource dataSource;

        public ProfesorDaRepository(NpgsqlDataSource dataSource)
        {
            this.dataSource = dataSource;
        }
        public Task ConocerAlumnosdeProfesorAsync(int idProfesor)
        {
            throw new NotImplementedException();
        }

        public Task ConocerMateriasAsync(int idProfesor)
        {
            throw new NotImplementedException();
        }

        public Task ConocerProfdeMateriaAsync(int idMateria)
        {
            throw new NotImplementedException();
        }

        public Task ContratarProfesorenMateriaAsync(int idProfesor, int idMateria)
        {
            throw new NotImplementedException();
        }
    }
}
