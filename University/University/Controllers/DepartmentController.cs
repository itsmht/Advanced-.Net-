using University.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace University.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            UniEntities1 db = new UniEntities1();
            var data = db.Departments.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Department());
        }
        [HttpPost]
        public ActionResult Create(Department s)
        {
            if (ModelState.IsValid)
            {
                UniEntities1 db = new UniEntities1();
                db.Departments.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            UniEntities1 db = new UniEntities1();
            var data = (from s in db.Departments
                        where s.id == id
                        select s).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Department sub_s)
        {
            UniEntities1 db = new UniEntities1();
            var data = (from s in db.Departments
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
            var data = (from s in db.Departments
                        where s.id == id
                        select s).FirstOrDefault();

            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(Department sub_s)
        {
            UniEntities1 db = new UniEntities1();
            var data = (from s in db.Departments
                        where s.id == sub_s.id
                        select s).FirstOrDefault();

            db.Departments.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}