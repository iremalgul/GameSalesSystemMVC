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
    public class CartController : Controller
    {
        // GET: Admin/Cart
        private readonly ICartService _CartService;

        public CartController(ICartService CartService)
        {
            _CartService = CartService;
        }
        public ActionResult ShowUserCart(int id)
        {
            var cart = _CartService.GetUserCart(id);
            var cartgames = _CartService.GetUserCartGames(id);
            return View(cartgames);
        }

       
    }
}