using Contracts.Models;
using Contracts.Repositories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class ProfesorRepository : IProfesorRepository
    {
        public NpgsqlDataSource dataSource;

        public ProfesorRepository(NpgsqlDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public Task CrearAsync(Profesor profesor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int idProfesor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Profesor profesor)
        {
            throw new NotImplementedException();
        }
    }
}
