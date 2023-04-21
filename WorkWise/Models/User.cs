using System.ComponentModel.DataAnnotations;
using WorkWise.Controllers;
using Microsoft.AspNetCore.Identity;


namespace WorkWise.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }


        public string? FirstName { get; set; }


        public string? LastName { get; set; }


        public string? Email { get; set; }


        public string? Phone { get; set; }


        public string? Password { get; set; }
    }

}
