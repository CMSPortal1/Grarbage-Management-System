using NewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using Garbage.Common.DTO;
using Garbage.Services.implementation;

namespace NewProject.Controllers
{
   
    public class rolesController : Controller
    {
      
        smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();
        // GET: roles
        
        public ActionResult Index()
        {
            Session["LogIn"] = true;
            RolesService CreateRoles = new RolesService();
            var Roles = CreateRoles.AllRoles();
            return View(Roles);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Session["LogIn"] = true;
            return View();
        }
        [LoginFilter]
        [HttpPost]
        public ActionResult Create(RolesDTO Roles)   
        {
            //DONE
           
            RolesService CreateRoles = new RolesService();
            var RoleTitles = CreateRoles.AddRoles(Roles);
          
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            RolesService CreateRoles = new RolesService();
            var edit = CreateRoles.EditRole(id);

            if (edit.data == null)
            {
                return HttpNotFound();
            }
           
            
            var Roles = CreateRoles.AllRoles();
            ViewBag.role_title = Roles;

            return View(edit.data);
        }
        [HttpPost]
        public ActionResult Edit(RolesDTO Role)
        {
            Role.created_on = DateTime.Now;
           Role.updated_on = DateTime.Now;
            Role.updated_by = "Admin";
           Role.created_by = "Admin";
            RolesService CreateRoles = new RolesService();
            var Save=CreateRoles.SaveRoles(Role);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            //if(id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //role Role = db.roles.Find(id);
            RolesService CreateRoles = new RolesService();
            var edit = CreateRoles.EditRole(id);
            {
                if (edit.data== null)
                return HttpNotFound();
            }
            return View(edit.data);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // role Role = db.roles.Find(id);
            RolesService CreateRoles = new RolesService();
            var edit = CreateRoles.EditRole(id);
            var del = edit.data;
           var Delete= CreateRoles.ConfirmedDelRoles(del);
            return RedirectToAction("Index");
        }
    }
}