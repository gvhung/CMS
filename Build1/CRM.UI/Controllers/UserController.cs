using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using CRM.Business;
using CRM.UI.ViewModels;

namespace CRM.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register()
        {
            return View();
        }
       
        public JsonResult IsEmailIdExists(string emailId)
        {
            UserBiz userBiz = new UserBiz();
            return Json(userBiz.IsEmailIdExists(emailId)?"Email Address already exists":"Email Address available", JsonRequestBehavior.AllowGet);
        }

        public ActionResult ActivateUser(Guid uid)
        {
            return View();
        }

    }
        
}