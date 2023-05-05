using NewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewProject.Controllers
{
    public class DashboardController : Controller
    {
        smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();
        // GET: Dashboard
        public ActionResult Index()
        {
            
            return View();
        }
        
    
      
       
        
        
    }
}