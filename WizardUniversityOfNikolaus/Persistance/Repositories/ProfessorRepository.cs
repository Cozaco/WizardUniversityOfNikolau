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
    public class ProfessorRepository : IProfessorRepository
    {
        public NpgsqlDataSource dataSource;

        public ProfessorRepository(NpgsqlDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public async Task<Professor> CreateAsync(Professor professor)
        {

            using NpgsqlCommand command = dataSource.CreateCommand($"INSERT INTO universidadnikolay.profesores (nombre,edad) " +
                                                                   $"VALUES ('{professor.Name}',{professor.Age}) " +
                                                                   $"RETURNING id");
            
            int? resultadoComando = (int?) await command.ExecuteScalarAsync();
            if (resultadoComando == null)
            {
                throw new Exception("No se pudo agregar profesor");

            }
            professor.Id = resultadoComando.Value;
            return professor;
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

        public async Task<Professor> UpdateAsync(Professor professor) //alumno con el update HECHO
        {
            using NpgsqlCommand command = dataSource.CreateCommand($"UPDATE universidadnikolay.profesores " +
                                                                   $"SET nombre = '{professor.Name}', edad = {professor.Age}" +
                                                                   $" WHERE id = {professor.Id}");
            
            int resultadoComando = await command.ExecuteNonQueryAsync(); // hace la query y no devuelve nada
            if (resultadoComando == -1)
            {
                throw new Exception("Error while updating the professor");
            }
            if (resultadoComando > 1)
            {
                throw new Exception("F");
            }
            if (resultadoComando == 0)
            {
                throw new Exception("Error. No professor was afected"); // no se actualizo profesor
            }
            return professor; //se actualizo exitosamente un profesor
        }

        public async Task<List<Professor>> GetStudentProfessorsAsync(int idStudent)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT profesores.id,profesores.nombre " +
                                                                        $"FROM universidadnikolay.profesores " +
                                                                        $"JOIN universidadnikolay.profesores_dictan " +
                                                                        $"ON profesores.id=profesores_dictan.profesor_id " +
                                                                        $"JOIN universidadnikolay.alumnos_cursan " +
                                                                        $"ON profesores_dictan.materia_id=alumnos_cursan.materia_id " +
                                                                        $"WHERE alumnos_cursan.alumno_id={idStudent}");

            using NpgsqlDataReader reader = await comand.ExecuteReaderAsync();
            List<Professor> professors = new List<Professor>();
            while (reader.Read())
            {
                Professor professor = new Professor(reader.GetString(1), reader.GetInt32(0));
                professors.Add(professor);
            }
            return professors;
        }

        public async Task<List<Professor>> GetCourseProfessorsAsync(int idCourse)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT profesores.id,profesores.nombre,profesores.edad " +
                                                                        $"FROM universidadnikolay.profesores " +
                                                                        $"JOIN universidadnikolay.profesores_dictan " +
                                                                        $"ON profesores.id=profesores_dictan.profesor_id " +
                                                                        $"WHERE profesores_dictan.materia_id={idCourse}");

            using NpgsqlDataReader reader = await comand.ExecuteReaderAsync();
            List<Professor> professors = new List<Professor>();
            while (reader.Read())
            {
                Professor profesor = new Professor(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(0));
                professors.Add(profesor);
            }
            return professors;
        }

        public async Task<bool> TakeCourseAsync(int idProfessor, int idCourse)
        {
            using NpgsqlCommand commandChequeo = dataSource.CreateCommand($"SELECT COUNT (id_alumno) " +
                                                                          $"FROM universidadnikolay.profesores_dictan " +
                                                                          $"WHERE id_profesor={idProfessor}");
            int? resultadoChequeo = (int?)await commandChequeo.ExecuteScalarAsync();
            if (resultadoChequeo >= 1)
            {
                Console.WriteLine("El Profesor no puede dictar más materias");
                return false;
            }

            using NpgsqlCommand command = dataSource.CreateCommand($"INSERT INTO universidadnikolay.profesores_dictan " +
                                                                   $"VALUES ({idProfessor},{idCourse})");

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

        public async Task<bool> LeaveCourseAsync(int idProfessor, int idCourse)
        {
            await using NpgsqlCommand command = dataSource.CreateCommand($"DELETE FROM universidadnikolay.profesores_dictan " +
                                                                          $"WHERE profesores_dictan.profesor_id = {idProfessor} " +
                                                                          $"AND profesores_dictan.materia_id={idCourse}");

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
                return false; // El profesor no pudo dejar esa materia
            }
            return true; //El profesor dejó la materia 

        }

        public async Task<bool> ValidateInfoAsync(int id, string name, int edad)
        {
            using NpgsqlCommand command = dataSource.CreateCommand($"SELECT * " +
                                                                   $"FROM universidadnikolay.profesores " +
                                                                   $"WHERE id = {id} " +
                                                                   $"AND nombre={name} " +
                                                                   $"AND edad={edad}");

            int commandResult = await command.ExecuteNonQueryAsync();
            if (commandResult == 1)
            {
                return true;
            }
            return false;
        }

        public async Task<Professor> GetByIdAsync(int idProfessor)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT * " +
                                                                       $"FROM universidadnikolay.profesores" +
                                                                       $"WHERE profesores.id={idProfessor}");
            using NpgsqlDataReader reader = await comand.ExecuteReaderAsync();
            Professor professor = new Professor(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(0));
            return professor;
        }
    }
}
