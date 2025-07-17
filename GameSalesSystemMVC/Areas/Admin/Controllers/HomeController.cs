using GameSalesSystemMVC.Filters;
using GameSalesSystemMVC.Models;
using GameSalesSystemMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameSalesSystemMVC.Areas.Admin.Controllers
{
    [IsAdmin]
    public class HomeController : Controller
    {
        // GET: Admin/Home

        private readonly IPurchaseService _purchaseService;

        public HomeController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        public ActionResult Index()
        {
            DashboardModel dashboardModel = new DashboardModel
            {
                EarningsMonthly = _purchaseService.GetPurchasesMonthly(),
                EarningsAnnual = _purchaseService.GetPurchasesAnnual(),
                PurchaseGames = _purchaseService.GetAllPurchaseGames()
            };

            return View(dashboardModel);
        }
    }
}