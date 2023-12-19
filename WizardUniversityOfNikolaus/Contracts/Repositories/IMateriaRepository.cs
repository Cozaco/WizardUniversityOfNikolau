using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IMateriaRepository
    {
        public Task CrearAsync(Materia materia);
        public Task<bool> DeleteAsync(int idMateria);
        public Task<bool> UpdateAsync(Materia materia);
    }
}
