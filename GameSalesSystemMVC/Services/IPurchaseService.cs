using GameSalesSystemMVC.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSalesSystemMVC.Services
{
    public interface IPurchaseService
    {
        List<PurchaseDto> GetUserPurchases(int userId);
        List<PurchaseGameDto> GetPurchaseGames(int purchaseId);
        List<PurchaseGameDto> GetAllPurchaseGames();

        Decimal GetPurchasesMonthly();
        Decimal GetPurchasesAnnual();

        bool InsertPurchase(int userId,List<CartGameDto> cartGames);

        PurchaseDto GetPurchaseLast();
    }
}
