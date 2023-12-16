using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Models
{
    internal class ProfesorDa
    {
        private int idProfesor;
        private int idMateria;

        public int GetIdProfesor()
        {
            return idProfesor;
        }
        public int GetIdMateria()
        {
            return idMateria;
        }
    }
}
