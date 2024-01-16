using Contracts.Models;
using Contracts.Repositories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSmart.Contracts.Repositories;
using UniSmart.Contracts.Services;

namespace Persistance.Repositories
{
    public class CourseRepository :ICourseRepository
    {
        public NpgsqlDataSource dataSource;

        public CourseRepository(IDataSource dataSource)
        {
            this.dataSource = dataSource.GetConnection();
        }
        public async Task<Course> CreateAsync(Course course)
        {

            using NpgsqlCommand command = dataSource.CreateCommand($"INSERT INTO universidadnikolay.materias (nombre, comision)" +
                                                                   $" VALUES ('{course.GetName()}', {course.GetComission()}) " +
                                                                   $"RETURNING id");
            
            int? resultadoComando = (int?) await command.ExecuteScalarAsync();
            if (resultadoComando == null)
            {
                throw new Exception("Couldn´t add the course to database");

            }
            course.SetId(resultadoComando.Value);
            return course;
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

        public async Task<bool> ValidateInfoAsync(int id,string name,int comission)
        {
            using NpgsqlCommand command = dataSource.CreateCommand($"SELECT * " +
                                                                   $"FROM universidadnikolay.materias " +
                                                                   $"WHERE id = {id} " +
                                                                   $"AND nombre={name} " +
                                                                   $"AND comision={comission}" );
            
            int commandResult= await command.ExecuteNonQueryAsync();
            if (commandResult == 1)
            {
                return true;
            }
            return false;
        }
        public async Task<Course> UpdateAsync(Course course) //materia con el update HECHO
        {
            
            using NpgsqlCommand command = dataSource.CreateCommand($"UPDATE universidadnikolay.materias " +
                                                                   $"SET nombre = '{course.GetName()}', comision = {course.GetComission()}" +
                                                                   $" WHERE id = {course.GetId()}");
            
            int resultadoComando = await command.ExecuteNonQueryAsync(); // hace la query y no devuelve nada
            if (resultadoComando == -1)
            {
                throw new Exception("Error al actualizar la materia");
            }
            if (resultadoComando > 1)
            {
                throw new Exception("F");
            }
            return course;
        }

        public async Task<List<Course>> GetStudentCoursesAsync(int idStudent)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT * " +
                                                                        $"FROM universidadnikolay.materias " +
                                                                        $"JOIN universidadnikolay.alumnos_cursan " +
                                                                        $"ON materias.id=alumnos_cursan.materia_id " +
                                                                        $"WHERE alumnos_cursan.alumno_id={idStudent}");
            
            using NpgsqlDataReader reader = await comand.ExecuteReaderAsync();
            List<Course> studentCourses = new List<Course>();
            while (reader.Read())
            {
                Course materia = new Course(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(0));
                studentCourses.Add(materia);
            }
            return studentCourses;
        }

        public async Task<List<Course>> GetProfessorCoursesAsync(int idProfessor)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT * " +
                                                                        $"FROM universidadnikolay.materias " +
                                                                        $"JOIN universidadnikolay.profesores_dictan " +
                                                                        $"ON materias.id=profesores_dictan.materia_id " +
                                                                        $"WHERE profesores_dictan.profesor_id={idProfessor}");
            
            using NpgsqlDataReader reader = await comand.ExecuteReaderAsync();
            List<Course> professorCourses = new List<Course>();
            while (reader.Read())
            {
                Course materia = new Course(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(0));
                professorCourses.Add(materia);
            }
            return professorCourses;
        }

        public async Task<Course> GetByIdAsync(int idCourse)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT * " +
                                                                        $"FROM universidadnikolay.materias " +
                                                                        $"WHERE materias.id = {idCourse}");
            using NpgsqlDataReader reader = await comand.ExecuteReaderAsync();
            if (reader.Read() == false)
            {
                throw new KeyNotFoundException();
            }
            Course course = new Course(reader.GetString(1),reader.GetInt32(2), reader.GetInt32(0));
            return course;
        }
    }
}
