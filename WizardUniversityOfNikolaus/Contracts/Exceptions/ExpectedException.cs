using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSmart.Contracts.Exceptions
{
    public abstract class ExpectedException : Exception
    {
        public int Code { get; set; }
        public ExpectedException() { }
    }
}
