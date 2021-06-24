using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs.Request;

namespace WebAPI.Services
{
    public interface IUserService
    {
        IEnumerable<List<UserRequest>> GetAll();
        UserRequest GetById(long id);
        void Insert(UserRequest req);
        void Update(UserRequest req);
        void Delete(long id);
    }
}
