using GameSalesSystemMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.Dtos
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseAmount { get; set; }

        public int UserId { get; set; }

        public virtual UserDto User { get; set; }
    }
}