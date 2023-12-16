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
        public Task RecibirAlumnoAsync(Alumno alumno, Materia materia);

        public Task ConocerAlumnosAsync(Materia materia);

        public Task InscribirAMateriaAsync(Alumno alumno, Materia materia);

        public Task ConocerMateriasAsync(Alumno alumno);

        public Task ConocerProfesoresAsync(Alumno alumno);
    }
}
