using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Project.Models;
using CSharp_Project.Request;
namespace WebAPI.DTOs.Converters
    public class CommentConverter
    {
        public CommentRequest toReq(CommentTable table)
        {
            CommentRequest req = new CommentRequest();
            req.Content = table.Content;
            req.CreateBy = table.CreateBy;
            req.CreateDate = table.CreateDate;
            req.Id = table.Id;
            req.NewsId = table.NewsId;
            return req;
        }

        public CommentTable toTable(CommentRequest req)
        {
            var table = new CommentTable();
            table.Content = req.Content;
            table.CreateBy = req.CreateBy;
            table.CreateDate = req.CreateDate;
            table.NewsId = req.NewsId;
            return table;
        }

        public void toTable(ref CommentTable table, CommentRequest req)
        {
            table.Content = req.Content;
            table.CreateBy = req.CreateBy;
            table.CreateDate = req.CreateDate;
            table.NewsId = req.NewsId;
        }
    }
}
