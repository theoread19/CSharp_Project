using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs.Request;
using Domain.Logging;
using WebAPI.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private ICategoryService _categoryService;
        private ILoggerManager _loggerManager;
        public CategoryController(ICategoryService categoryService, ILoggerManager loggerManager)
        {
            this._categoryService = categoryService;
            this._loggerManager = loggerManager;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<List<CategoryRequest>> GetAllCategory()
        {
            try
            {
                this._loggerManager.LogInfo("Fetching all the category from the storage");
                return _categoryService.GetAll();
            }
            catch (Exception)
            {
                throw new Exception("Exception while fetching all the category from the storage.");
            }
            
            
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public CategoryRequest GetCategoryById(long id)
        {
            try
            {
                this._loggerManager.LogInfo("Fetching a category from the storage");
                return _categoryService.GetById(id);
            }
            catch (Exception) { throw new Exception("Exception while fetching a category from the storage."); }
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void CreateCategory([FromBody] CategoryRequest req)
        {
            try
            {
                this._loggerManager.LogInfo("Inserting a category to the storage");
                _categoryService.Insert(req);
            }
            catch(Exception)
            {
                throw new Exception("Exception while inserting a category to the storage.");
            }

           
            //throw new Exception("Exception while inserting a category to the storage.");
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void UpdateCategory(long id, [FromBody] CategoryRequest req)
        {
            try
            {
                req.Id = id;
                this._loggerManager.LogInfo("Updating a category to the storage");
                _categoryService.Update(req);
            }
            catch (Exception)
            {
                throw new Exception("Exception while updating a category to the storage.");
            }
            
            
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void DeleteCategory(long id)
        {
            try
            {
                this._loggerManager.LogInfo("Deleting a category to the storage");
                _categoryService.Delete(id);
            }
            catch (Exception) { throw new Exception("Exception while deleting a category to the storage."); }
        }
    }
}
