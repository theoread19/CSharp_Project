using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repository;
using WebAPI.DTOs.Converters;
using Domain.Models;
using WebAPI.DTOs.Request;

namespace WebAPI.Services.impl
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private UserConverter converter = new UserConverter();

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public void Delete(long id)
        {
            _userRepository.Delete(id);
            _userRepository.Save();
        }

        public IEnumerable<List<UserRequest>> GetAll()
        {
            List<UserTable> tables = _userRepository.GetAll();
            List<UserRequest> reqs = new List<UserRequest>();
            foreach (UserTable item in tables)
            {
                var req = new UserRequest();
                req = converter.toReq(item);
                reqs.Add(req);
            }
            yield return reqs;
        }

        public UserRequest GetById(long id)
        {
            return converter.toReq(_userRepository.GetById(id));
        }

        public void Insert(UserRequest req)
        {
            _userRepository.Insert(converter.toTable(req));
            _userRepository.Save();
        }

        public void Update(UserRequest req)
        {
            var table = _userRepository.GetById(req.Id);
            converter.toTable(ref table, req);
            _userRepository.Update(table);
            _userRepository.Save();
        }
    }
}
