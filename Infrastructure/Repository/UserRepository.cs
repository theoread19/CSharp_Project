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
    public class UserRepository : BaseRepository<UserTable>, IUserRepository
    {
    }
}
