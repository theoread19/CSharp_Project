using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Project.Models;
namespace CSharp_Project.Repository
{
    public interface INewsRepository : IRepository<NewsTable>
    {
        public void deleteCascade(long id);
    }
}
