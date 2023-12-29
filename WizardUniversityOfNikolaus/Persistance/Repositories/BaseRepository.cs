using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSmart.Persistance.Repositories
{
    public abstract class BaseRepository<T> //TODO hacer un repositorio base donde esten las funciones comunes, y además va tener las funciones que ejecutan las querys y hacen los chequeos 
    //TODO Boby tables
    {
        
        public BaseRepository() { }
        //Ejemplo: 
        //protected async Task<RetType> ExecuteScalarAsync<RetType>(string query, object[] parameters)
        //{

        //    using (NpgsqlCommand command = _dataSource.CreateCommand(query))
        //    {
        //        command.Parameters.AddRange(parameters);

        //        RetType? scalar = (RetType?)await command.ExecuteScalarAsync();

        //        if (scalar == null)
        //        {
        //            throw new Exception("No se pudo ejecutar la query");
        //        }

        //        return scalar;
        //    }
        //}

        public abstract Task<bool> ValidateInfoAsync(T oldEntity);//El valor de la oldEntity la va armar el service yo verifico si esta en la base 
    }
}
