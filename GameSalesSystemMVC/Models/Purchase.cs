using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.Models
{
    public class Purchase
    {
        public Purchase() 
        {
            this.PurchaseGames = new HashSet<PurchaseGame>();
        }
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseAmount { get; set; }

        public int UserId { get; set; }


        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<PurchaseGame> PurchaseGames { get; set; }









    }
}