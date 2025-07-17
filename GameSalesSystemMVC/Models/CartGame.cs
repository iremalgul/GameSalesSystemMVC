using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.Models
{
    public class CartGame
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int GameId { get; set; }


        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }
    }
}