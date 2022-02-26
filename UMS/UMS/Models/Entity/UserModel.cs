using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.Models.Entity
{
    public class UserModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}