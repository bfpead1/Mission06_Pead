using Microsoft.AspNetCore.Mvc;

namespace Mission06_Pead.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return RedirectToAction("Add", "Movies");
        }
    }
}
