using AuthenticationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationDemo.Controllers
{
    public class HomeController : Controller
    {
        AuthenticationEntities db = new AuthenticationEntities();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult UserList()
        {
            var user = db.Users.ToList();
            return View(user);
        }

        [Authorize(Roles = "Customer")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Customer")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}