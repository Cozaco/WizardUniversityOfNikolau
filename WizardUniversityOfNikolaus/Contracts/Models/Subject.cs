using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Models
{
    public class Subject
    {
        private int? id;
        private string nombre;
        private int comision;

        public Subject(string nombre, int comision, int? id = null)
        {
            this.nombre = nombre;
            this.id = id;
            this.comision = comision;
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

        public int GetComision()
        {
            return this.comision;
        }
    }
}
