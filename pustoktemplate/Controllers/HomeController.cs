using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.ContentModel;
using pustoktemplate.DAL;
using pustoktemplate.Models;
using pustoktemplate.ViewModels;

namespace pustoktemplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task< IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> AddBasket(int id)
        {
            Book book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            List<BasketVm> baskets = new List<BasketVm>();
            BasketVm basketitem = null;
            if (book != null)
            {
                if (Request.Cookies["Book"]!=null)
                {
                    baskets = JsonConvert.DeserializeObject<List<BasketVm>>(Request.Cookies["Book"]);
                    basketitem = baskets.FirstOrDefault(x => x.BookId == id);
                }
            }
            if (basketitem == null)
            {
                baskets.Add(new BasketVm
                {
                    BookId = id,
                    Count = 1
                });
            }
            else
            {
                basketitem.Count++;
            }
            Response.Cookies.Append("Book", JsonConvert.SerializeObject(baskets));
            return RedirectToAction("Index");
        }

    }
}
