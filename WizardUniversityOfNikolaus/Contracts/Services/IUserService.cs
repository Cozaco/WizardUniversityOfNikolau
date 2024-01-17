using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSmart.Contracts.Services
{
    public interface IUserService
    {
        Task<bool> CheckPasswordAsync(string mail, string password);
    }
}
