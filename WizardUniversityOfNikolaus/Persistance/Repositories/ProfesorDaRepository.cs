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
    internal class ProfesorDaRepository : IProfesorDaRepository
    {
        public NpgsqlDataSource dataSource;

        public ProfesorDaRepository(NpgsqlDataSource dataSource)
        {
            this.dataSource = dataSource;
        }
        public async Task ConocerAlumnosdeProfesorAsync(int idProfesor)
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

        public async Task ConocerMateriasAsync(int idProfesor)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT materias.id,materias.nombre " +
                                                                        $"FROM universidadnikolay.materias " +
                                                                        $"JOIN universidadnikolay.profesores_dictan " +
                                                                        $"ON materias.id=profesores_dictan.materia_id " +
                                                                        $"WHERE profesores_dictan.profesor_id={idProfesor}");
            using NpgsqlDataReader reader = await comand.ExecuteReaderAsync();
            List<Materia> materiasQueCursa = new List<Materia>();
            while (reader.Read())
            {
                Materia materia = new Materia(reader.GetString(1), reader.GetInt32(0));
                materiasQueCursa.Add(materia);
            }
            foreach (Materia materia in materiasQueCursa)
            {
                Console.WriteLine($"ID:{materia.GetId()}");
                Console.WriteLine($"Nombre:{materia.GetNombre()}");
            }
        }

        public async Task ConocerProfdeMateriaAsync(int idMateria)
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

        public async Task<ProfesorDa?> ContratarProfesorEnMateriaAsync(int idProfesor,int idMateria)
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
                return null; // no se contrató a nadie
            }
            ProfesorDa profesorDa=new ProfesorDa(idProfesor,idMateria);
            return profesorDa;
        }
    }
}
