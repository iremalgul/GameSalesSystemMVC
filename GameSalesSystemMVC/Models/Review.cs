using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.Models
{
    public class Review
    {
        public int Id { get; set; }
        public DateTime ReviewDate { get; set;}
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }


        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }


    

    }
}