using GroupWebProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupWebProject.Areas.Identity.Data.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly GroupContext _context;
        public CategoriesViewComponent(GroupContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync() => View(await _context.Catgories.ToListAsync());
    }
}
