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
    public class areasController : Controller
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        // GET: areas
        public ActionResult Index()
        {
            AreaService GetAreas = new AreaService();
            var Area = GetAreas.GetAllAreas();
            return View(Area);
        }


        // GET: areas/Create
        public ActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Area_id,area1,created_on,created_by,updated_time,updated_by")] AreaDTO area)
        {
            if (ModelState.IsValid)
            {
                AreaService GetAreas = new AreaService();
                var Area = GetAreas.AddArea(area);
                return RedirectToAction("Index");
            }

            return View(area);
        }

        // GET: areas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            area area = db.areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // POST: areas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Area_id,area1,created_on,created_by,updated_time,updated_by")] area area)
        {
            if (ModelState.IsValid)
            {
                db.Entry(area).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(area);
        }

        // GET: areas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            area area = db.areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // POST: areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            area area = db.areas.Find(id);
            db.areas.Remove(area);
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
