using GameSalesSystemMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.Dtos
{
    public class CartGameDto
    {

        public int Id { get; set; }
        public int CartId { get; set; }
        public int GameId { get; set; }


        
        public virtual GameDto Game { get; set; }
        
        public virtual CartDto Cart { get; set; }
    }
}