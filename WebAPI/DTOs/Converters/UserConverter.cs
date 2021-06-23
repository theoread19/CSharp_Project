using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Project.Request;
using CSharp_Project.Models;

namespace WebAPI.DTOs.Converters
{
    public class UserConverter
    {
        public UserRequest toReq(UserTable table)
        {
            UserRequest req = new UserRequest();
            req.Id = table.Id;
            req.Fullname = table.Fullname;
            req.Username = table.Username;
            req.RoleId = table.RoleId;
            return req;
        }

        public UserTable toTable(UserRequest req)
        {
            var table = new UserTable();
            table.Fullname = req.Fullname;
            table.Username = req.Username;
            table.Password = req.Password;
            table.RoleId = req.RoleId;
            return table;
        }

        public void toTable(ref UserTable table, UserRequest req)
        {
            table.Fullname = req.Fullname;
            table.Username = req.Username;
            table.Password = req.Password;
            table.RoleId = req.RoleId;
        }
    }
}
