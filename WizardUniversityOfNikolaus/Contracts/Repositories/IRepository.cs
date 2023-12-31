using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSmart.Contracts.Repositories
{
    public interface IRepository<T> //TODO tiene que tener create delete y upddate 
    {
        public Task<T> CreateAsync(T entity);
    }
}
