﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSmart.Contracts.Exceptions
{
    public class NotFoundException : ExpectedException
    {
        public override int Code => 404;

        public NotFoundException(string message):base(message)
        {

        }
    }
}
