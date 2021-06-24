
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Project.Request;
using CSharp_Project.Services;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharp_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public IRoleService _roleService;
        private ILoggerManager _loggerManager;
        public RoleController(IRoleService roleService, ILoggerManager loggerManager)
        {
            _roleService = roleService;
            this._loggerManager = loggerManager;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public IEnumerable<List<RoleRequest>> GetAllRole()
        {
            try
            {
                this._loggerManager.LogInfo("Fetching all the role from the storage");
                return this._roleService.GetAll();
            }
            catch (Exception)
            {
                throw new Exception("Exception while fetching all the role from the storage.");
            }
        }   

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public RoleRequest GetRoleById(long id)
        {
            try
            {
                this._loggerManager.LogInfo("Fetching a role from the storage");
                return _roleService.GetById(id);
            }
            catch (Exception)
            {
                throw new Exception("Exception while fetching a role from the storage.");
            }
        }

        // POST api/<RoleController>
        [HttpPost]
        public void CreateRole([FromBody] RoleRequest req)
        {
            try
            {
                this._loggerManager.LogInfo("Inserting a role to the storage");
                _roleService.Insert(req);
            }
            catch (Exception)
            {
                throw new Exception("Exception while inserting a role to the storage.");
            }           
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public void UpdateRole(long id, [FromBody] RoleRequest req)
        {
            try
            {
                req.Id = id;
                this._loggerManager.LogInfo("Updating a role to the storage");
                _roleService.Update(req);
            }
            catch (Exception)
            {
                throw new Exception("Exception while updating a role to the storage.");
            }
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public void DeleteRole(long id)
        {try
            {
                this._loggerManager.LogInfo("Deleting a role to the storage");
                _roleService.Delete(id);
            }
            catch (Exception) { throw new Exception("Exception while deleting a role to the storage."); }
        }

    }
}
