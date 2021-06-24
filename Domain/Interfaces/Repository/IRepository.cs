using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepository<TEntity> where TEntity :class
    {
        List<TEntity> GetAll();
        TEntity GetById(long id);
        void Insert(TEntity table);
        void Update(TEntity table);
        void Delete(long id);
        void Save();
    }
}
