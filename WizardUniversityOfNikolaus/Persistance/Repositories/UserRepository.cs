using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSmart.Contracts.Repositories;

namespace UniSmart.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private NpgsqlDataSource dataSource;

        public UserRepository(IDataSource dataSource)
        {
            this.dataSource = dataSource.GetConnection();
        }
        public async Task<bool> CheckPasswordAsync(string mail, string passwordHash)
        {
            using NpgsqlCommand command = dataSource.CreateCommand("SELECT EXISTS (SELECT * FROM universidadnikolay.usuarios WHERE mail = $1 AND password_hash = $2)");
            command.Parameters.Add(new NpgsqlParameter(null,mail));
            command.Parameters.Add(new NpgsqlParameter(null, passwordHash));
            return (bool)(await command.ExecuteScalarAsync())!;
        }
    }
}
