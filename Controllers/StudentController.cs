using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Read(long? seatingNo)
        {
            if (seatingNo == null)
            {
                return BadRequest("You haven't entered saeting number");
            }

            var student = _context.Students.Find(seatingNo);

             if (student == null)
             {
                return NotFound("worong seating number");
             }
            return View(student);
        }
    }
}
