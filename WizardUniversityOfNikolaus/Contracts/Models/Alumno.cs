﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Models
{
    public class Alumno : Persona
    {
        public Alumno(string nombre,int edad, int? id = null) : base(nombre,edad, id) { }
    }
}
