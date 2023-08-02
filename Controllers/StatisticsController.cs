using Microsoft.AspNetCore.Mvc;
using ThirdYear.Models;

namespace ThirdYear.Controllers
{
    public class StatisticsController: Controller
    {
        private readonly AppDbContext _context;

        public StatisticsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            const int Total_Degree = 665;
            int TotalStudents = _context.Students.Count();
            int TotalSuccessfulStudents = _context.Students.Where(s => s.student_case == 1 ).Count();
            int TotalFailingStudents = _context.Students.Where(s => s.student_case == 2).Count();
            int TotalSecondChnaceStudent = _context.Students.Where(s => s.student_case == 3).Count();
            int TotalStudentsAbove95 = _context.Students.Where(s => s.student_case == 1 && s.total_degree/Total_Degree >= 0.95).Count();
            int TotalStudentsAbove90 = _context.Students.Where(s => s.student_case == 1 && s.total_degree / Total_Degree >= 0.90).Count();
            int TotalStudentsAbove85 = _context.Students.Where(s => s.student_case == 1 && s.total_degree / Total_Degree >= 0.85).Count();
            int TotalStudentsAbove80 = _context.Students.Where(s => s.student_case == 1 && s.total_degree / Total_Degree >= 0.80).Count();
            double AverageMarks = _context.Students.Average(s => s.total_degree);
            double FirstStudentDegree = _context.Students.Max(s => s.total_degree);
            double LastStudentDegree = _context.Students.Where(s => s.arabic_name != null).Min(s => s.total_degree);

            var model = new Statistics
            {
                TotalStudents = TotalStudents,
                TotalSuccessfulStudents = TotalSuccessfulStudents,
                TotalFailingStudents = TotalFailingStudents,
                TotalSecondChnaceStudent = TotalSecondChnaceStudent,
                TotalStudentsAbove95 = TotalStudentsAbove95,
                TotalStudentsAbove90 = TotalStudentsAbove90,
                TotalStudentsAbove85 = TotalStudentsAbove85,
                TotalStudentsAbove80 = TotalStudentsAbove80,
                AverageMarks = AverageMarks,
                FirstStudentDegree = FirstStudentDegree,
                LastStudentDegree = LastStudentDegree
            };

            return View("index",model);
        }
    }
}
