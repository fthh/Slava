using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Autofac;
using DTO;
using BLL.Interfaces;

namespace BLL
{
    public class ProjectService : ServiceBase<Project>, IProjectService
    {
        private IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteProject(Project entity)
        {
            base.Delete(entity);
        }

        public void DeleteProject(Guid id)
        {
            base.Delete(id);
        }

        public void DeleteUserFromProjects(Guid idProject, Guid idUser)
        {
            var project = GetById(idProject);
            var user = project.Workers.FirstOrDefault(c => c.Id == idUser);
            project.Workers.Remove(user);
            _unitOfWork.Commit();
        }

        public void AddUserToProject(Project project, User user)
        {
            project.Workers.Add(user);
            user.Projects.Add(project);
            _unitOfWork.Commit();
        }

        public Project GetProjectById(Guid id)
        {
            return base.GetById(id);
        }

        public void NewProject(Project entity)
        {
            base.Create(entity);
        }

        public void UpdateProject(Project entity)
        {
            base.Update(entity);
        }

    }
}
