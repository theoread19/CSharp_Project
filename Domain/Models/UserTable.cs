using System;
using System.Collections.Generic;

#nullable disable

namespace CSharp_Project.Models
{
    public partial class UserTable
    {
        public UserTable()
        {
            CommentTables = new HashSet<CommentTable>();
            NewsTables = new HashSet<NewsTable>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public long RoleId { get; set; }

        public virtual RoleTable Role { get; set; }
        public virtual ICollection<CommentTable> CommentTables { get; set; }
        public virtual ICollection<NewsTable> NewsTables { get; set; }
    }
}
