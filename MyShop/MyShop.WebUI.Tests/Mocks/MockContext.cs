using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.WebUI.Tests.Mocks
{
    public class MockContext<N> : IRepository<N> where N: BaseEntity
    {
        List<N> items;
        string className;

        public MockContext()
        {
            items = new List<N>();
        }

        public void Commit()
        {
            return; 
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
                throw new Exception(className + " Not found");
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
                throw new Exception(className + " Not found");
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
                throw new Exception(className + " Not found");
            }
        }
    }
}
