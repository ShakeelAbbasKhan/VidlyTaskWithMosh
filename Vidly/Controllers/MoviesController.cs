using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MoviesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            var data = _db.Movies.Include(c => c.Genre).ToList();
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        public ActionResult Details(int id)
        {
            var movies = _db.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movies == null)
                return NotFound();

            return View(movies);
        }



        //public IActionResult Random()
        //{ 
        //    var movies = new Movie() {Name = "Sherk"};

        //    var customers = new List<Customer>
        //    {
        //        new Customer { Name = "Customer1"},
        //        new Customer { Name = "Customer2"},

        //    };

        //    var randomMovieVm = new RandomMovieVM
        //    {
        //        Movie = movies,
        //        Customers = customers
        //    };
        //    return View(randomMovieVm);
        //}
    }
}
