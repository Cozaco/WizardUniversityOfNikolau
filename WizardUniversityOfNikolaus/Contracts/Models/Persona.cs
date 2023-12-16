using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Models
{
    public abstract class Persona
    {
        private int? id;
        private string nombre; 
        private int edad;


        public Persona(string nombre,int edad, int? id=null)
        {
            this.nombre = nombre;
            this.id = id;
            this.edad = edad;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public int? GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetEdad()
        {
            return edad;
        }
    }
}
