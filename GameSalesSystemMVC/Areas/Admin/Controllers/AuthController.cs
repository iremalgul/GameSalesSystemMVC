using GameSalesSystemMVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameSalesSystemMVC.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        // GET: Admin/Auth
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult CheckAdmin(string Username, string Password, string remember)
        {

            if (CustomHelpers.AdminLogin(Username, Password))
            {
                if (remember == "on")
                {
                    CookieHelper.CreateCookie(this.Response, Constants.COOKIE_USERNAME, Username);
                    CookieHelper.CreateCookie(this.Response, Constants.COOKIE_PASSWORD, Password);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Login");
            }


        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            CookieHelper.DeleteCookie(this.Response, this.Request, Constants.COOKIE_USERNAME);
            CookieHelper.DeleteCookie(this.Response, this.Request, Constants.COOKIE_PASSWORD);
            return RedirectToAction("Index", "Home");
        }

    }
}