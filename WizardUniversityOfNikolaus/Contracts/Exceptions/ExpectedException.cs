using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSmart.Contracts.Exceptions
{
    public abstract class ExpectedException : Exception
    {
        public abstract int Code { get;}
        public ExpectedException(string message):base(message) { }
    }
}
