using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {       
        public ActionResult Index()
        {
            ViewBag.UserName = User.Identity.Name.Substring(0, User.Identity.Name.IndexOf("@"));
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