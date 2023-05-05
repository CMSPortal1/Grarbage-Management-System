using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garbage.Common.DTO;
using Garbage.Services.implementation;
using NewProject.Models;

namespace NewProject.Controllers
{
    public class garbages1Controller : Controller
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        // GET: garbages1
        
        public ActionResult Index()
        {

            GarbageRequestService GetRequests = new GarbageRequestService();
            var UserReq = GetRequests.GetAllRequests();
            //var garbages = db.garbages.Include(g => g.signup).Include(g=> g.add_Garbage);
           
            return View(UserReq);
        }

        // GET: garbages1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            garbage garbage = db.garbages.Find(id);
            if (garbage == null)
            {
                return HttpNotFound();
            }
            return View(garbage);
        }

        // GET: garbages1/Create
        public ActionResult Create()
        {

            AccountService UserAccount = new AccountService();
            var users = UserAccount.GetAllUsers();
            GarbageTypeInfoService Save = new GarbageTypeInfoService();
            var Saved = Save.GetAllTypes();
            ViewBag.fk_garbageName = new SelectList(Saved, "G_id", "G_Type");
            ViewBag.fk_user_id = new SelectList(users, "Signup_ID", "username");

            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "garbage_id,garbage_type,fk_user_id,Hygiene_level,Comment,created_by,updated_by,created_on,updated_on,Cost,Weight,fk_garbageName")]  GarabgeRequestServiceDTO garbage)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Session["UserId"]);
                garbage.fk_user_id = id;
                garbage.created_on = DateTime.Now;
                garbage.updated_on = DateTime.Now;
                garbage.created_by = Session["UserName"].ToString();
                garbage.updated_by = Session["UserName"].ToString();
                GarbageRequestService GarbageService = new GarbageRequestService();
                var GetRequest = GarbageService.UserRequest(garbage);
                var GetData = GetRequest.data;

                Session["GarbageID"] = GetData.garbage_id;
                int LatestGarbageId = Convert.ToInt32(Session["GarbageID"]);
                return RedirectToAction("Status","Complaints");
            }
            AccountService UserAccount = new AccountService();
            var users = UserAccount.GetAllUsers();
            GarbageTypeInfoService Save = new GarbageTypeInfoService();
            var Saved = Save.GetAllTypes();
            ViewBag.fk_user_id = new SelectList(users, "Signup_ID", "username", garbage.fk_user_id);
            ViewBag.fk_garbageName = new SelectList(Saved, "G_id", "G_Type", garbage.fk_garbage_type);
            return View(garbage);
        }

        // GET: garbages1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            garbage garbage = db.garbages.Find(id);
            if (garbage == null)
            {
                return HttpNotFound();
            }
            AccountService UserAccount = new AccountService();
            var users = UserAccount.GetAllUsers();
            ViewBag.fk_user_id = new SelectList(users, "Signup_ID", "username", garbage.fk_user_id);
            return View(garbage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "garbage_id,garbage_type,fk_user_id,Hygiene_level,Comment,created_by,updated_by,created_on,updated_on")] garbage garbage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garbage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            AccountService UserAccount = new AccountService();
            var users = UserAccount.GetAllUsers();
            ViewBag.fk_user_id = new SelectList(users, "Signup_ID", "username", garbage.fk_user_id);
            return View(garbage);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
