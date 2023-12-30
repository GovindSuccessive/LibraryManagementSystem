using Microsoft.AspNetCore.Mvc;

namespace LibraryMvc.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
