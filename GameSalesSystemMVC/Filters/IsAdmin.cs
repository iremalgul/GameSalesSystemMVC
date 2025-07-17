using GameSalesSystemMVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameSalesSystemMVC.Filters
{
    public class IsAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var userName = CookieHelper.GetCookie(filterContext.HttpContext.Request, Constants.COOKIE_USERNAME);
            var password = CookieHelper.GetCookie(filterContext.HttpContext.Request, Constants.COOKIE_PASSWORD);

            if (userName == null || password == null)
            {
                filterContext.Result = new RedirectResult("~/Admin/Auth/Login");
                return;
            }
            else
            {
                bool isLogin = CustomHelpers.AdminLogin(userName, password);
                if (isLogin)
                {
                    base.OnActionExecuting(filterContext);
                    return;
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Admin/Auth/Login");
                    return;
                }
            }

        }
    }
}