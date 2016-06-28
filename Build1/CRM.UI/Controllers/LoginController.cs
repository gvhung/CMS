using CRM.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel lgn)
        {
            var UserName = lgn.Email;
            var Pswd = lgn.Password;
            Session["User"] = UserName;
            if (UserName == "venkat.5160@gmail.com" && Pswd == "venky80088")
            {
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }
    }
}