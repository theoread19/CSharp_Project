using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_Project.Request
{
    public class CommentRequest
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public long CreateBy { get; set; }
        public long NewsId { get; set; }
    }
}
