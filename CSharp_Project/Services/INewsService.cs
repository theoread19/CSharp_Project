using CSharp_Project.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_Project.Services
{
    public interface INewsService
    {
        IEnumerable<List<NewsRequest>> GetAll();
        NewsRequest GetById(long id);
        void Insert(NewsRequest req);
        void Update(NewsRequest req);
        void Delete(long id);
    }
}
