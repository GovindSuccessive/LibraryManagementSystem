using Microsoft.AspNetCore.Mvc;

namespace LibraryMvc.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
