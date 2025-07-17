using AutoMapper;
using GameSalesSystemMVC.Contexts;
using GameSalesSystemMVC.Dtos;
using GameSalesSystemMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.Services.Implements
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IRepository<Purchase> _purchaserepository;
        private readonly IRepository<PurchaseGame> _purchasegamerepository;

        public PurchaseService(IRepository<Purchase> purchaserepository, IRepository<PurchaseGame> purchasegamerepository)
        {
            _purchaserepository = purchaserepository;
            _purchasegamerepository = purchasegamerepository;
        }
        public List<PurchaseDto> GetUserPurchases(int userId)
        {
            var allPurchases = _purchaserepository.Table;
            var purchases = allPurchases.Where(x => x.UserId == userId);
            var purchasesDto = Mapper.Map<List<PurchaseDto>>(purchases);
            return purchasesDto;
        }
        public List<PurchaseGameDto> GetPurchaseGames(int purchaseId)
        {
            var allPurchaseGames = _purchasegamerepository.Table;
            var purchaseGames = allPurchaseGames.Where(x => x.PurchaseId == purchaseId);
            var purchaseGamesDto = Mapper.Map<List<PurchaseGameDto>>(purchaseGames);
            return purchaseGamesDto;
        }

        public decimal GetPurchasesMonthly()
        {
            try
            {
                decimal monthlySum = _purchaserepository.Table
                .Where(x => x.PurchaseDate.Month == DateTime.Now.Month && x.PurchaseDate.Year == DateTime.Now.Year)
                 .Sum(x => x.PurchaseAmount);

                return monthlySum;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public decimal GetPurchasesAnnual()
        {
            try
            {
                decimal annualSum = _purchaserepository.Table
                .Where(x => x.PurchaseDate.Year == DateTime.Now.Year)
                .Sum(x => x.PurchaseAmount);

                return annualSum;
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public List<PurchaseGameDto> GetAllPurchaseGames()
        {
            var allPurchases = _purchasegamerepository.Table;
            var allPurchasesDto = Mapper.Map<List<PurchaseGameDto>>(allPurchases);
            return allPurchasesDto;

        }

        public bool InsertPurchase(int userId, List<CartGameDto> cartGames)
        {
            decimal cartTotal = cartGames[0].Cart.TotalCost;
            try
            {
                PurchaseDto purchaseDto = new PurchaseDto()
                {
                    UserId = userId,
                    PurchaseDate = DateTime.Now,
                    PurchaseAmount = cartTotal
                };
                var purchase = Mapper.Map<Purchase>(purchaseDto);
                var result= _purchaserepository.Insert(purchase);

                foreach (var cartgame in cartGames)
                {
                    PurchaseGameDto purchaseGameDto = new PurchaseGameDto()
                    {
                        PurchaseId = purchase.Id,
                        GameId = cartgame.Game.Id,
                        GameAmount = cartgame.Game.Price
                    };
                    var purchaseGame = Mapper.Map<PurchaseGame>(purchaseGameDto);
                    var result2 = _purchasegamerepository.Insert(purchaseGame);
                }
               
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PurchaseDto GetPurchaseLast()
        {
            var purchase = _purchaserepository.Table
                                     .OrderByDescending(p => p.Id)
                                     .FirstOrDefault();
           
         
            var purchaseDto = Mapper.Map<PurchaseDto>(purchase);
            return purchaseDto;
        }
    }
}