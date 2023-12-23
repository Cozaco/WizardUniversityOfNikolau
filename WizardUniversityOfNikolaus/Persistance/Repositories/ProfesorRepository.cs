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

            using NpgsqlCommand command = dataSource.CreateCommand($"INSERT INTO universidadnikolay.profesores (nombre,edad) " +
                                                                   $"VALUES ('{profesor.GetNombre()}',{profesor.GetEdad()}) " +
                                                                   $"RETURNING id");
            
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
            await using NpgsqlCommand command = dataSource.CreateCommand($"DELETE FROM universidadnikolay.profesores" +
                                                                         $" WHERE profesores.id = {id}");
            
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
            using NpgsqlCommand command = dataSource.CreateCommand($"UPDATE universidadnikolay.profesores " +
                                                                   $"SET nombre = '{profesor.GetNombre()}', edad = {profesor.GetEdad()}" +
                                                                   $" WHERE id = {profesor.GetId()}");
            
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

        public async Task ProfesoresDeAlumnoAsync(int idAlumno)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT profesores.id,profesores.nombre " +
                                                                        $"FROM universidadnikolay.profesores " +
                                                                        $"JOIN universidadnikolay.profesores_dictan " +
                                                                        $"ON profesores.id=profesores_dictan.profesor_id " +
                                                                        $"JOIN universidadnikolay.alumnos_cursan " +
                                                                        $"ON profesores_dictan.materia_id=alumnos_cursan.materia_id " +
                                                                        $"WHERE alumnos_cursan.alumno_id={idAlumno}");

            using NpgsqlDataReader reader = await comand.ExecuteReaderAsync();
            List<Profesor> profesores = new List<Profesor>();
            while (reader.Read())
            {
                Profesor profesor = new Profesor(reader.GetString(1), reader.GetInt32(0));
                profesores.Add(profesor);
            }
            foreach (Profesor profesor in profesores)
            {
                Console.WriteLine($"ID:{profesor.GetId()}");
                Console.WriteLine($"Nombre:{profesor.GetNombre()}");
            }
        }

        public async Task ProfesoresDeMateriaAsync(int idMateria)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT profesores.id,profesores.nombre,profesores.edad " +
                                                                        $"FROM universidadnikolay.profesores " +
                                                                        $"JOIN universidadnikolay.profesores_dictan " +
                                                                        $"ON profesores.id=profesores_dictan.profesor_id " +
                                                                        $"WHERE profesores_dictan.materia_id={idMateria}");

            using NpgsqlDataReader reader = await comand.ExecuteReaderAsync();
            List<Profesor> profesoresEnLaMateria = new List<Profesor>();
            while (reader.Read())
            {
                Profesor profesor = new Profesor(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(0));
                profesoresEnLaMateria.Add(profesor);
            }
            foreach (Profesor profesor in profesoresEnLaMateria)
            {
                Console.WriteLine($"ID:{profesor.GetId()}");
                Console.WriteLine($"Nombre:{profesor.GetNombre()}");
                Console.WriteLine($"Nombre:{profesor.GetEdad()}");
            }
        }

        public async Task<bool> AsingnarAMateriaAsync(int idProfesor, int idMateria)
        {
            using NpgsqlCommand command = dataSource.CreateCommand($"INSERT INTO universidadnikolay.profesores_dictan VALUES ({idProfesor},{idMateria}) RETURNING id");
            int? resultadoComando = await command.ExecuteNonQueryAsync();
            if (resultadoComando == -1)
            {
                throw new Exception("No se pudo contratar al profesor");

            }
            if (resultadoComando > 1)
            {
                throw new Exception("F");
            }
            if (resultadoComando == 0)
            {
                return false; // no se contrató a nadie
            }
            return true;
        }

    }
}
