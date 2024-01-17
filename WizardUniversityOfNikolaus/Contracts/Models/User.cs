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
        public string Name { get; set; } 
        public int Age { get; set; }
        public string? UserName { get; set; }


        public User(string name,int age, int? id = null, string? userName = null)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
            this.UserName = userName;
        }
    }
}
