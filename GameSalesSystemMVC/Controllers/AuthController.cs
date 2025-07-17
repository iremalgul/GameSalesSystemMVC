using GameSalesSystemMVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameSalesSystemMVC.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
        public ActionResult CheckUser(string Username, string Password, string Remember)
        {
            if (CustomHelpers.UserLogin(Username, Password))
            {
                if (Remember == "on")
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