using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ThirdYear.Models;

namespace ThirdYear.Controllers
{
    public class StudentController:Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
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
                //var errorModel = new ErrorViewModel
                //{
                //    RequestId = HttpStatusCode.NotFound.ToString()
                //};

                //return View("Error", errorModel);
                return View("NotFound");
            }

            return View(student);
        }
    }
}
