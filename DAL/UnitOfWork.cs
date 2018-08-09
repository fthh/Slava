using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context _context;
        private List<object> _repositories = new List<object>();
        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public IRepository<T> GetRepository<T>() where T : DAL.Entities.Entity
        {
            var repo = (IRepository<T>)_repositories.SingleOrDefault(r => r is IRepository<T>);
            if (repo == null)
            {
                _repositories.Add(repo = new Repository<T>(_context));
            }
            return repo;
        }
    }
}
