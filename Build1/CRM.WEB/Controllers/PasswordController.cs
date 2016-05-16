using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.UI.Models;
using BotDetect.Web.Mvc;
namespace CRM.UI.Controllers
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

            return View(m);
        }
    }
}
