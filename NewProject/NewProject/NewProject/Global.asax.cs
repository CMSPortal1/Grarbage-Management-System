using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NewProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Application_EndRequest(object sender, System.EventArgs e)
        {
            //string a = "";
            Exception TheError = Server.GetLastError();

            Server.ClearError();

            // If the user is not authorised to see this page or access this function, send them to the error page.
            if (Response.StatusCode == 401)
            {


                Response.ClearContent();
                Response.Redirect("~/Login/Error");
            }

            else if (Response.StatusCode == 404)
            {


                Response.ClearContent();
                Response.Redirect("~/Login/NotFound");
            }

            else if (Response.StatusCode == 500)
            {
                Response.ClearContent();
                //if (TheError != null)
                //{
                //    string abc = TheError.InnerException == null ? " " : TheError.InnerException.Message.ToString();
                //    Response.Redirect("~/Account/Error?id=" + "  Main Exception  " + TheError.Message.ToString() + "  Inner Exception  " + abc);
                //}

                Response.Redirect("~/Login/Errorshow");

            }

            //else if (Response.StatusCode == 500)
            //{

            //    Response.ClearContent();
            //    Response.Redirect("~/Account/Error");
            //}

        }



    }
}
