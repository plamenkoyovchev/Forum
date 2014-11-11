using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Common.Repository
{
    public interface IRepository<T>:IDisposable where T: class
    {
        IQueryable<T> All();

        T GetById(long id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(long id);

        void Detach(T entity);

        int SaveChanges();
    }
}
