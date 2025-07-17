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
    [IsLogin]
    public class CartController : Controller
    {
        // GET: Cart
        private readonly ICartService _cartService;
        private readonly IUserService _userService;
        private readonly IGameService _gameService;

        public CartController(ICartService CartService, IUserService UserService, IGameService GameService)
        {
            _cartService = CartService;
            _userService = UserService;
            _gameService = GameService;

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToCart(int id)
        {
            var game_id = id;
            var user = _userService.GetUserFromSession();
            var result =  _cartService.AddCartGame(game_id, user.Id);


            var game_amount = _gameService.GetGameById(game_id).Price;
            var cartDto = _cartService.GetUserCart(user.Id);
            cartDto.TotalCost += game_amount;
            _cartService.UpdateCart(cartDto);
            if (result)
                return RedirectToAction("Index","Game");   
            else return Json(new JsonModel(false, "Game couldnt added to cart"), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowUserCart()
        {
            var user = _userService.GetUserFromSession();
            var cartgames = _cartService.GetUserCartGames(user.Id);
            return View(cartgames);
        }

        public ActionResult DeleteCartGame(int id)
        {
            var user = _userService.GetUserFromSession();
            var cartDto = _cartService.GetUserCart(user.Id);
            var cartgame = _cartService.GetCartGame(id);
            var result = _cartService.DeleteCartGame(id);
            if (result)
            {
                cartDto.TotalCost -= cartgame.Game.Price;
                _cartService.UpdateCart(cartDto);
                return RedirectToAction("ShowUserCart", "Cart");
            }
              
            else return Json(new JsonModel(false, "Game couldnt added to cart"), JsonRequestBehavior.AllowGet);
        }
    }
}