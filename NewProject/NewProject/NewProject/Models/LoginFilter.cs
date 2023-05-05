using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewProject.Models
{
    public class LoginFilter : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (Convert.ToBoolean(HttpContext.Current.Session["LogIn"]) == true )
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