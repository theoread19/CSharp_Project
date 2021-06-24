using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Repository;
using Domain.Models;
using Infrastructure.ContextConfigure;

namespace Infrastructure.Repository
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
