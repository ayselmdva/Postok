
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using pustoktemplate.DAL;
using pustoktemplate.Models;
using pustoktemplate.Utilities.Extentions;
using pustoktemplate.ViewModels;

namespace pustoktemplate.Controllers
{
    public class ProductController:Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task< IActionResult> Cart()
        {
            List<BasketVm> basketVm = new();
            if (Request.Cookies["Book"] != null)
            {
                basketVm = JsonConvert.DeserializeObject<List<BasketVm>>(Request.Cookies["Book"]);

            }
            List<BasketItemVm> basketItemVm = new List<BasketItemVm>();
            foreach (var item in basketVm)
            {
                Book book = await _context.Books.Include(x=>x.BookImages).FirstOrDefaultAsync(x => x.Id == item.BookId);
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
        public async Task<IActionResult> Increement(int id)
        {
            List<BasketVm>? basketVm = JsonConvert.DeserializeObject<List<BasketVm>>(Request.Cookies["Book"]);
            BasketVm basket = basketVm.Find(x => x.BookId == id);
            basket.Count++;
            Response.Cookies.Append("Book", JsonConvert.SerializeObject(basketVm));
            return RedirectToAction("Cart");

        }
        public async Task<IActionResult> Decreement(int id)
        {

            List<BasketVm>? basketVm = JsonConvert.DeserializeObject<List<BasketVm>>(Request.Cookies["Book"]);
            BasketVm basket = basketVm.Find(x => x.BookId == id);
            if (basket.Count != 1)
            {
                basket.Count--;
            }
            else
            {
                basketVm.Remove(basket);
            }
            
            Response.Cookies.Append("Book", JsonConvert.SerializeObject(basketVm));
            return RedirectToAction("Cart");

        }
    }
}
