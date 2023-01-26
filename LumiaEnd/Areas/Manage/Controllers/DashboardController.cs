using LumiaEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LumiaEnd.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin")]

    public class DashboardController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser admin = new AppUser
        //    {
        //        UserName = "Ceyran26",
        //        Fullname = "Ceyran Murselova"
        //    };
        //    var result = await _userManager.CreateAsync(admin, "Ceyran26");
        //    return Ok(result);
        //}
        //public async Task<IActionResult> CraeteRole()
        //{
        //    IdentityRole role1 = new IdentityRole("SuperAdmin");
        //    IdentityRole role2 = new IdentityRole("Admin");
        //    await _roleManager.CreateAsync(role1);
        //    await _roleManager.CreateAsync(role2);

        //    return Ok("created");
        //}
        //public async Task<IActionResult> AddRole()
        //{
        //    AppUser appUser = await _userManager.FindByNameAsync("Ceyran26");

        //    await _userManager.AddToRoleAsync(appUser, "SuperAdmin");
        //    return Ok("Role Added");
        //}
    }
}
