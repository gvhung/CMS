using CRM.Business;
using CRM.Model;
using CRM.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.UI.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserProfileViewModel u)
        {
            CRMUser user = new CRMUser();
            user.CompanyId = u.CompanyId;
            user.FirstName = u.FirstName;
            user.LastName = u.LastName;
            user.Password = u.Password;
            user.Username = u.Username;
            user.UserType = u.UserType;
            UserProfileBiz userProfile = new UserProfileBiz();
                userProfile.Create(user);
            return View();
        }

    }
}