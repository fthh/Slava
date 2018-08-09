using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPostService : IServiceBase<DAL.Entities.Post>
    {
        void newPost(DAL.Entities.Post entity, DAL.Entities.User author);
        DAL.Entities.Post GetPostById(Guid Id);
    }
}
