using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pustoktemplate.DAL;
using pustoktemplate.Models;
using pustoktemplate.Utilities.Extentions;

namespace pustoktemplate.Areas.PustokAdmin.Controllers
{
    [Area("PustokAdmin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public SliderController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task< IActionResult> Index()
        {
          return View(await _context.Sliders.ToListAsync());
           
            
        }
        public async Task<IActionResult> Detail(int id)
        {
            return View(await _context.Sliders.FirstOrDefaultAsync(x=>x.Id==id));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
          if(!ModelState.IsValid) { return View(); }


           if (!slider.ImageFile.CheckFiletype("image/"))
           {
                ModelState.AddModelError("SliderController", "This is not image");
                return View();
           }
            if (slider.ImageFile.Length / 1024 > 2000)
            {
                ModelState.AddModelError("SliderController", "This is false");
                return View();
            }

            slider.Image = await slider.ImageFile.SaveFileAsync(_environment.WebRootPath, "bg-images");
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _context.Sliders.FirstOrDefaultAsync(x => x.Id == id));
        }
        public async Task <IActionResult>Edit(Slider slider)
        {
            Slider? exist = await _context.Sliders.FirstOrDefaultAsync(x => x.Id == slider.Id);
            if (exist == null)
            {
                ModelState.AddModelError("", "Slider not found");
                return View();
            }
            if (!exist.ImageFile.CheckFiletype("image/"))
            {
                ModelState.AddModelError("SliderController", "This is not image");
                return View();
            }
            if (exist.ImageFile.Length / 1024 > 200)
            {
                ModelState.AddModelError("SliderController", "This is false");
                return View();
            }
            exist.Image = await exist.ImageFile.SaveFileAsync(_environment.WebRootPath, "slider");
            exist.Title1 = slider.Title1;
            exist.Title2 = slider.Title2;
            exist.Image = slider.Image;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            Slider? exist = await _context.Sliders.FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null)
            {
                ModelState.AddModelError("", "Invalid Input");
                return Json(new { status = 404 });
            }
            _context.Sliders.Remove(exist);
            await _context.SaveChangesAsync();
            return Json(new { status=200});
        }
    }
    
}
