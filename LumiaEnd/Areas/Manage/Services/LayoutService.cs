using LumiaEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace LumiaEnd.Areas.Manage.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _appDbContext;

        public LayoutService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Setting>> GetSettingsAsync()
        {
            return await _appDbContext.Settings.ToListAsync();
        }
    }
}
