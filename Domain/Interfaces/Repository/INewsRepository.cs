using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repository
{
    public interface INewsRepository : IRepository<NewsTable>
    {
        public void deleteCascade(long id);
    }
}
