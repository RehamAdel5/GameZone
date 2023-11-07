using GameZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDBContext _context;

        public CategoriesService(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Categories
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .OrderBy(c => c.Text)
                    .AsNoTracking()
                    .ToList();
        }
    }
}
