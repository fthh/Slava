using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Guid Add(TEntity entity);
        void Delete(TEntity entity);
        void Delete(Guid entity);
        void Update(TEntity entity);
        TEntity GetById(Guid id);
    }
}
