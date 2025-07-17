using GameSalesSystemMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.Dtos
{
    public class PurchaseGameDto
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int Count { get; set; }
        public decimal GameAmount { get; set; }
        public int GameId { get; set; }

     
        public virtual GameDto Game { get; set; }
     
        public virtual PurchaseDto Purchase { get; set; }
    }
}