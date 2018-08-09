using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;


namespace Organizer.MVC.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IUserService userService)
        {
            var qq = userService.GetAll().ToList()[0];
            System.Diagnostics.Debug.WriteLine(qq.Login);
        }

        public ActionResult Index()
        {
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