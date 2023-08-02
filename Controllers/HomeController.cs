using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThirdYear.Models;

namespace ThirdYear.Controllers
{
	public class HomeController : Controller
	{
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

        public IActionResult Read(long seatingNo)
        {
            var student = _context.Students.Find(seatingNo);

            if (student == null)
            {
                return NotFound("wrong seating number");
            }

            return View(student);
        }
    }
}