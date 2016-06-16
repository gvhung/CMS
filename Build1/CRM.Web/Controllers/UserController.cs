using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Tickets;
using CRM.Store.Entities;
using CRM.Model;
using CRM.Store;

namespace CRM.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Activate(Guid id)
        {
             
            UserManager<CRMUser> userManager = new UserManager<CRMUser>(new UserStore<CRMUser>());
            userManager.UserActivate(id);
            //code for updating status of user from 0 to 1
            return View();
        }
    }
}