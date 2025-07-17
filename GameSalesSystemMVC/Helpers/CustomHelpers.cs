using GameSalesSystemMVC.Contexts;
using GameSalesSystemMVC.Models;
using GameSalesSystemMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameSalesSystemMVC.Helpers
{
    public static class CustomHelpers
    {
        public static string GetUserName(this HtmlHelper helper)
        {
            if ((User)HttpContext.Current.Session["user"] != null)
                return ((User)HttpContext.Current.Session["user"]).NameSurname;
            else return "";
        }
        public static int GetUserId(this HtmlHelper helper)
        {
            return ((User)HttpContext.Current.Session["user"]).Id;
        }

        public static bool AdminLogin(string Username, string Password)
        {
            GameSalesContext context = new GameSalesContext();
            var admin = context.Users.FirstOrDefault(x => x.Id == 4);

            if (admin != null)
            {
                if (admin.Username == Username && admin.Password == Password)
                {
                    HttpContext.Current.Session["user"] = admin;
                    return true;  // Successful login
                }
                else
                {
                    return false; // Incorrect username or password
                }
            }
            else
            {
                return false; // Admin not found
            }
        }


        public static bool UserLogin(string username, string password)
        {
            GameSalesContext context = new GameSalesContext();
            var user = context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (user != null)
            {
                HttpContext.Current.Session["user"] = user;

                return true;
            }
            else
            {
                return false;
            }

        }
    }
}