using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Contracts.Repositories;
using Contracts.Models;
using Npgsql;
using NpgsqlTypes;
using UniSmart.Contracts.Models.Exceptions;

namespace Persistance.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public NpgsqlDataSource dataSource;
       

        public StudentRepository(NpgsqlDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public async Task<Student> CreateAsync(Student student)
        {
            
            using NpgsqlCommand command = dataSource.CreateCommand($"INSERT INTO universidadnikolay.alumnos (nombre,edad) " +
                                                                   $"VALUES ('{student.Name}',{student.Age}) " +
                                                                   $"RETURNING id");
            
            int? resultadoComando=(int?)await command.ExecuteScalarAsync();
            if ( resultadoComando == null )
            {
                throw new Exception("No se pudo agregar alumno");

            }
            student.Id = resultadoComando.Value;
            return student;
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

        public async Task<Student> UpdateAsync(Student student) //alumno con el update HECHO
        {
            using NpgsqlCommand command = dataSource.CreateCommand($"UPDATE universidadnikolay.alumnos " +
                                                                   $"SET nombre = '{student.Name} ', edad =  {student.Age} " +
                                                                   $"WHERE id = {student.Id}");
            
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
                throw new Exception(); // no se borró ningún alumnos
            }
            return student; //se borró exitosamente un alumno
        }
        public async Task<List<Student>> GetCourseStudentsAsync(int idCourse)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT alumnos.id,alumnos.nombre,alumnos.edad " +
                                                                        $"FROM universidadnikolay.alumnos " +
                                                                        $"JOIN universidadnikolay.alumnos_cursan " +
                                                                        $"ON alumnos.id=alumnos_cursan.alumno_id " +
                                                                        $"WHERE alumnos_cursan.materia_id={idCourse}");
            
            using NpgsqlDataReader reader = await comand.ExecuteReaderAsync();
            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                Student student = new Student(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(0)); //TODO Mapeo para no tener que cambiar los numeros cuando agrego una tabla
                students.Add(student);
            }
            if (students.Count== 0)
            {
                throw new EmptyListException(); //TODO Preguntar Nico
            }
            return students;
        }

        public async Task<List<Student>> GetProfessorStudentsAsync(int idProfessor)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT alumnos.id,alumnos.nombre " +
                                                                        $"FROM universidadnikolay.alumnos " +
                                                                        $"JOIN universidadnikolay.alumnos_cursan " +
                                                                        $"ON alumnos.id=alumnos_cursan.alumno_id " +
                                                                        $"JOIN universidadnikolay.profesores_dictan " +
                                                                        $"ON profesores_dictan.materia_id=alumnos_cursan.materia_id " +
                                                                        $"WHERE profesores_dictan.profesor_id={idProfessor}");
            
            using NpgsqlDataReader reader = await comand.ExecuteReaderAsync();
            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                Student student = new Student(reader.GetString(1), reader.GetInt32(0));
                students.Add(student);
            }
            return students;
        }

        public async Task<long> CountCoursesAsync(int idStudent)
        {
            await using NpgsqlCommand chequeoQuery = dataSource.CreateCommand($"SELECT COUNT(id_alumno) " +
                                                                              $"FROM universidadnikolay.alumnos_cursan " +
                                                                              $"WHERE id_alumno={idStudent}");
            long? resultadoQuery =(long?)chequeoQuery.ExecuteScalar();
            if ( resultadoQuery == null )
            {
                throw new Exception("No se pudo hacer la Query");
            }
            return (int) resultadoQuery;
        }

        public async Task<bool> TakeCourseAsync(int idStudent, int idCourse)
        {
            await using NpgsqlCommand command = dataSource.CreateCommand($"INSERT INTO universidadnikolay.alumnos_cursan " +
                                                                         $"VALUES ({idStudent},{idCourse})");
            
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

        public async Task<bool> LeaveCourseAsync(int idStudent, int idCourse)//esta
        {
            await using NpgsqlCommand command = dataSource.CreateCommand($"DELETE FROM universidadnikolay.alumnos_cursan " +
                                                                         $"WHERE alumnos_cursan.alumno_id = {idStudent} " +
                                                                         $"AND alumno_cursan.materia_id = {idCourse}");

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

        public async Task<bool> ValidateInfoAsync(int id, string name, int edad)
        {
            using NpgsqlCommand command = dataSource.CreateCommand($"SELECT * " +
                                                                   $"FROM universidadnikolay.alumnos " +
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

        public async Task<Student> GetStudentAsync(int idStudent)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT * " +
                                                                       $"FROM universidadnikolay.alumnos" +
                                                                       $"WHERE alumno.id={idStudent}");
            using NpgsqlDataReader reader = await comand.ExecuteReaderAsync();
            Student student = new Student(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(0));
            return student;
        }
    }

}

