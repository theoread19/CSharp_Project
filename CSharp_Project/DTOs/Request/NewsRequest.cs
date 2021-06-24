using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_Project.Request
{
    public class NewsRequest
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public string ShortDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public long CategoryId { get; set; }
        public long CreateBy { get; set; }
    }
}
