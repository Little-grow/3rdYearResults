using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
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
            int TotalStudents = _context.Students.Count();
            int TotalSuccessfulStudents = _context.Students.Where(s => s.student_case == 1).Count();
            int TotalFailingStudents = _context.Students.Where(s => s.student_case == 2).Count();
            int TotalSecondChnaceStudent = _context.Students.Where(s => s.student_case == 3).Count();
            int TotalStudentsAbove95 = GetStudentsCount(95);
            int TotalStudentsAbove90 = GetStudentsCount(90);
            int TotalStudentsAbove85 = GetStudentsCount(85);
            int TotalStudentsAbove80 = GetStudentsCount(80);
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

            return View("index", model);
        }

        private int GetStudentsCount(double n)
        {
            return _context.Students.Where(s=> s.Percentage >= n).Count();
        }

		public ActionResult Diagram()
		{
			List<DataPoint> dataPoints = new List<DataPoint>();

			dataPoints.Add(new DataPoint("95%", GetStudentsCount(95)));
			dataPoints.Add(new DataPoint("90%", GetStudentsCount(90)));
			dataPoints.Add(new DataPoint("85%", GetStudentsCount(85)));
			dataPoints.Add(new DataPoint("80%", GetStudentsCount(80)));
			dataPoints.Add(new DataPoint("75%", GetStudentsCount(75)));
			dataPoints.Add(new DataPoint("70%", GetStudentsCount(70)));
			dataPoints.Add(new DataPoint("65%", GetStudentsCount(65)));
			dataPoints.Add(new DataPoint("60%", GetStudentsCount(60)));
			dataPoints.Add(new DataPoint("55%", GetStudentsCount(55)));
			dataPoints.Add(new DataPoint("50%", GetStudentsCount(50)));

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

			return View();
		}

	}
}
