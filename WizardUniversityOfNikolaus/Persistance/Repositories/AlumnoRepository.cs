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

        public Task CrearAsync(Alumno alumno)
        {
            
            using NpgsqlCommand command = dataSource.CreateCommand($"INSERT INTO universidad.materias (nombre,edad) VALUES ('{alumno.GetNombre()}','{alumno.GetEdad()}') RETURNING id");
            int? resultadoComando=(int?)command.ExecuteScalar();
            if ( resultadoComando == null )
            {
                throw new Exception("No se pudo agregar alumno");

            }
            alumno.SetId(resultadoComando.Value);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Alumno alumno)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Alumno alumno)
        {
            throw new NotImplementedException();
        }
    }
}
