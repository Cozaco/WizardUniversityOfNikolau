using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSmart.Contracts.Exceptions
{
    public class UnauthorizedException : ExpectedException
    {
        public override int Code => 401;

        public UnauthorizedException(string message):base(message)
        {

        }
    }
}
