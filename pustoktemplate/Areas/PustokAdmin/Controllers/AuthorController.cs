using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pustoktemplate.DAL;
using pustoktemplate.Models;

namespace pustoktemplate.Areas.PustokAdmin.Controllers
{
    [Area("PustokAdmin")]
    public class AuthorController : Controller
    {
        private readonly AppDbContext _context;
        public AuthorController(AppDbContext context)
        {
            _context = context;
        }

        public async Task< IActionResult> Index()
        {
            return View(await _context.Author.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult>Create(Author author)
        {
            await _context.Author.AddAsync(author);
            await _context.SaveChangesAsync();
            return View();
        }
        [HttpGet]
        public async Task< IActionResult> Edit(int id)
        {
            return  View(await _context.Author.FirstOrDefaultAsync(x => x.Id == id));
        }
        [HttpPost]
        public async  Task <IActionResult> Edit(Author author)
        {
            Author ? exist=await _context.Author.FirstOrDefaultAsync(x=>x.Id== author.Id);
            if (exist == null)
            {
                ModelState.AddModelError("", "This file not found");
                return View();
            }
            exist.Name=author.Name;
            return RedirectToAction("Index");   
        }
        [HttpPost]
		public async Task<IActionResult> Delete([FromBody]int id)
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
