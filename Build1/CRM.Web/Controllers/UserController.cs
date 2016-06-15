using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Activate(int id)
        {

            //code for updating status of user from 0 to 1
            return View();
        }
    }
}