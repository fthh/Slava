using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL.Interfaces
{
    public interface IServiceBase<T> where T : Entity
    {
        void Create(T entity);
        T GetById(Guid id);
        ICollection<T> GetAll();
        void Delete(T entity);
        void Delete(Guid id);
        void Update(T entity);
    }
}
