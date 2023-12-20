using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Models
{
    public class Profesor : Persona
    {
        public Profesor(string nombre,int edad=0, int? id = null) : base(nombre,edad, id) { }


    }
}
