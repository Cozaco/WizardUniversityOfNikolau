using Contracts.Repositories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class AlumnoCursaRepository : IAlumnoCursaRepository
    {
        public NpgsqlDataSource dataSource;

        public AlumnoCursaRepository(NpgsqlDataSource dataSource)
        {
            this.dataSource = dataSource;
        }
        public Task ConocerAlumnosAsync(int idMateria)
        {
            throw new NotImplementedException();
        }

        public Task ConocerMateriasAsync(int idAlumno)
        {
            throw new NotImplementedException();
        }

        public Task ConocerProfdeAlumnoAsync(int idAlumno)
        {
            throw new NotImplementedException();
        }

        public Task InscribirAMateriaAsync(int idAlumnos, int idMateria)
        {
            throw new NotImplementedException();
        }
    }
}
