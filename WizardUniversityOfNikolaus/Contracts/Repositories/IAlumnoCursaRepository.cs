using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IAlumnoCursaRepository
    {
        public Task ConocerAlumnosAsync(int idMateria);

        public Task InscribirAMateriaAsync(int idAlumnos, int idMateria);

        public Task ConocerMateriasAsync(int idAlumno);

        public Task ConocerProfdeAlumnoAsync(int idAlumno);
    }
}
