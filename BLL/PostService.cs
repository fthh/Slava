using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Autofac;
using DAL.Entities;

namespace BLL
{
    public class PostService : ServiceBase<DAL.Entities.Post>, BLL.Interfaces.IPostService
    {
        private IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Post GetPostById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void newPost(Post entity, User author)
        {
            throw new NotImplementedException();
        }
    }
}
