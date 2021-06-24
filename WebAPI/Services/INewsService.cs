using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs.Request;

namespace WebAPI.Services
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
