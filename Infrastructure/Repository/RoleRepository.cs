using CSharp_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CSharp_Project.Repository.iplm
{
    public class RoleRepository : BaseRepository<RoleTable>, IRoleRepository
    {
        private C_ProjectDBContext context;
        public RoleTable getByCode(string code)
        {
            var context = new C_ProjectDBContext();
            return context.RoleTables.Where(b => b.Code == code).FirstOrDefault();
            
        }
    }
}
