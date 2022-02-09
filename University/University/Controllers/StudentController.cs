using University.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace University.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            UniEntities1 db = new UniEntities1();
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
            if (ModelState.IsValid)
            {
                UniEntities1 db = new UniEntities1();
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Scholarship()
        {
            UniEntities1 db =new UniEntities1();
            var data = (from s in db.Students
                        where s.CGPA > 3.75
                        select s).ToList();
            return View(data);
        }
        public ActionResult SpecialDiscount(Student a)
        {
            DateTime now = DateTime.Today;
            DateTime bday = a.DOB;
            int age = 0;
            age = now.Year-bday.Year;
            if(bday>now.AddYears(-age))
            {
                age--;
            }
            UniEntities1 db = new UniEntities1();
            var data = (from s in db.Students
                        where s.CGPA > 3.5
                        && age > 30
                        select s).ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            UniEntities1 db = new UniEntities1();
            var data = (from s in db.Students
                        where s.id == id
                        select s).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student sub_s)
        {
            UniEntities1 db = new UniEntities1();
            var data = (from s in db.Students
                        where s.id == sub_s.id
                        select s).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(sub_s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            UniEntities1 db = new UniEntities1();
            var data = (from s in db.Students
                        where s.id == id
                        select s).FirstOrDefault();

            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(Student sub_s)
        {
            UniEntities1 db =new UniEntities1();
            var data = (from s in db.Students
                        where s.id == sub_s.id
                        select s).FirstOrDefault();

            db.Students.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}