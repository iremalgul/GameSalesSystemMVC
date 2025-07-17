using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace GameSalesSystemMVC.Models
{
    public class Game
    {
        public Game()
        {
            this.Reviews = new HashSet<Review>();
            this.PurchaseGames = new HashSet<PurchaseGame>();
            this.CartGames = new HashSet<CartGame>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<PurchaseGame> PurchaseGames { get; set; }
        public virtual ICollection<CartGame> CartGames { get; set; }



    }
}