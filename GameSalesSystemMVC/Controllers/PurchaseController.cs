using GameSalesSystemMVC.Filters;
using GameSalesSystemMVC.Models;
using GameSalesSystemMVC.Services;
using GameSalesSystemMVC.Services.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameSalesSystemMVC.Controllers
{
    [IsLogin]
    public class PurchaseController : Controller
    {

        private readonly IPurchaseService _purchaseService;
        private readonly IUserService _userService;
        private readonly IGameService _gameService;
        private readonly ICartService _cartService;

        public PurchaseController(IPurchaseService PurchaseService, IUserService UserService, IGameService GameService, ICartService cartService)
        {
            _purchaseService = PurchaseService;
            _userService = UserService;
            _gameService = GameService;
            _cartService = cartService;
        }
        // GET: Purchase
        public ActionResult Checkout()
        {
            var user = _userService.GetUserFromSession();
            var cartgames = _cartService.GetUserCartGames(user.Id);
            return View(cartgames);
        }

        public ActionResult AddPurchase()
        {
            var userId = _userService.GetUserFromSession().Id;
            var cartgames = _cartService.GetUserCartGames(userId);
            var result = _purchaseService.InsertPurchase(userId, cartgames);
            if (result)
                return RedirectToAction("OrderSuccess");
            else return Json(new JsonModel(false, "Purchase couldnt add"), JsonRequestBehavior.AllowGet);
        }

        public ActionResult OrderSuccess()
        {
            var last_purchase = _purchaseService.GetPurchaseLast();
            var purchasegames = _purchaseService.GetPurchaseGames(last_purchase.Id);
            return View(purchasegames);  
        }

    }
}