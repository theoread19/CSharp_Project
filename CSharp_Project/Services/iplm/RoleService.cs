using CSharp_Project.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Project.Models;
using CSharp_Project.Converters;
using CSharp_Project.Repository;

namespace CSharp_Project.Services.iplm
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
