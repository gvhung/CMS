using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using CRM.Business;
using CRM.UI.ViewModels;
using CRM.Model;
using Utility;
using System.Net;

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
            try
            {
                UserBiz userBiz = new UserBiz();
                return Json(new { Status = userBiz.IsEmailIdExists(emailId) }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { Message = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }


        [HttpPost]
        public ActionResult Register(UserRegisterVM u)
        {
            try
            {
                ///creating company
                
                UserBiz userBiz = new UserBiz();
                

                /// creating user
                CRMUser user = new CRMUser();

                //user.FirstName = u.FirstName;
                //user.LastName = u.LastName;
                user.Password = u.Password;
                user.Username = u.EmailId;
                user.CompanyName = u.CompanyName;


                user.CompanyId = 0;
               string guid= userBiz.RegisterUser (user);
                


                //string CurrentURL = Request.Url.AbsoluteUri;
                string Msg = "Dear Customer,<br/><br/> Thank you for Registring with us<br/>" +
                "Plese Click below link for Activation<br/><br/>" +
                "<a href='http://localhost:53581/User/Activate?id=" + guid +
                 "' > http://localhost:53581/User/Activate?id=" + guid + "</a><br/><br />" +
                 "Thanks and Regards<br/>CRM Admin";
                //string Msg = "Dear Customer,<br/><br/> Thank you for Registring with us<br/>" +
                //"Plese Click below link for Activation<br/><br/>" + CurrentURL + "/" + res + "<br/>< br /> " +
                // "Thanks and Regards<br/>CRM Admin";
                //EmailUtilty.SendEmail(user.Username, "ajnasystemshyd@gmail.com", "Company Registration", Msg, true);
                //Temparary.sendMail(user.Username, "ajnasystemshyd@gmail.com", "Company Registration", Msg, true);


                return View();
            }
            catch(Exception Ex)
            {
                ModelState.AddModelError("VE", Ex.Message);
                return View(u);
            }
        }


        public ActionResult Create(UserProfileViewModel u)
        {
            return View();
        }


        public ActionResult Activate(string Id)
        {
            UserBiz userBiz = new UserBiz();
            userBiz.Activate(Id);
            return RedirectToAction("Login", "Login");
        }

    }

}