using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pustoktemplate.DAL;
using pustoktemplate.Models;

namespace pustoktemplate.Areas.PustokAdmin.Controllers
{
    public class GenreController : Controller
    {
        private readonly AppDbContext _context;
        public GenreController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Genres.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _context.Genres.FirstOrDefaultAsync(x => x.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Genre genre)
        {
            Genre? exist = await _context.Genres.FirstOrDefaultAsync(x => x.Id == genre.Id);
            if (exist == null)
            {
                ModelState.AddModelError("", "This file not found");
                return View();
            }
            exist.Name = genre.Name;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            Author? exist = await _context.Author.FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null)
            {
                ModelState.AddModelError("", "Invalid Input");
                return View();
            }
            _context.Author.Remove(exist);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
