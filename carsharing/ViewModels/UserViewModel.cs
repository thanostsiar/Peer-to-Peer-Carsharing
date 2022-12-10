using carsharing.Models;
using carsharing.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace carsharing.ViewModels
{
    public class UserViewModel
    {
        public Renter? Renter { get; set; }
        public Owner? Owner { get; set; }
        public String? Role { get; set; }
    }
}
