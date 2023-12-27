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
    public class MateriaRepository : ISubjectRepository
    {
        public NpgsqlDataSource dataSource;

        public MateriaRepository(NpgsqlDataSource dataSource)
        {
            this.dataSource = dataSource;
        }
        public async Task CrearAsync(Subject materia)
        {

            using NpgsqlCommand command = dataSource.CreateCommand($"INSERT INTO universidadnikolay.materias (nombre, comision)" +
                                                                   $" VALUES ('{materia.GetNombre()}', {materia.GetComision()}) " +
                                                                   $"RETURNING id");
            
            int? resultadoComando = (int?) await command.ExecuteScalarAsync();
            if (resultadoComando == null)
            {
                throw new Exception("No se pudo agregar materia");

            }
            materia.SetId(resultadoComando.Value);
            return;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using NpgsqlCommand command = dataSource.CreateCommand($"DELETE FROM universidadnikolay.materias " +
                                                                         $"WHERE materias.id = {id}");
            
            int resultadoComando = await command.ExecuteNonQueryAsync(); // hace la query y no devuelve nada
            Console.WriteLine(resultadoComando);
            if (resultadoComando == -1)
            {
                throw new Exception("Error al eliminar el materias");
            }
            if (resultadoComando > 1)
            {
                throw new Exception("F");
            }
            if (resultadoComando == 0)
            {
                return false; // no se borró ninguna materia
            }
            return true; //se borró exitosamente una materia
        }

        public async Task<bool> UpdateAsync(Subject materia) //materia con el update HECHO
        {
            using NpgsqlCommand command = dataSource.CreateCommand($"UPDATE universidadnikolay.materias " +
                                                                   $"SET nombre = '{materia.GetNombre()}', comision = {materia.GetComision()}" +
                                                                   $" WHERE id = {materia.GetId()}");
            
            int resultadoComando = await command.ExecuteNonQueryAsync(); // hace la query y no devuelve nada
            if (resultadoComando == -1)
            {
                throw new Exception("Error al actualizar la materia");
            }
            if (resultadoComando > 1)
            {
                throw new Exception("F");
            }
            if (resultadoComando == 0)
            {
                return false; // no se actualizo materia
            }
            return true; //se actualizo exitosamente una materia

        }

        public async Task MateriasDeAlumnoAsync(int idAlumno)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT materias.id,materias.nombre " +
                                                                        $"FROM universidadnikolay.materias " +
                                                                        $"JOIN universidadnikolay.alumnos_cursan " +
                                                                        $"ON materias.id=alumnos_cursan.materia_id " +
                                                                        $"WHERE alumnos_cursan.alumno_id={idAlumno}");
            
            using NpgsqlDataReader reader = await comand.ExecuteReaderAsync();
            List<Subject> materiasQueCursa = new List<Subject>();
            while (reader.Read())
            {
                Subject materia = new Subject(reader.GetString(1), reader.GetInt32(0));
                materiasQueCursa.Add(materia);
            }
            foreach (Subject materia in materiasQueCursa)
            {
                Console.WriteLine($"ID:{materia.GetId()}");
                Console.WriteLine($"Nombre:{materia.GetNombre()}");
            }
        }

        public async Task MateriasDeProfesorAsync(int idProfesor)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT materias.id,materias.nombre " +
                                                                        $"FROM universidadnikolay.materias " +
                                                                        $"JOIN universidadnikolay.profesores_dictan " +
                                                                        $"ON materias.id=profesores_dictan.materia_id " +
                                                                        $"WHERE profesores_dictan.profesor_id={idProfesor}");
            
            using NpgsqlDataReader reader = await comand.ExecuteReaderAsync();
            List<Subject> materiasQueCursa = new List<Subject>();
            while (reader.Read())
            {
                Subject materia = new Subject(reader.GetString(1), reader.GetInt32(0));
                materiasQueCursa.Add(materia);
            }
            foreach (Subject materia in materiasQueCursa)
            {
                Console.WriteLine($"ID:{materia.GetId()}");
                Console.WriteLine($"Nombre:{materia.GetNombre()}");
            }
        }
    }
}
