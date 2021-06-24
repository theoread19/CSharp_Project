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
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        private RoleConverter converter = new RoleConverter();
        public RoleService(IRoleRepository roleRepository)
        {
            this._roleRepository = roleRepository;
        }

        public void Delete(long id)
        {
            _roleRepository.Delete(id);
            _roleRepository.Save();
        }

        public IEnumerable<List<RoleRequest>> GetAll()
        {
            List<RoleTable> tabes = _roleRepository.GetAll();
            List<RoleRequest> reqs = new List<RoleRequest>();
            foreach (RoleTable item in tabes)
            {
                var req = converter.toReq(item);
                reqs.Add(req);
            }
            yield return reqs;
        }

        public RoleRequest GetByCode(string code)
        {
            return converter.toReq(_roleRepository.getByCode(code));
        }

        public RoleRequest GetById(long id)
        {
            return converter.toReq(_roleRepository.GetById(id));
        }

        public void Insert(RoleRequest req)
        {
            _roleRepository.Insert(converter.toTable(req));
            _roleRepository.Save();
        }

        public void Update(RoleRequest req)
        {
            var table = _roleRepository.GetById(req.Id);
            converter.toTable(ref table, req);
            _roleRepository.Update(table);
            _roleRepository.Save();
        }
    }
}
