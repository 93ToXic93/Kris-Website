using Microsoft.AspNetCore.Mvc;

namespace Kris.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
