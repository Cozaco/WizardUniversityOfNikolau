﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSmart.Contracts.Models
{
    public class Professor : User
    {
        public Professor(string name, int age = 0, int? id = null, string? userName = null) : base(name, age, id, userName) { }

    }
}
