using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Project.Models;

namespace CSharp_Project.Repository.iplm
{
    public class NewsRepository : BaseRepository<NewsTable>, INewsRepository
    {
        public void deleteCascade(long id)
        {
            var context = new C_ProjectDBContext();
            var newsTable = context.NewsTables.Single(e => e.Id == id);
            var commentTable = context.CommentTables.Single(e => e.News == newsTable);
            context.Remove(newsTable);
            context.SaveChanges();
        }
    }
}
