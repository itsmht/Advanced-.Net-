using EFStudent.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFStudent.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            EFEntities db = new EFEntities();
            var data = db.Students.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            if(ModelState.IsValid)
            {
                EFEntities db = new EFEntities();
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Scholarship()
        {
            EFEntities db = new EFEntities();
            var data = (from s in db.Students
                        where s.CGPA > 3.75
                        select s).ToList();
            return View(data);
        }
        public ActionResult SpecialDiscount(Student a)
        {
            int age = 0;
            age = DateTime.Now.Subtract(a.DOB).Days;
            age = age / 365;
            
            EFEntities db = new EFEntities();
            var data = (from s in db.Students
                        where s.CGPA > 3.5 && age > 30
                        select s).ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            EFEntities db = new EFEntities();
            var data = (from s in db.Students
                        where s.id == Id
                        select s).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Student sub_s)
        {
            EFEntities db = new EFEntities();
            var data = (from s in db.Students
                        where s.id == sub_s.id
                        select s).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(sub_s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            EFEntities db = new EFEntities();
            var data = (from s in db.Students
                        where s.id == Id
                        select s).FirstOrDefault();
            
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Student sub_s)
        {
            EFEntities db = new EFEntities();
            var data = (from s in db.Students
                        where s.id == sub_s.id
                        select s).FirstOrDefault();
            
            db.Students.Remove(data);
            db.SaveChanges();
            return View();
        }

    }
    
}