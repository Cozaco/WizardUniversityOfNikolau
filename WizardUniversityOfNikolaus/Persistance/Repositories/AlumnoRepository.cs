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

        public async Task CrearAsync(Profesor alumno)
        {
            
            using NpgsqlCommand command = dataSource.CreateCommand($"INSERT INTO universidadnikolay.alumnos (nombre,edad) VALUES ('{alumno.GetNombre()}',{alumno.GetEdad()}) RETURNING id");
            int? resultadoComando=(int?)await command.ExecuteScalarAsync();
            if ( resultadoComando == null )
            {
                throw new Exception("No se pudo agregar alumno");

            }
            alumno.SetId(resultadoComando.Value);
            return;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using NpgsqlCommand command = dataSource.CreateCommand($"DELETE FROM universidadnikolay.alumnos WHERE alumnos.id = {id}");
            int resultadoComando = await command.ExecuteNonQueryAsync(); // hace la query y no devuelve nada
            Console.WriteLine(resultadoComando);
            if (resultadoComando == -1)
            {
                throw new Exception("Error al eliminar el alumno");
            }
            if (resultadoComando > 1)
            {
                throw new Exception("F");
            }
            if (resultadoComando == 0)
            {
                return false; // no se borró ningún alumnos
            }
            return true; //se borró exitosamente un alumno
        }

        public async Task<bool> UpdateAsync(Profesor alumno) //alumno con el update HECHO
        {
            using NpgsqlCommand command = dataSource.CreateCommand($"UPDATE universidadnikolay.alumnos SET nombre = '{alumno.GetNombre()}', edad = {alumno.GetEdad()} WHERE id = {alumno.GetId()}");
            int resultadoComando = await command.ExecuteNonQueryAsync(); // hace la query y no devuelve nada
            if (resultadoComando == -1)
            {
                throw new Exception("Error al actualizar el alumno");
            }
            if (resultadoComando > 1)
            {
                throw new Exception("F");
            }
            if (resultadoComando == 0)
            {
                return false; // no se borró ningún alumnos
            }
            return true; //se borró exitosamente un alumno

        }
    }
}
