using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission06_Pead.Data;
using Mission06_Pead.Models;

namespace Mission06_Pead.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = new SelectList(_context.Categories.OrderBy(c => c.Name), "CategoryId", "Name");
            return View(new Movie());
        }

        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return View("Confirmation", movie);
            }
            ViewBag.Categories = new SelectList(_context.Categories.OrderBy(c => c.Name), "CategoryId", "Name", movie.CategoryId);
            return View(movie);
        }
    }
}
