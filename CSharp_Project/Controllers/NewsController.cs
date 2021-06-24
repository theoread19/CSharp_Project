using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Project.Request;
using CSharp_Project.Services;
using LoggerService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharp_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsService _newsService;
        private ILoggerManager _loggerManager;
        public NewsController(INewsService newsService, ILoggerManager loggerManager)
        {
            this._newsService = newsService;
            this._loggerManager = loggerManager;
        }
        // GET: api/<NewsController>
        [HttpGet]
        public IEnumerable<List<NewsRequest>> GetAllNews()
        {
            try
            {
                this._loggerManager.LogInfo("Fetching all the news from the storage");
                return _newsService.GetAll();
            }
            catch (Exception) { throw new Exception("Exception while fetching all the news from the storage."); }
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public NewsRequest GetNewsById(long id)
        {
            try
            {
                this._loggerManager.LogInfo("Fetching a news from the storage");
                return _newsService.GetById(id);
            }
            catch (Exception) { throw new Exception("Exception while fetching a news from the storage."); }
        }

        // POST api/<NewsController>
        [HttpPost]
        public void CreateNews([FromBody] NewsRequest req)
        {
            try
            {
                this._loggerManager.LogInfo("Inserting a news to the storage");
                _newsService.Insert(req);
            }
            catch (Exception) { throw new Exception("Exception while inserting a news to the storage."); }
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        public void UpdateNews(long id, [FromBody] NewsRequest req)
        {
            try
            {
                req.Id = id;
                this._loggerManager.LogInfo("Updating a news to the storage");
                _newsService.Update(req);
            }
            catch (Exception) { throw new Exception("Exception while updating a news to the storage."); }
        }

        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        public void DeleteNews(long id)
        {
            try
            {
                this._loggerManager.LogInfo("Deleting a the news to the storage");
                _newsService.Delete(id);
            }
            catch (Exception) { throw new Exception("Exception while deleting a news to the storage."); }
        }
    }
}
