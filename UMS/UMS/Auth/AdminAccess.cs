using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMS.Models.Database;

namespace UMS.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            var authenticated = base.AuthorizeCore(httpContext);
            if (!authenticated)
            {
                return false;
            }
            var username = httpContext.User.Identity.Name;
            UMSEntities db = new UMSEntities();
            var role = from e in db.Users
                       where e.Username.Equals(username)
                       select e.Role;
            if (role.Equals("Admin")) return true;
            else return false;

            /*if (httpContext.Session["UserType"].ToString().Equals("Admin"))
            {
                return true;
            }
            else return false;*/
        }
    }
}