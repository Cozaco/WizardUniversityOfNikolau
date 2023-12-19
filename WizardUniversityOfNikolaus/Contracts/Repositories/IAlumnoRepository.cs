using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IAlumnoRepository
    {
        public Task CrearAsync(Alumno alumno);
        
        public Task<bool> DeleteAsync(int id);

        public Task<bool> UpdateAsync(Alumno alumno);
        
    }
}
