using Microsoft.AspNetCore.Mvc;
using Studentinfo.Data;
using Studentinfo.Models;
using System;

namespace Studentinfo.Controllers
{
    public class FilterStudentController : Controller
    {

        private readonly ApplicationDbContext _context;

        public FilterStudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string className, string firstName, string lastName)
        {
            var students = from s in _context.Students
                           select s;

            if (!string.IsNullOrEmpty(className))
            {
                students = students.Where(s => s.ClassName.Contains(className));
            }

            if (!string.IsNullOrEmpty(firstName))
            {
                students = students.Where(s => s.FirstName.Contains(firstName));
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                students = students.Where(s => s.LastName.Contains(lastName));
            }

            return View(students.ToList());
        }
       


    }
}

   
  
