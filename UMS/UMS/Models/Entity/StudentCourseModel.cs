using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.Models.Entity
{
    public class StudentCourseModel : StudentModel
    {
        public List<CourseModel> Courses { get; set; }
        public StudentCourseModel()
        {
            Courses = new List<CourseModel>();
        }
    }
}