using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index","Product");
            }
            return View(s);
        }
        [HttpPost]
        public ActionResult Submit(Student s)
        {
            /*if(ModelState.IsValid)
            {
                return View(s);
            }
            return RedirectToAction("Create");*/
            return View();
            
        }
    }
}