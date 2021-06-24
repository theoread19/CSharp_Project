using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Repository;
using Domain.Models;
using Infrastructure.ContextConfigure;

namespace Infrastructure.Repository
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
