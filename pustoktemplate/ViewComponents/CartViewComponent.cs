using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using pustoktemplate.DAL;
using pustoktemplate.Models;
using pustoktemplate.ViewModels;

namespace pustoktemplate.ViewComponents
{
    public class CartViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        public CartViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<BasketVm> basketVm = new();
            if (Request.Cookies["Book"] != null)
            {
                basketVm = JsonConvert.DeserializeObject<List<BasketVm>>(Request.Cookies["Book"]);

            }
            List<BasketItemVm> basketItemVm = new List<BasketItemVm>();
            foreach (var item in basketVm)
            {
                Book book = await _context.Books.FirstOrDefaultAsync(x => x.Id == item.BookId);
                if (book != null)
                {
                    basketItemVm.Add(new BasketItemVm()
                    {
                        BookId = item.BookId,
                        Image = book.BookImages.FirstOrDefault(x => x.Ismain == true).Image,
                        Price = book.Price - book.DisCountPrice,
                        Name = book.Name,
                        Count = item.Count,
                    });
                }

            }
            return View(basketItemVm);

        }
    }
}
