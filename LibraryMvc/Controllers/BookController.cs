using Microsoft.AspNetCore.Mvc;

namespace LibraryMvc.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
