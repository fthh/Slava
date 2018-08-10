using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IProjectService : IServiceBase<Project>
    {
        void NewProject(Project entity);
        void UpdateProject(Project entity);
        void DeleteProject(Project entity);
        void DeleteProject(Guid id);
        Project GetProjectById(Guid id);
    }
}
