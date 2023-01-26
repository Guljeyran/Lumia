using LumiaEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LumiaEnd.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public SettingController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            List<Setting> settings = _appDbContext.Settings.ToList();
            return View(settings);
        }
        public IActionResult Update(int id)
        {
            Setting setting = _appDbContext.Settings.Find(id);
            if (setting == null) return NotFound();
            return View(setting);
        }
        [HttpPost]
        public IActionResult Update(Setting setting)
        {
            Setting existSetting= _appDbContext.Settings.Find(setting.Id);
            if (existSetting == null) return NotFound();
            existSetting.Value = setting.Value;
            _appDbContext.SaveChanges();
            return RedirectToAction("index");

        }
    }
}
