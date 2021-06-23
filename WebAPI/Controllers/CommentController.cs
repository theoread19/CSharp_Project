using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Project.Request;
using CSharp_Project.Services;
using LoggerService;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;
        private ILoggerManager _loggerManager;
        public CommentController(ICommentService commentService, ILoggerManager loggerManager)
        {
            this._commentService = commentService;
            this._loggerManager = loggerManager;
        }

        // GET: api/<CommentController>
        [HttpGet]
        public IEnumerable<List<CommentRequest>> GetAllComment()
        {
            try
            {
                this._loggerManager.LogInfo("Fetching all the comment from the storage");
                return _commentService.GetAll();
            }
            catch (Exception) { throw new Exception("Exception while fetching all the comment from the storage."); }
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public CommentRequest GetCommentById(long id)
        {
            try
            {
                this._loggerManager.LogInfo("Fetching a category from the storage");
                return _commentService.GetById(id);
            }
            catch (Exception) { throw new Exception("Exception while fetching a category from the storage."); }
        }

        // POST api/<CommentController>
        [HttpPost]
        public void CreateComment([FromBody] CommentRequest req)
        {
            try
            {
                this._loggerManager.LogInfo("Inserting a comment to the storage");
                _commentService.Insert(req);
            }
            catch (Exception) { throw new Exception("Exception while inserting a comment to the storage."); }
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public void UpdateComment(long id, [FromBody] CommentRequest req)
        {
            try
            {
                req.Id = id;
                this._loggerManager.LogInfo("Updating a category to the storage");
                _commentService.Update(req);
            }
            catch (Exception)
            {
                throw new Exception("Exception while updating a category to the storage.");
            }
            
            
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public void DeleteComment(long id)
        {
            try
            {
                this._loggerManager.LogInfo("Deleting a the category to the storage");
                _commentService.Delete(id);
            }
            catch (Exception) { throw new Exception("Exception while deleting a category to the storage."); }
        }
    }
}
