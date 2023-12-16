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
    }
}
