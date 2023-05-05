using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garbage.Services.implementation;
using NewProject.Models;

namespace NewProject.Controllers
{
    public class AssignDumpedController : Controller
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        // GET: AssignDumped
        public ActionResult Index()
        {
            AssignedDumpedService Assgn = new AssignedDumpedService();
            var All = Assgn.GetAllAreas();
            AccountService UserAccount = new AccountService();
            var users = UserAccount.GetAllUsers();
            ViewBag.fk_user_id = new SelectList(users, "Signup_ID", "username");
            

            //var dumping_details = db.dumping_details.Include(d => d.dumped_area).Include(d => d.signup);
            return View(All);
        }
        public ActionResult AssignDumped()
        {
            AssignedDumpedService Assgn = new AssignedDumpedService();
            int id = Convert.ToInt32(Session["UserId"]);  // current UserId
            var Assign = Assgn.Assignedumped(id);
            return View(Assign);
            
        }
        // GET: AssignDumped/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dumping_detail dumping_detail = db.dumping_details.Find(id);
            if (dumping_detail == null)
            {
                return HttpNotFound();
            }
            return View(dumping_detail);
        }

    
      
        // GET: AssignDumped/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dumping_detail dumping_detail = db.dumping_details.Find(id);
            if (dumping_detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_name = new SelectList(db.dumped_areas, "Dumping_id", "source", dumping_detail.fk_name);
            ViewBag.destination_fk = new SelectList(db.signups, "Signup_ID", "username", dumping_detail.destination_fk);
            return View(dumping_detail);
        }

        // POST: AssignDumped/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dump_area_id,fk_name,source_fk,destination_fk,fk_city_id,created_by,updated_by,created_on,updated_time")] dumping_detail dumping_detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dumping_detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_name = new SelectList(db.dumped_areas, "Dumping_id", "source", dumping_detail.fk_name);
            ViewBag.destination_fk = new SelectList(db.signups, "Signup_ID", "username", dumping_detail.destination_fk);
            return View(dumping_detail);
        }

        // GET: AssignDumped/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dumping_detail dumping_detail = db.dumping_details.Find(id);
            if (dumping_detail == null)
            {
                return HttpNotFound();
            }
            return View(dumping_detail);
        }

        // POST: AssignDumped/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dumping_detail dumping_detail = db.dumping_details.Find(id);
            db.dumping_details.Remove(dumping_detail);
            db.SaveChanges();
            return RedirectToAction("Index");
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
