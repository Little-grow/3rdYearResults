using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThirdYear.Models;

namespace ThirdYear.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}
	}
}