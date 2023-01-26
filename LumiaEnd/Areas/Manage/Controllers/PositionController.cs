using LumiaEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LumiaEnd.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles ="SuperAdmin")]
    public class PositionController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public PositionController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
           List<Position> positions = _appDbContext.Positions.ToList();
            return View(positions);
        }
        public IActionResult Create()
        {
            ViewBag.Position = _appDbContext.Positions.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Position position)
        {
            ViewBag.Position = _appDbContext.Positions.ToList();
            if(!ModelState.IsValid) return NotFound();

            _appDbContext.Positions.Add(position);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Update(int id)
        {
            Position position = _appDbContext.Positions.Find(id);   
            if(position == null) return NotFound();
            return View(position);
        }
        [HttpPost]
        public IActionResult Update(Position position)
        {
            Position existPosition = _appDbContext.Positions.Find(position.Id);
            if(existPosition == null) return NotFound();
            existPosition.Name = position.Name;
            _appDbContext.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Delete(int id)
        {
            Position position = _appDbContext.Positions.Find(id);
            _appDbContext.Positions.Remove(position);
            _appDbContext.SaveChanges();
            return RedirectToAction("index");
        }
        

    }
}
