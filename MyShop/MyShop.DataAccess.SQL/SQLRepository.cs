using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.SQL
{
    public class SQLRepository<N> : IRepository<N> where N : BaseEntity
    {
        internal DataContext context;
        internal DbSet<N> dbSet;

        public SQLRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<N>();
        }
        public IQueryable<N> Collection()
        {
            return dbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(string Id)
        {
            var n = Find(Id);
            if (context.Entry(n).State == EntityState.Detached)
                dbSet.Attach(n);

            dbSet.Remove(n);
        }

        public N Find(string Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(N n)
        {
            dbSet.Add(n);
        }

        public void Update(N n)
        {
            dbSet.Attach(n);
            context.Entry(n).State = EntityState.Modified;
        }
    }
}
