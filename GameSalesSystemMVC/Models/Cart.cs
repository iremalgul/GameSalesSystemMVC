using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.Models
{
    public class Cart
    {
        public Cart() 
        { 
            this.CartGames = new HashSet<CartGame>();
        }
        [ForeignKey("User")]
        public int Id { get; set; }
        public decimal TotalCost { get; set; }


        public virtual User User { get; set; }

        public virtual ICollection<CartGame> CartGames { get; set; }
    }

   
}