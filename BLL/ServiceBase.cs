using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace BLL
{
    public class ServiceBase<T> : BLL.Interfaces.IServiceBase<T> where T : DAL.Entities.Entity
    {
        private IUnitOfWork _unitOfWork;

        public ServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(T entity)
        {
            _unitOfWork.GetRepository<T>().Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(T entity)
        { 
        }

        public void Delete(Guid id)
        {
        }

        public ICollection<T> GetAll()
        {
            return _unitOfWork.GetRepository<T>().GetAll().ToList();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
        }
    }
}
