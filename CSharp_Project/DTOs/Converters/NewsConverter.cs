using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Project.Models;
using CSharp_Project.Request;
namespace CSharp_Project.Converters
{
    public class NewsConverter
    {
        public NewsRequest toReq(NewsTable table)
        {
            NewsRequest req = new NewsRequest();
            req.CategoryId = table.CategoryId;
            req.Content = table.Content;
            req.CreateBy = table.CreateBy;
            req.CreateDate = table.CreateDate;
            req.Id = table.Id;
            req.ShortDescription = table.ShortDescription;
            req.Thumbnail = table.Thumbnail;
            req.Title = table.Title;
            return req;
        }

        public NewsTable toTable(NewsRequest req)
        {
            var table = new NewsTable();
            table.CategoryId = req.CategoryId;
            table.Content = req.Content;
            table.CreateBy = req.CreateBy;
            table.ShortDescription = req.ShortDescription;
            table.Thumbnail = req.Thumbnail;
            table.Title = req.Title;
            table.CreateDate = req.CreateDate;
            return table;
        }

        public void toTable(ref NewsTable table, NewsRequest req)
        {
            table.CategoryId = req.CategoryId;
            table.Content = req.Content;
            table.CreateBy = req.CreateBy;
            table.ShortDescription = req.ShortDescription;
            table.Thumbnail = req.Thumbnail;
            table.Title = req.Title;
            table.CreateDate = req.CreateDate;
        }
    }
}
