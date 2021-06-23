using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Project.Request;
using CSharp_Project.Models;
namespace WebAPI.DTOs.Converters
{
    public class CategoryConverter
    {
        public CategoryRequest toReq(CategoryTable table)
        {
            var req = new CategoryRequest();
            req.Id = table.Id;
            req.Code = table.Code;
            req.Name = table.Name;
            return req;
        }

        public CategoryTable toTable(CategoryRequest req)
        {
            var table = new CategoryTable();
            table.Code = req.Code;
            table.Name = req.Name;
            return table;
        }

        public void toTable(ref CategoryTable table, CategoryRequest req)
        {
            table.Code = req.Code;
            table.Name = req.Name;
        }
    }
}
