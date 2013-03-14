using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XavierSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Xavier's blog";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hi my friend, my name is Xavier, a C# programmer in Brisbane Australia";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My Email is ";

            return View();
        }
    }
}
