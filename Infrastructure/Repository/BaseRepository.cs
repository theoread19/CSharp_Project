using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharp_Project.Repository.iplm
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        
        private C_ProjectDBContext context;
        private DbSet<TEntity> dbSet;
        public BaseRepository() {
            context = new C_ProjectDBContext();
            dbSet = context.Set<TEntity>();

        }
        public virtual void Delete(long id)
        {
            var std = dbSet.Find(id);
            dbSet.Remove(std);
        }

        public virtual List<TEntity> GetAll()
        {
            List<TEntity> models = dbSet.ToList();
            return models;
        }
            
        public virtual TEntity GetById(long id)
        {
            var std = dbSet.Find(id);
            return std;
        }

        public virtual void Insert(TEntity table)
        {
            dbSet.Add(table);
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }

        public virtual void Update(TEntity table)
        {
            //dbSet.Attach(table);
            context.Entry(table).State = EntityState.Modified;
        }
    }
}
