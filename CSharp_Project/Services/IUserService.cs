using CSharp_Project.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_Project.Services
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
