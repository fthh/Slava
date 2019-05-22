using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using DTO;
using System.Web.Services;
using System.Web.Script.Services;
using WebGrease.Css.Extensions;
using System.Text;

namespace Organizer.MVC.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        private IProjectService _projectService;

        public HomeController(IUserService userService, IProjectService projectService)
        {
            _userService = userService;
            _projectService = projectService;
        }

        public ActionResult Index()
        {
            var users = _userService
                .GetAll()
                .OrderBy(x => x.FirstName)
                .ToList();

            var projects = _projectService
                .GetAll()
                .OrderBy(x => x.Priority)
                .ToList();

            ViewData["users"] = users;
            ViewData["projects"] = projects;
            return View(users);
        }

        public ActionResult Project(Guid id)
        {
            var project = _projectService.GetById(id);
            ViewData["project"] = project;
            return View();
        }

        public ActionResult ProjectEdit(Guid id)
        {
            var project = _projectService.GetById(id);
            ViewData["project"] = project;
            return View();
        }

        [HttpPost]
        public string GetUsers(string str)
        {
            if (!Request.IsAjaxRequest()) return null;
            if (str.Length == 0)
            {
                var users = _userService.GetAll().Take(10);
                var request = new StringBuilder();
                users.ForEach
                    (
                        c => request.Append
                        (
                            "<li>" + c.FirstName + " " + c.LastName + " " + c.MiddleName + " *" + c.Id + "</li>"
                        )
                    );
                return request.ToString();
            }else{
                var users = _userService.GetAll().ToList().Where(c =>
                {
                    if (c.FirstName.ToLower().Contains(str.ToLower()) || c.LastName.ToLower().Contains(str.ToLower()) || c.MiddleName.ToLower().Contains(str.ToLower()))
                        return true;
                    return false;
                });
                var request = new StringBuilder();
                users.Take(10).ForEach(c => request.Append("<li>" + c.FirstName + " " + c.LastName + " " + c.MiddleName + " *" + c.Id + "</li>"));
                return request.ToString();
            }
        }

        public string GetProjects(string str)
        {
            if (!Request.IsAjaxRequest()) return null;
            if (str.Length == 0)
            {
                var projects = _projectService.GetAll().Take(10);
                var request = new StringBuilder();
                projects.ForEach
                    (
                        c => request.Append
                        (
                            "<li>" + c.Title + " " + c.Id + "</li>"
                        )
                    );
                return request.ToString();
            }else{
                var projects = _projectService.GetAll().ToList().Where(c =>
                {
                    if (c.Title.ToLower().Contains(str.ToLower()) || c.Text.ToLower().Contains(str.ToLower()))
                        return true;
                    return false;
                });
                var request = new StringBuilder();
                projects.Take(10).ForEach(c => request.Append("<li>" + c.Title + " " + c.Id + "</li>"));
                return request.ToString();
            }
        }

        [HttpPost]
        public ActionResult ProjectEdit(Guid id, [Bind(Include = "Title,Priority,Text,Performer,Customer,CreatedAt,CompletedAt")] Project project)
        {
            
            var projectById = _projectService.GetById(id);
            projectById.Title = project.Title;
            projectById.Priority = project.Priority;
            projectById.Text = project.Text;
            projectById.Performer = project.Performer;
            projectById.Customer = project.Customer;

            _projectService.UpdateProject(projectById);

            ViewData["project"] = projectById;
            return View();
        }

        public ActionResult ProjectDelete(Guid id)
        {
            _projectService.DeleteProject(id);
            return Redirect("/");
        }

        public ActionResult UserDelete(Guid id)
        {
            _userService.DeleteUser(id);
            return Redirect("/");
        }

        public ActionResult ProjectCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProjectCreate([Bind(Include = "Title,Priority,Text,Performer,Customer,CreatedAt,CompletedAt")] Project project)
        {
            _projectService.NewProject(project);
            return View("");
        }

        public ActionResult DeleteProjectUser(Guid idProject, Guid idUser)
        {
            _projectService.DeleteUserFromProjects(idProject, idUser);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult AddProjectPM(Guid idProject, Guid idPm)
        {
            _projectService.AddProjectManager(idProject, idPm);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult AddProjectUser(Guid idProject, Guid idUser)
        {
            _projectService.AddUserToProject(idProject, idUser);
            return Redirect(Request.UrlReferrer.ToString());
        }


        public ActionResult User(Guid id)
        {
            var user = _userService.GetById(id);
            ViewData["user"] = user;
            return View();
        }

        public ActionResult UserEdit(Guid id)
        {
            var user = _userService.GetById(id);
            ViewData["user"] = user;
            return View();
        }

        [HttpPost]
        public ActionResult UserEdit(Guid id, [Bind(Include = "FirstName,LastName,MiddleName,Email")] User user)
        {
            var userById = _userService.GetById(id);
            userById.FirstName = user.FirstName;
            userById.LastName = user.LastName;
            userById.MiddleName = user.MiddleName;
            userById.Email = user.Email;

            _userService.UpdateUser(userById);

            ViewData["user"] = userById;
            return View();
        }

        public ActionResult UserCreate()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult UserCreate([Bind(Include = "FirstName,LastName,MiddleName,Email")] User user)
        {
            _userService.NewUser(user);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}