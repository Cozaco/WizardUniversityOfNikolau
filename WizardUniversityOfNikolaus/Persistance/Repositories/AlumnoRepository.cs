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

        public async Task CrearAsync(Alumno alumno)
        {
            
            using NpgsqlCommand command = dataSource.CreateCommand($"INSERT INTO universidadnikolay.alumnos (nombre,edad) " +
                                                                   $"VALUES ('{alumno.GetNombre()}',{alumno.GetEdad()}) " +
                                                                   $"RETURNING id");
            
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
            await using NpgsqlCommand command = dataSource.CreateCommand($"DELETE FROM universidadnikolay.alumnos " +
                                                                         $"WHERE alumnos.id = {id}");
            
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

        public async Task<bool> UpdateAsync(Alumno alumno) //alumno con el update HECHO
        {
            using NpgsqlCommand command = dataSource.CreateCommand($"UPDATE universidadnikolay.alumnos " +
                                                                   $"SET nombre = '{alumno.GetNombre()}', edad = {alumno.GetEdad()} " +
                                                                   $"WHERE id = {alumno.GetId()}");
            
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
        public async Task AlumnosEnLaMateriaAsync(int idMateria)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT alumnos.id,alumnos.nombre,alumnos.edad " +
                                                                        $"FROM universidadnikolay.alumnos " +
                                                                        $"JOIN universidadnikolay.alumnos_cursan " +
                                                                        $"ON alumnos.id=alumnos_cursan.alumno_id " +
                                                                        $"WHERE alumnos_cursan.materia_id={idMateria}");
            
            using NpgsqlDataReader reader = await comand.ExecuteReaderAsync();
            List<Profesor> alumnosEnLaMateria = new List<Profesor>();
            while (reader.Read())
            {
                Profesor alumno = new Profesor(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(0));
                alumnosEnLaMateria.Add(alumno);
            }
            foreach (Profesor alumno in alumnosEnLaMateria)
            {
                Console.WriteLine($"ID:{alumno.GetId()}");
                Console.WriteLine($"Nombre:{alumno.GetNombre()}");
                Console.WriteLine($"Nombre:{alumno.GetEdad()}");
            }
        }

        public async Task AlumnosDeProfesorAsync(int idProfesor)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT alumnos.id,alumnos.nombre " +
                                                                        $"FROM universidadnikolay.alumnos " +
                                                                        $"JOIN universidadnikolay.alumnos_cursan " +
                                                                        $"ON alumnos.id=alumnos_cursan.alumno_id " +
                                                                        $"JOIN universidadnikolay.profesores_dictan " +
                                                                        $"ON profesores_dictan.materia_id=alumnos_cursan.materia_id " +
                                                                        $"WHERE profesores_dictan.profesor_id={idProfesor}");
            
            using NpgsqlDataReader reader = await comand.ExecuteReaderAsync();
            List<Profesor> alumnos = new List<Profesor>();
            while (reader.Read())
            {
                Profesor alumno = new Profesor(reader.GetString(1), reader.GetInt32(0));
                alumnos.Add(alumno);
            }
            foreach (Profesor profesor in alumnos)
            {
                Console.WriteLine($"ID:{profesor.GetId()}");
                Console.WriteLine($"Nombre:{profesor.GetNombre()}");
            }
        }

        public async Task<int> CountMateriasAsync(int idAlumno)
        {
            await using NpgsqlCommand chequeoQuery = dataSource.CreateCommand($"SELECT COUNT (id_alumno) " +
                                                                          $"FROM universidadnikolay.alumnos_cursan " +
                                                                          $"WHERE id_alumno={idAlumno}");
            int? resultadoQuery = (int?) chequeoQuery.ExecuteScalar();
            if ( resultadoQuery == null )
            {
                throw new Exception("No se pudo hacer la Query");
            }
            return (int) resultadoQuery;
        }

        public async Task<bool> InsertAlumnoEnMateriaAsync(int idAlumno, int idMateria)
        {
            await using NpgsqlCommand command = dataSource.CreateCommand($"INSERT INTO universidadnikolay.alumnos_cursan " +
                                                                   $"VALUES ({idAlumno},{idMateria})");
            
            int? resultadoComando = await command.ExecuteNonQueryAsync();
            if (resultadoComando == -1)
            {
                throw new Exception("No se pudo inscribir al alumno");
            }
            if (resultadoComando == 0)
            {
                return false; // no se inscribió ningún alumno
            }
            return true;
        }

        public async Task<bool> DesinscribirAMateriaAsync(int idAlumno, int idMateria)
        {
            await using NpgsqlCommand command = dataSource.CreateCommand($"DELETE FROM universidadnikolay.alumnos_cursan " +
                                                                         $"WHERE alumnos_cursan.alumno_id = {idAlumno} " +
                                                                         $"AND alumno_cursan.materia_id = {idMateria}");

            int resultadoComando = await command.ExecuteNonQueryAsync(); // hace la query y no devuelve nada
            if (resultadoComando == -1)
            {
                throw new Exception("Error al eliminar el alumno");
            }
            if (resultadoComando == 0)
            {
                return false; // no se desincribió ningún alumno
            }
            return true; //se desincribió exitosamente un alumno

        }
    }
}
