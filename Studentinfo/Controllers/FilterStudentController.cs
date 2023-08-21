using Microsoft.AspNetCore.Mvc;
using Studentinfo.Data;
using Studentinfo.Data.NewFolder.NewFolder;
using Studentinfo.Models;
using System;

namespace Studentinfo.Controllers
{
    public class FilterStudentController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IStudentRepository _studentRepository;

        public FilterStudentController(ApplicationDbContext context, IStudentRepository studentRepository)
        {
            _context = context;
            _studentRepository = studentRepository;
        }
       
        public IActionResult Index(string className, string firstName, string lastName)
        {
            var students = _studentRepository.FilterBy(className, firstName, lastName);
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }

       
        public IActionResult Upsert(int? id)
        {
            Student student = new Student(); //new is used to intialize and object save like category
            if (id == null)
                return View(student);
            var studentInDb = _studentRepository.Get(id.GetValueOrDefault());
            return View(studentInDb);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Student student)
        {
            if (student == null)
                return NotFound();
            if (!ModelState.IsValid)
            {
                if (student.Id == 0)
                    _studentRepository.Add(student);
                else
                    _studentRepository.Update(student);
                _studentRepository.Save();
                return RedirectToAction(nameof(Create));
            }
            return View(student);
        }
        #region APIs   //we make API because we feTCH DATA FROM MULTIPLE TABLES
        [HttpGet]
        public IActionResult GetAll()
        {
            var categoryList = _studentRepository.GetAll();
            return Json(new { data = _studentRepository.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var categoryInDb = _studentRepository.Get(id);
            if (categoryInDb == null)
                return Json(new { success = false, message = "Error while delete data !!" });
            _studentRepository.Remove(id);
            _studentRepository.Save();
            return Json(new { success = true, message = "Data successfully deleted !!" });
        }
        #endregion



    }
}

   
  
