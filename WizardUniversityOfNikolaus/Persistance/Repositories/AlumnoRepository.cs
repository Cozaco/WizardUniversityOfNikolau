using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Repositories;
using Contracts.Models;
using Npgsql;

namespace Persistance.Repositories
{
    public class AlumnoRepository : IAlumnoRepository
    {
        public NpgsqlDataSource dataSource;

        public AlumnoRepository(NpgsqlDataSource dataSource)
        {
            this.dataSource = dataSource;
        }
    }
}
