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
    public class citiesController : Controller
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        // GET: cities
        public ActionResult Index()
        {
            CityService AllCities = new CityService();
            var Cities = AllCities.GetAllCities();
            return View(Cities);
        }

        // GET: cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            city city = db.cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: cities/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "city_id,city1,updated_on,created_on,updated_by,created_by")] CityDTO city)
        {
           
            if (ModelState.IsValid)
            {
                CityService Addcity = new CityService();
                var City = Addcity.AddCities(city);

                
                return RedirectToAction("Index");
            }

            return View(city);
        }

        // GET: cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            city city = db.cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "city_id,city1,updated_on,created_on,updated_by,created_by")] city city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(city);
        }

        // GET: cities/Delete/5
        public ActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            CityService Addcity = new CityService();
            var DelCity = Addcity.DelCity(id);
            if (DelCity.data == null)
            {
                return HttpNotFound();
            }
            return View(DelCity.data);
        }

        // POST: cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CityService Addcity = new CityService();
            var DelCity = Addcity.DelCity(id);
            Addcity.ConfirmedDelCity(DelCity.data);
            //db.cities.Remove(city);
            //db.SaveChanges();
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
