using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pustoktemplate.DAL;
using pustoktemplate.Models;
using pustoktemplate.Utilities.Extentions;

namespace pustoktemplate.Areas.PustokAdmin.Controllers
{
    [Area("PustokAdmin")]
    public class BookController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public BookController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task <IActionResult> Index()
        {
            return View( await _context.Books.Include(x=>x.Author).Include(x=>x.Genre).ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Authors = _context.Author.ToList();
            ViewBag.Genres= _context.Genres.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            ViewBag.Authors = _context.Author.ToList();
            ViewBag.Genres = _context.Genres.ToList();
            if (!ModelState.IsValid) return View();
            if(book==null) return View();

            if (!book.MainFile.CheckFiletype("image/"))
            {
                ModelState.AddModelError("MainFile", "Error");
                return View();
            }
           
            if (book.MainFile.CheckFileSize(2000))
            {
                ModelState.AddModelError("MainFile", "Error");
                return View();
            }


            book.BookImages = new List<BookImage>();    
            book.BookImages.Add(new BookImage
            {
                Ismain = true,
                Image = await book.MainFile.SaveFileAsync(_environment.WebRootPath, "bg-images"),
                books = book
            }); 
           
            foreach (var files in book.Files)
            {
                if (!files.CheckFiletype("image/"))
                {
                    ModelState.AddModelError("Files", "Error");
                    return View();
                }

                if (files.CheckFileSize(2000))
                {
                    ModelState.AddModelError("Files", "Error");
                    return View();
                }
            book.BookImages.Add(new BookImage
            {
                Ismain = false,
                Image = await files.SaveFileAsync(_environment.WebRootPath, "bg-images"),
                books = book
            });
            }
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");



        }
    }
}
