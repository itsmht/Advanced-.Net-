using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();
            for (int i = 0; i<11; i++)
            {
                var p = new Product()
                {
                    Id = i + 1,
                    Name = "Product" + (i + 1)
                };
                products.Add(p);
            }
            return View(products);
        }
    }
}