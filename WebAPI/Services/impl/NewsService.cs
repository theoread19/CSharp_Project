using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repository;
using WebAPI.DTOs.Converters;
using Domain.Models;
using WebAPI.DTOs.Request;
namespace WebAPI.Services.impl
{
    public class NewsService : INewsService
    {
        private INewsRepository _newsRepository;
        private NewsConverter converter = new NewsConverter();

        public NewsService(INewsRepository newsRepository)
        {
            this._newsRepository = newsRepository;
        }
        public void Delete(long id)
        {
            _newsRepository.deleteCascade(id);
            _newsRepository.Save();
        }

        public IEnumerable<List<NewsRequest>> GetAll()
        {
            List<NewsTable> tables = _newsRepository.GetAll();
            List<NewsRequest> reqs = new List<NewsRequest>();
            foreach (NewsTable item in tables)
            {
                var req = new NewsRequest();
                req = converter.toReq(item);
                reqs.Add(req);
            }
            yield return reqs;
        }

        public NewsRequest GetById(long id)
        {
            return converter.toReq(_newsRepository.GetById(id));
        }

        public void Insert(NewsRequest req)
        {
            _newsRepository.Insert(converter.toTable(req));
            _newsRepository.Save();
        }

        public void Update(NewsRequest req)
        {
            var table = _newsRepository.GetById(req.Id);
            converter.toTable(ref table, req);
            _newsRepository.Update(table);
            _newsRepository.Save();
        }
    }
}
