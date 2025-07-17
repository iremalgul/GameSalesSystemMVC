using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.Models
{
    public class GameCrudModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
    }
}