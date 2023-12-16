using Contracts.Repositories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class MateriaRepository : IMateriaRepository
    {
        public NpgsqlDataSource dataSource;

        public MateriaRepository(NpgsqlDataSource dataSource)
        {
            this.dataSource = dataSource;
        }
    }
}
