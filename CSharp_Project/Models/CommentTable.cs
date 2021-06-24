using System;
using System.Collections.Generic;

#nullable disable

namespace CSharp_Project.Models
{
    public partial class CommentTable
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public long CreateBy { get; set; }
        public long NewsId { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual UserTable CreateByNavigation { get; set; }
        public virtual NewsTable News { get; set; }
    }
}
