using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> 
        where T : class, IDataModel
    {
        public virtual IEnumerable<T> Get()
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<T>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
