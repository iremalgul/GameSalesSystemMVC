using GameSalesSystemMVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameSalesSystemMVC.Filters
{
    public class IsLogin: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["user"] == null)
            {
                var userName = CookieHelper.GetCookie(filterContext.HttpContext.Request, Constants.COOKIE_USERNAME);
                var passwor = CookieHelper.GetCookie(filterContext.HttpContext.Request, Constants.COOKIE_PASSWORD);

                if (userName == null || passwor == null)
                {
                    filterContext.Result = new RedirectResult("~/Auth/Login");
                  
                }
                else
                {
                    bool isLogin = CustomHelpers.UserLogin(userName, passwor);
                    if (isLogin)
                    {
                        base.OnActionExecuting(filterContext);
                       
                    }
                    else
                    {
                        filterContext.Result = new RedirectResult("~/Auth/Login");
                    }
                }

            }
            base.OnActionExecuting(filterContext);
        }



    }
}