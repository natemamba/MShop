using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class InMemoyRepository<N> where N : BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<N> items;
        string ClassName;

        public InMemoyRepository()
        {
            ClassName = typeof(N).Name;
            items = cache[ClassName] as List<N>;
            if (items == null)
            {
                items = new List<N>();
            }
        }

        public void Commit()
        {
            cache[ClassName] = items;
        }

        public void Insert(N n)
        {
            items.Add(n);
        }

        public void Update(N n)
        {
            N nToUpdate = items.Find(i => i.Id == n.Id);

            if (nToUpdate != null)
            {
                nToUpdate = n;
            }
            else
            {
                throw new Exception(ClassName + " Not found");
            }
        }

        public N Find(string Id)
        {
            N n = items.Find(i => i.Id == Id);
            if (n != null)
            {
                return n;
            }
            else
            {
                throw new Exception(ClassName + " Not found");
            }
        }

        public IQueryable<N> Collection()
        {
            return items.AsQueryable();
        }

        public void Delete(string Id)
        {
            N nToDelete = items.Find(i => i.Id == Id);

            if (nToDelete != null)
            {
                items.Remove(nToDelete);
            }
            else
            {
                throw new Exception(ClassName + " Not found");
            }
        }
    }
}
