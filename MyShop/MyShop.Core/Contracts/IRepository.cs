using System.Linq;
using MyShop.Core.Models;

namespace MyShop.Core.Contracts
{
    public interface IRepository<N> where N : BaseEntity
    {
        IQueryable<N> Collection();
        void Commit();
        void Delete(string Id);
        N Find(string Id);
        void Insert(N n);
        void Update(N n);
    }
}