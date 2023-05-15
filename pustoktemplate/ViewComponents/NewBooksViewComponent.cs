using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pustoktemplate.DAL;

namespace pustoktemplate.ViewComponents
{
    public class NewBooksViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        public NewBooksViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View(await _context.Books.
                Include(x => x.BookImages).
                Include(x => x.Author).
                Include(x => x.Genre).
                Where(x=>x.IsAvailable==true).OrderByDescending(x=>x.Id==id).ToListAsync());
        }
    }
}
