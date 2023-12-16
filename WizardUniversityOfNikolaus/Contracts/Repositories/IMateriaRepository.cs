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
        public Task DeleteAsync(Materia materia);
        public Task UpdateAsync(Materia materia);
    }
}
