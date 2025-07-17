using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.Models
{
    public class User
    {
        public User() 
        {
            this.Reviews = new HashSet<Review>();
            this.Purchases = new HashSet<Purchase>();
        }   
        public int Id { get; set; }
        
        public string Username { get; set; }
        public string Password{ get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }

        public string NameSurname { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}