using GameSalesSystemMVC.Dtos;
using GameSalesSystemMVC.Filters;
using GameSalesSystemMVC.Models;
using GameSalesSystemMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameSalesSystemMVC.Controllers
{
  
    public class UserController : Controller
    {
        // GET: User
        private readonly IUserService _userService;

        private readonly ICartService _cartService;
        public UserController(IUserService userService, ICartService cartService)
        {
            _userService = userService;
            _cartService = cartService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InsertUser(UserDto userDto)
        {
            var userId = _userService.InsertUser(userDto);
            var result = _cartService.InsertCart(userId);
            if (userId > 0)
                return Json(new JsonModel(true, "New User Added"), JsonRequestBehavior.AllowGet);
            else return Json(new JsonModel(false, "New User Couldn't Add"), JsonRequestBehavior.AllowGet);
        }
    }
}