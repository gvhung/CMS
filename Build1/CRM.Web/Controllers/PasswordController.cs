using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Web.Models;
using CRM.Model;
using BotDetect.Web.Mvc;
using CRM.Tickets;
using CRM.Tickets.Interfaces;
using CRM.Store;
namespace CRM.Web.Controllers
{
    public class PasswordController : Controller
    {
        //
        // GET: /Password/
        [HttpGet]
        public ActionResult Reset()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [CaptchaValidation("SecurityCode", "Venkanna", "Incorrect CAPTCHA code!")]
        public ActionResult Reset(ForgotPasswordModel m)
        {
            if (ModelState.IsValid)
            {
                try {
                    UserManager<CRMUser> userManger = new UserManager<CRMUser>(new UserStore<CRMUser>(new CRMContext("CRMContext")));
                    CRMUser user = userManger.GetUser(m.EmailAddress);
                    if (user == null)
                        ModelState.AddModelError("UD", "Email Address does not exist in our database");
                    else
                        ModelState.AddModelError("UD", "Dear "+ user.FirstName + user.LastName +", please click on rest link sent to your email id.");               }
                catch(Exception ex)
                {
                    ModelState.AddModelError("UD", ex.Message);
                }
            }
                

            return View(m);
        }
    }
}
