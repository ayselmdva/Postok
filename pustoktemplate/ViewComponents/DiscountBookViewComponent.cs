using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pustoktemplate.DAL;

namespace pustoktemplate.Components
{
    public class DiscountBookViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        public DiscountBookViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Books.
                Include(x=>x.BookImages).
                Include(x=>x.Author).
                Include(x=>x.Genre).
                Where(x=>x.DisCountPrice>0).ToListAsync());
        }
    }
}
