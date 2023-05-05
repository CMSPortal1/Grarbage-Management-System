using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewProject.Models
{
    public class RolesFilter:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (Convert.ToBoolean(HttpContext.Current.Session["Isadmin"]) == true /*Roles.Contains("admin")*/)
            {
                return true;
            }
            else
            { 
                return false;
            }

       
        }
    }
}