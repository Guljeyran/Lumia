using LumiaEnd.Helpers;
using LumiaEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LumiaEnd.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin")]

    public class TeamController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public TeamController(AppDbContext appDbContext,IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Team> teams = _appDbContext.Teams.Include(x=>x.Position).ToList();
            return View(teams);
        }
        public IActionResult Create()
        {
            ViewBag.Position = _appDbContext.Positions.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Team team)
        {
            ViewBag.Position = _appDbContext.Positions.ToList();
            if (!ModelState.IsValid) return NotFound();
            if (team.ImageFile.ContentType != "image/png" && team.ImageFile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("ImageFile", "You can only upload image type png or jpeg");
            }
            if (team.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "You can only upload image size lower than 2mb");
            }
            team.Image = team.ImageFile.SaveFile(_env.WebRootPath, "uploads/teams");
            _appDbContext.Teams.Add(team);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            ViewBag.Position = _appDbContext.Positions.ToList();
            Team team = _appDbContext.Teams.FirstOrDefault(x => x.Id == id);
            if(team == null) return NotFound();
            return View(team);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Team team)
        {
            ViewBag.Position = _appDbContext.Positions.ToList();
            if (!ModelState.IsValid) return NotFound();
            Team existTeam = _appDbContext.Teams.Find(team.Id);
            if (existTeam == null) return NotFound();
            if (team.ImageFile != null)
            {
                existTeam.Image.DeleteOld(_env.WebRootPath, "uploads/teams");
                if (team.ImageFile.ContentType != "image/png" && team.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "You can only upload image type png or jpeg");
                }
                if (team.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "You can only upload image size lower than 2mb");
                }
                existTeam.Image = team.ImageFile.SaveFile(_env.WebRootPath, "uploads/teams");
            }
            existTeam.PositionId = team.PositionId;
            existTeam.Fullname = team.Fullname;
            existTeam.Desc = team.Desc;
            existTeam.RedirectUrl1=team.RedirectUrl1;
            existTeam.RedirectUrl2=team.RedirectUrl2;
            existTeam.RedirectUrl3=team.RedirectUrl3;
            existTeam.RedirectUrl4=team.RedirectUrl4;
            _appDbContext.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Team team = _appDbContext.Teams.Find(id);
            if(team == null) return NotFound();
            _appDbContext.Teams.Remove(team);
            _appDbContext.SaveChanges();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\teams\\", team.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            return RedirectToAction("index");
        }

    }
}
