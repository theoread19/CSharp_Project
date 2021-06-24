using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class CategoryTable
    {
        public CategoryTable()
        {
            NewsTables = new HashSet<NewsTable>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<NewsTable> NewsTables { get; set; }
    }
}
