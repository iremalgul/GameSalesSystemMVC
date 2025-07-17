using GameSalesSystemMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.Dtos
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }



        public virtual UserDto User { get; set; }
      
        public virtual GameDto Game { get; set; }
    }
}