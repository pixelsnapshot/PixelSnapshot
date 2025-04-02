using Microsoft.AspNetCore.Mvc;

namespace PixelSnapshot.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult BlogSingle()
        {
            return View();
        }
    }
}
