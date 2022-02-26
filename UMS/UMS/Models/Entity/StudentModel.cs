using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.Models.Entity
{
    public class StudentModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentModel Department { get; set; }
    }
}