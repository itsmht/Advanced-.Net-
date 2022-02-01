using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroMVC.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Login()
        {
            return View();
        }
    }
}