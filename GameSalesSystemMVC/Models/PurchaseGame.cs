using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.Models
{
    public class PurchaseGame
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        
        public decimal GameAmount { get; set; }
        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
        [ForeignKey("PurchaseId")]
        public virtual Purchase Purchase { get; set; }
    }
}