using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs.Request;
using Domain.Models;


namespace WebAPI.DTOs.Converters
{
    public class RoleConverter
    {
        public RoleRequest toReq(RoleTable table)
        {
            var req = new RoleRequest();
            req.Id = table.Id;
            req.Code = table.Code;
            req.Name = table.Name;
            return req;
        }

        public RoleTable toTable(RoleRequest req)
        {
            var table = new RoleTable();
            table.Name = req.Name;
            table.Code = req.Code;
            return table;
        }

        public void toTable(ref RoleTable table, RoleRequest req)
        {
            table.Name = req.Name;
            table.Code = req.Code;
        }
    }
}
