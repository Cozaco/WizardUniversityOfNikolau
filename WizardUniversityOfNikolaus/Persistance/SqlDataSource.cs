using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSmart.Contracts.Repositories;

namespace UniSmart.Persistance
{

    public class SqlDataSource : IDisposable,IDataSource
    {
        private readonly NpgsqlDataSource dataSource;
        public SqlDataSource()
        {
            dataSource = NpgsqlDataSource.Create("Host=127.0.0.1;Username=postgres;Password=loba2110;Database=postgres");
        }

        public NpgsqlDataSource GetConnection()
        {
            return dataSource;
        }
        public void Dispose()
        {
            dataSource.Dispose();
        }
    }
}
