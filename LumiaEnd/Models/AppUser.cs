using Microsoft.AspNetCore.Identity;

namespace LumiaEnd.Models
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
    }
}
