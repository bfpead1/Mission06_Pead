using Microsoft.AspNetCore.Mvc;
using Mission06_Pead.Data;
using Mission06_Pead.Models;

namespace Mission06_Pead.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // GET: /Home/AddMovie
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View("AddMovie", new Movie());
        }

        // POST: /Home/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View("AddMovie", movie);
            }

            var category = _context.Categories.FirstOrDefault(c => c.Name.ToLower() == movie.CategoryName.Trim().ToLower());
            if (category == null)
            {
                category = new Category { Name = movie.CategoryName.Trim() };
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            movie.CategoryId = category.CategoryId;

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
