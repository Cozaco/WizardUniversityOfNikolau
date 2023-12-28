using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Models
{
    public class Course
    {
        private int? id;
        private string name;
        private int comission;

        public Course(string name, int comission, int? id = null)
        {
            this.name = name;
            this.id = id;
            this.comission = comission;
        }
        public string GetName()
        {
            return name;
        }

        public int? GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetComission()
        {
            return this.comission;
        }
    }
}
