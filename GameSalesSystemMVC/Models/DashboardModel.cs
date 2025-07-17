using GameSalesSystemMVC.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.Models
{
    public class DashboardModel
    {
        public decimal EarningsMonthly;
        public decimal EarningsAnnual;
        public List<PurchaseGameDto> PurchaseGames;


    }
}