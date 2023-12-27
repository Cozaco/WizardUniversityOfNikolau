using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Models
{
    public abstract class User
    {
        public int? Id { get; set; }
        private string nombre; 
        private int edad;


        public User(string nombre,int edad, int? id=null)
        {
            this.nombre = nombre;
            this.Id = id;
            this.edad = edad;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public int? GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            this.Id = id;
        }

        public int GetEdad()
        {
            return edad;
        }
    }
}
