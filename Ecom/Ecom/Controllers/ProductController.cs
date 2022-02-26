using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecom.Models.Database;

namespace Ecom.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            EcommerceEntities db = new EcommerceEntities();
            var data = db.Products.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            
            return View(new Product());
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (!ModelState.IsValid)
            {
                EcommerceEntities db = new EcommerceEntities();
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EcommerceEntities db = new EcommerceEntities();
            var data = (from p in db.Products
                        where p.id == id
                        select p).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Product sub_p)
        {
            EcommerceEntities db = new EcommerceEntities();
            var data = (from p in db.Products
                        where p.id == sub_p.id
                        select p).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(sub_p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            EcommerceEntities db = new EcommerceEntities();
            var data = (from p in db.Products
                        where p.id == id
                        select p).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(Product sub_p)
        {
            EcommerceEntities db = new EcommerceEntities();
            var data = (from p in db.Products
                        where p.id == sub_p.id
                        select p).FirstOrDefault();
            db.Products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}