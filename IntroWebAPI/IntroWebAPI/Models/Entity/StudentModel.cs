using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntroWebAPI.Models.Entity
{
    public class StudentModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public System.DateTime DOB { get; set; }
        public double CGPA { get; set; }

    }
}