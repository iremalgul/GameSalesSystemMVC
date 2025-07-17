using GameSalesSystemMVC.Filters;
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
    public class PurchaseController : Controller
    {
        // GET: Admin/Purchase
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowUserPurchases(int id)
        {
            var purchase = _purchaseService.GetUserPurchases(id);
            return View(purchase);
        }
        public ActionResult Details(int id)
        {
            var purchasegames = _purchaseService.GetPurchaseGames(id);
            return View(purchasegames);
        }
    }
}