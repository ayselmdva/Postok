using Microsoft.AspNetCore.Mvc;

namespace pustoktemplate.Areas.PustokAdmin.Controllers
{
    public class DashboardController : Controller
    {
        [Area("PustokAdmin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
