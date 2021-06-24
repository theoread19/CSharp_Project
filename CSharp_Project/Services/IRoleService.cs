using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Project.Request;
namespace CSharp_Project.Services
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
