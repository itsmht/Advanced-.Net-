using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMS.Models.Database;
using UMS.Models.Entity;
using AutoMapper;
using System.Web.Security;
using UMS.Auth;

namespace UMS.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
           /* UMSEntities db = new UMSEntities();
            var dept = (from d in db.Departments
                        where d.id == 1
                        select d).FirstOrDefault();
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Department, DepartmentStudentModel>();
                    cfg.CreateMap<Student, StudentModel>();
                }
                );
            var mapper = new Mapper(config);
            var deptModel = mapper.Map<DepartmentStudentModel>(dept);
            var courses = dept.Courses.ToList();
            var students = dept.Students.ToList();*/
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserModel user)
        {
            if(ModelState.IsValid)
            {
                UMSEntities db = new UMSEntities();
                var data = (from u in db.Users
                            where u.Username.Equals(user.Username) &&
                            u.Password.Equals(user.Password)
                            select u).FirstOrDefault();
                if (data != null)
                {
                    FormsAuthentication.SetAuthCookie(data.Username, false);
                    // FormsAuthentication.SignOut(); for logout
                    return RedirectToAction("Dashboard");
                }
            }
            return View();
        }
        [Authorize]
        public ActionResult Dashboard()
        {
            /*if(Session["User"] == null)
            {
                return RedirectToAction("Index");
            }*/
            UMSEntities db = new UMSEntities();
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Department, DepartmentModel>();        
                }
                );
            var deptDB = db.Departments.ToList();
            Mapper mapper = new Mapper(config);
            var data = mapper.Map<List<DepartmentModel>>(deptDB);
            return View(data);
            
        }
        [AdminAccess]
        public ActionResult AllUsers()
        {
            UMSEntities db = new UMSEntities();
            var config = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<User, UserModel>();

                }
                );
            var deptDb = db.Users.ToList();
            Mapper mapper = new Mapper(config);
            var data = mapper.Map<List<UserModel>>(deptDb);
            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}