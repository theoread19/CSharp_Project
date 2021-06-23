﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Project.Models;
namespace CSharp_Project.Repository
{
    public interface IRoleRepository : IRepository<RoleTable>
    {
        public RoleTable getByCode(string code);
    }
}
