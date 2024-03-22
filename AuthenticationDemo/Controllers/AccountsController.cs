using AuthenticationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthenticationDemo.Controllers
{
    public class AccountsController : Controller
    {
        AuthenticationEntities db = new AuthenticationEntities();

        // GET: Accounts
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User u)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(u);
                if(db.SaveChanges() > 0)
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User u, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(x => x.Username == u.Username && x.Password == u.Password).FirstOrDefault();
                if(user != null)
                {
                    FormsAuthentication.SetAuthCookie(u.Username, false);
                    Session["username"] = u.Username.ToString();
                    if(ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["username"] = null;
            return RedirectToAction("Login");
        }
    }
}