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
    public class AlumnoCursaRepository : IAlumnoCursaRepository
    {
        public NpgsqlDataSource dataSource;

        public AlumnoCursaRepository(NpgsqlDataSource dataSource)
        {
            this.dataSource = dataSource;
        }
        public async Task ConocerAlumnosAsync(int idMateria)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT alumnos.id,alumnos.nombre,alumnos.edad FROM universidadnikolay.alumnos JOIN universidadnikolay.alumnos_cursan ON alumnos.id=alumnos_cursan.alumno_id WHERE alumnos_cursan.materia_id={idMateria}");
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

        public async Task ConocerMateriasAsync(int idAlumno)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT materias.id,materias.nombre FROM universidadnikolay.materias JOIN universidadnikolay.alumnos_cursan ON materias.id=alumnos_cursan.materia_id WHERE alumnos_cursan.alumno_id={idAlumno}");
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

        public async Task ConocerProfdeAlumnoAsync(int idAlumno)
        {
            await using NpgsqlCommand comand = dataSource.CreateCommand($"SELECT profesores.id,profesores.nombre FROM universidadnikolay.profesores JOIN universidadnikolay.profesores_dictan ON profesores.id=profesores_dictan.profesor_id JOIN universidadnikolay.alumnos_cursan ON profesores_dictan.materia_id=alumnos_cursan.materia_id WHERE alumnos_cursan.alumno_id={idAlumno}");
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

        public async Task<AlumnoCursa?> InscribirAMateriaAsync(int idAlumno,int idMateria)
        {
            using NpgsqlCommand command = dataSource.CreateCommand($"INSERT INTO universidadnikolay.alumnos_cursan VALUES ({idAlumno},{idMateria}) RETURNING id");
            int? resultadoComando = await command.ExecuteNonQueryAsync();
            if (resultadoComando == -1)
            {
                throw new Exception("No se pudo inscribir al alumno");

            }
            if (resultadoComando > 1)
            {
                throw new Exception("F");
            }
            if (resultadoComando == 0)
            {
                return null; // no se inscribió ningún alumno
            }
            AlumnoCursa alumnoCursa= new AlumnoCursa(idAlumno,idMateria);
            return alumnoCursa;
        }
    }
}
