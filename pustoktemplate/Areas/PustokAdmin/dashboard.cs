using Microsoft.AspNetCore.Mvc;

namespace pustoktemplate.Areas.PustokAdmin
{
    public class dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
