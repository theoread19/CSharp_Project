using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs.Request;

namespace WebAPI.Services
{
    public interface IRoleService
    {
        IEnumerable<List<RoleRequest>> GetAll();
        RoleRequest GetById(long id);
        void Insert(RoleRequest req);
        void Update(RoleRequest req);
        void Delete(long id);
        RoleRequest GetByCode(string code);
    }
}
