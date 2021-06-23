using System;
using System.Collections.Generic;

#nullable disable

namespace CSharp_Project.Models
{
    public partial class NewsTable
    {
        public NewsTable()
        {
            CommentTables = new HashSet<CommentTable>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public string ShortDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public long CategoryId { get; set; }
        public long CreateBy { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual CategoryTable Category { get; set; }
        public virtual UserTable CreateByNavigation { get; set; }
        public virtual ICollection<CommentTable> CommentTables { get; set; }
    }
}
