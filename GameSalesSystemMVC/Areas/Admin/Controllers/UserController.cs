using GameSalesSystemMVC.Dtos;
using GameSalesSystemMVC.Filters;
using GameSalesSystemMVC.Models;
using GameSalesSystemMVC.Services;
using GameSalesSystemMVC.Services.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameSalesSystemMVC.Areas.Admin.Controllers
{
    [IsAdmin]
    public class UserController : Controller
    {
        // GET: Admin/User
        private readonly IUserService _userService;
        private readonly ICartService _cartService;

        public UserController(IUserService userService, ICartService cartService)
        {
            _userService = userService;
            _cartService = cartService;
        }
        public ActionResult Index()
        {
            return View(_userService.GetUsers());
        }
        public ActionResult IndexPartialTable()
        {
            return PartialView(_userService.GetUsers());
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult InsertUser(UserDto userDto)
        {
            var userId = _userService.InsertUser(userDto);
            var result= _cartService.InsertCart(userId);    
            if (userId > 0)
                return Json(new JsonModel(true, "New User Added"), JsonRequestBehavior.AllowGet);
            else return Json(new JsonModel(false, "New User Couldn't Add"), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            var user= _userService.GetUserById(id);
            return View(user);
        }

        public ActionResult UpdateUser(UserDto userDto)
        {
            var result = _userService.UpdateUser(userDto);
            if (result)
                return Json(new JsonModel(true, "User Updated"), JsonRequestBehavior.AllowGet);
            else return Json(new JsonModel(false, "User Couldn't Updated"), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteUser(int Id) 
        {
            _cartService.DeleteCart(Id);
            var result = _userService.DeleteUser(Id);
            if (result)
                return Json(new JsonModel(true, "User Deleted"), JsonRequestBehavior.AllowGet);
            else return Json(new JsonModel(false, "User Couldn't Deleted"), JsonRequestBehavior.AllowGet);
        }
    }
}