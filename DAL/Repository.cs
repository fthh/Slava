using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interfaces;
using DAL.Entities;

namespace DAL
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity : Entity
    {
        private DbContext _dbContext;
        private DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public Guid Add(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            _dbSet.Add(entity);
            return entity.Id;
        }

        public void Delete(TEntity entity)
        {
            var dbEntityEntry = _dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
        }

        public void Delete(Guid id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
                Delete(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            var dbEntityEntry = _dbContext.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
    }
}
