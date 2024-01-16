using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSmart.Contracts.Repositories
{
    public interface IDataSource
    {
        public NpgsqlDataSource GetConnection();
    }
}
