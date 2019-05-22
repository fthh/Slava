using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DTO;
using BLL.Interfaces;

namespace BLL
{
    public class ServiceBase<T> : IServiceBase<T> where T : Entity
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
            _unitOfWork.GetRepository<T>().Delete(entity);
            _unitOfWork.Commit();
        }

        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<T>().Delete(id);
            _unitOfWork.Commit();
        }

        public ICollection<T> GetAll()
        {
            return _unitOfWork.GetRepository<T>().GetAll().ToList();
        }

        public T GetById(Guid id)
        {
            return _unitOfWork.GetRepository<T>().GetById(id);
        }

        public void Update(T entity)
        {
            _unitOfWork.GetRepository<T>().Update(entity);
            _unitOfWork.Commit();
        }
    }
}
