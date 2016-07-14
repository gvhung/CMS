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
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

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
            catch (Exception ex)
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
                user.Password = u.Password;
                user.Username = u.EmailId;
                user.CompanyName = u.CompanyName;
                user.CompanyId = 0;
                string guid = userBiz.RegisterUser(user);
                //string CurrentURL = Request.Url.AbsoluteUri;
                string Msg = "Dear Customer,<br/><br/> Thank you for Registring with us<br/>" +
                "Plese Click below link for Activation<br/><br/>" +
                "<a href='http://localhost:53581/User/Activate?id=" + guid +
                "' > http://localhost:53581/User/Activate?id=" + guid + "</a><br/><br />" +
                "Thanks and Regards<br/>CRM Admin";
                EmailUtilty.SendEmail(user.Username, "ajnasystemshyd@gmail.com", "Company Registration", Msg, true);
                ViewBag.Message = "Succefully Registered";
                return View("RegisterSuccess");
            }
            catch (Exception Ex)
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
            try
            {

                UserBiz userBiz = new UserBiz();
                userBiz.Activate(Id);
                return RedirectToAction("Login", "User");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("IV", ex.Message);
                return View("Error");
            }
        }

        // GET: Login
        public ActionResult Login()
        {
            LoginViewModel m = new LoginViewModel();
            if (Request.Cookies["userinfo"]!=null)
            {
                m.Email = Request.Cookies["userinfo"].Values["username"];
                m.Password = Request.Cookies["userinfo"].Values["password"];
            }
            return View(m);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel m)
        {
            try
            {

                long uid;
                long companyId;
                UserBiz userbiz = new UserBiz();
                bool Status = userbiz.Login(m.Email, m.Password, out uid, out companyId );

                if (Status == true)
                {
                    if (m.RememberMe)
                    {
                        HttpCookie c = new HttpCookie("userinfo");
                        c.Values.Add("Username", m.Email);
                        c.Values.Add("password", m.Password);
                        c.Expires.AddDays(7);
                        Response.Cookies.Add(c);
                    }
                    Session["UID"] = uid;
                    Session["CompanyId"] = companyId;
                    var ident = new ClaimsIdentity(
                          new[] { 
                                  // adding following 2 claim just for supporting default antiforgery provider
                                  new Claim(ClaimTypes.NameIdentifier, m.Email),
                                  new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),

                                  new Claim(ClaimTypes.Name,m.Email),

                                  // optionally you could add roles if any
                                  new Claim(ClaimTypes.Role, "RoleName"),
                                  new Claim(ClaimTypes.Role, "AnotherRole"),

                          },
                          DefaultAuthenticationTypes.ApplicationCookie);

                    HttpContext.GetOwinContext().Authentication.SignIn(
                       new AuthenticationProperties { IsPersistent = false }, ident);
                    return RedirectToAction("MyProfile");
                }
                else
                {

                    ModelState.AddModelError("UVE", "Invalid username or pasword");
                    m.Password = "";
                    return View(m);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UVE", ex.Message);
                m.Password = "";
                return View(m);
            }
        }

        public ActionResult MyProfile()
        {
            UserProfileViewModel myProfile = new UserProfileViewModel();
            //get user profile inromation from database if user is logged in
            if (Session["UID"] != null)
            {
                var id = Session["UID"];
                //get information from db
                long UID = Convert.ToInt64(id);
                UserBiz getUser = new UserBiz();
                CRMUser crmUser = new CRMUser();
                crmUser = getUser.GetUserProfile(UID);
                myProfile.CompanyName = crmUser.CompanyName;
                myProfile.Password = crmUser.Password;
                myProfile.Username = crmUser.Username;
                myProfile.FirstName = crmUser.FirstName;
                myProfile.LastName = crmUser.LastName;

                return View(myProfile);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        [HttpPost]
        public ActionResult MyProfile(UserProfileViewModel profile)
        {
            CRMUser userProfile = new CRMUser();
            //var id = Session["UID"];
            userProfile.UID = Convert.ToInt64(Session["UID"]);
            userProfile.FirstName = profile.FirstName;
            userProfile.LastName = profile.LastName;
            userProfile.CompanyName = profile.CompanyName;
            userProfile.Password = profile.Password;
            userProfile.Username = profile.Username;
            //userProfile.UserType = profile.UserType;
            UserBiz userprofilebiz = new UserBiz();
            userprofilebiz.UpdateUserProfile(userProfile);
            ModelState.AddModelError("UPD", "Your Profile is Successfully Updated");
            return View();



        }
    }
}