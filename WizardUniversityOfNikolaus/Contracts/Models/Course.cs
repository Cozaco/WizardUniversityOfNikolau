using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSmart.Contracts.Models
{
    public class Course
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Comission { get; set; }

        public Course(string name, int comission, int? id = null)
        {
            this.Name = name;
            this.Id = id;
            this.Comission = comission;
        }
        public string GetName()
        {
            return Name;
        }

        public int? GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            this.Id = id;
        }

        public int GetComission()
        {
            return this.Comission;
        }
    }
}
