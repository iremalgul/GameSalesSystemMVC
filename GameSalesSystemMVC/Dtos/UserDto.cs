using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public CartDto Cart { get; set; }
        public string NameSurname { get; set; }
    }
}