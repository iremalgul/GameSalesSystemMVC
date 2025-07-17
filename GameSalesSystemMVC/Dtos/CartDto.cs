using GameSalesSystemMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.Dtos
{
    public class CartDto
    {
        public int Id { get; set; }
        public decimal TotalCost { get; set; }
        public UserDto User { get; set; }
    }
}