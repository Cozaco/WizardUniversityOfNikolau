﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Models
{
    public class AlumnoCursa
    {
        private int idAlumno;
        private int idMateria;

        public int GetIdAlumno()
        {
            return idAlumno;
        }
        public int GetIdMateria()
        {
            return idMateria;
        }
    }
}
