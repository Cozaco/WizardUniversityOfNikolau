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
        private string name; 
        private int age;


        public User(string name,int age, int? id=null)
        {
            this.name = name;
            this.Id = id;
            this.age = age;
        }

        public string GetName()
        {
            return name;
        }

        public int? GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            this.Id = id;
        }

        public int GetAge()
        {
            return age;
        }
    }
}
