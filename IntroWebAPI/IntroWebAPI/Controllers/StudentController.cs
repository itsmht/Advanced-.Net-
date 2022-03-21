using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntroWebAPI.Models.Entity;
using IntroWebAPI.Models.Database;

namespace IntroWebAPI.Controllers
{
    public class StudentController : ApiController
    {
        [Route("api/student/add")]
        [HttpPost]
        public string Post(Student s)
        {
            UniEntities db = new UniEntities();
            db.Students.Add(s);
            db.SaveChanges();
            return "Added";
        }
        [Route("api/student/get")]
        public List<Student> Get()
        {
            UniEntities db = new UniEntities();
            var data = db.Students.ToList();
            return data;
        }
        [Route("api/student/get")]
        public Student Get(int id)
        {
            var db = new UniEntities();
            var data = (from s in db.Students
                        where s.id == id
                        select s).FirstOrDefault();
            return data;
        }
        [Route("api/student/put")]
        [HttpGet]
        public string Put(int id, Student st)
        {
            var db = new UniEntities();
            var data = (from s in db.Students
                        where s.id == id
                        select s).FirstOrDefault();
            db.Students.Add(data);
            db.Entry(data).CurrentValues.SetValues(st);
            db.SaveChanges();
            return "Updated";

        }
        [Route("api/student/delete")]
        public string Delete(int id)
        {
            var db = new UniEntities();
            var data = (from s in db.Students
                        where s.id == id
                        select s).FirstOrDefault();
            db.Students.Remove(data);
            db.SaveChanges();
            return "Deleted";
        }
        

    }
}
