using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace GameSalesSystemMVC.Dtos
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Picture { get; set; }
        

    }
}