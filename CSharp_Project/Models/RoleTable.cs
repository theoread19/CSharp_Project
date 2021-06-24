using System;
using System.Collections.Generic;

#nullable disable

namespace CSharp_Project.Models
{
    public partial class RoleTable
    {
        public RoleTable()
        {
            UserTables = new HashSet<UserTable>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserTable> UserTables { get; set; }
    }
}
