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
    public class DumpedAreaController : Controller
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        // GET: DumpedArea
        public ActionResult Index()
        {
            AddDumpedAreaService CreateDumped = new AddDumpedAreaService();
            var GellAll = CreateDumped.GetAllDumpedAreas();
            return View(GellAll);
        }

        

        // GET: DumpedArea/Create
        public ActionResult Create()
        {
            CityService AllCities = new CityService();
            var Cities = AllCities.GetAllCities();
            ViewBag.cityid_fk = new SelectList(Cities, "city_id", "city1");
            return View();
        }
     [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Dumping_id,source,cityid_fk,createdby,updatedby,createdtime,updatedtime,Name")] AddDumpedAreaDTO dumped_area)
        {
            if (ModelState.IsValid)
            {
                AddDumpedAreaService CreateDumped = new AddDumpedAreaService();
                var Add = CreateDumped.AddDumpedArea(dumped_area);
                return RedirectToAction("Index");
            }
            CityService AllCities = new CityService();
            var Cities = AllCities.GetAllCities();
            ViewBag.cityid_fk = new SelectList(Cities, "city_id", "city1", dumped_area.cityid_fk);
            return View(dumped_area);
        }

        //// GET: DumpedArea/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    dumped_area dumped_area = db.dumped_areas.Find(id);
        //    if (dumped_area == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.cityid_fk = new SelectList(db.cities, "city_id", "city1", dumped_area.cityid_fk);
        //    return View(dumped_area);
        //}

      
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Dumping_id,source,cityid_fk,createdby,updatedby,createdtime,updatedtime,Name")] dumped_area dumped_area)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(dumped_area).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.cityid_fk = new SelectList(db.cities, "city_id", "city1", dumped_area.cityid_fk);
        //    return View(dumped_area);
        //}

        //// GET: DumpedArea/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    dumped_area dumped_area = db.dumped_areas.Find(id);
        //    if (dumped_area == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dumped_area);
        //}

        //// POST: DumpedArea/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    dumped_area dumped_area = db.dumped_areas.Find(id);
        //    db.dumped_areas.Remove(dumped_area);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
