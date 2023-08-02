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

        public IActionResult Read(int? seating_no)
        {
            if (seating_no == null)
            {
                return View("Index");
            }
            var student = _context.Students.Find(seating_no);

            if (student == null)
            {
                return NotFound("wrong seating number");
            }

            return View(student);
        }
    }
}