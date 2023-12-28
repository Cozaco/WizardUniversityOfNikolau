﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Models
{
    public class Student : User
    {
        public Student(string name, int age = 0, int? id = null) : base(name, age, id) { }
    }
}