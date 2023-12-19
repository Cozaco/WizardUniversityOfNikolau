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

        public async Task CrearAsync(Profesor profesor)
        {

            using NpgsqlCommand command = dataSource.CreateCommand($"INSERT INTO universidadnikolay.profesores (nombre,edad) VALUES ('{profesor.GetNombre()}',{profesor.GetEdad()}) RETURNING id");
            int? resultadoComando = (int?) await command.ExecuteScalarAsync();
            if (resultadoComando == null)
            {
                throw new Exception("No se pudo agregar profesor");

            }
            profesor.SetId(resultadoComando.Value);
            return;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using NpgsqlCommand command = dataSource.CreateCommand($"DELETE FROM universidadnikolay.profesores WHERE profesores.id = {id}");
            int resultadoComando = await command.ExecuteNonQueryAsync(); // hace la query y no devuelve nada
            Console.WriteLine(resultadoComando);
            if (resultadoComando == -1)
            {
                throw new Exception("Error al eliminar el profesor");
            }
            if (resultadoComando > 1)
            {
                throw new Exception("F");
            }
            if (resultadoComando == 0)
            {
                return false; // no se borró ningún profesor
            }
            return true; //se borró exitosamente un profesor
        }

        public async Task<bool> UpdateAsync(Profesor profesor) //alumno con el update HECHO
        {
            using NpgsqlCommand command = dataSource.CreateCommand($"UPDATE universidadnikolay.profesores SET nombre = '{profesor.GetNombre()}', edad = {profesor.GetEdad()} WHERE id = {profesor.GetId()}");
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
                return false; // no se actualizo profesor
            }
            return true; //se actualizo exitosamente un profesor

        }
    }
}
