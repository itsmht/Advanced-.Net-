using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.Models.Entity
{
    public class DepartmentStudentModel : DepartmentModel
    {
        public List<StudentModel> Students { get; set; }
        public DepartmentStudentModel()
        {
            Students = new List<StudentModel>();
        }
    }
}