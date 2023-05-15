using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pustoktemplate.DAL;

namespace pustoktemplate.ViewComponents
{
    public class RandomBooksViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        public RandomBooksViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Books.
                Include(x => x.BookImages).
                Include(x => x.Author).
                Include(x => x.Genre).
                Where(x => x.IsAvailable == true).OrderBy(x=>Guid.NewGuid()).ToListAsync());
        }
    }
}
