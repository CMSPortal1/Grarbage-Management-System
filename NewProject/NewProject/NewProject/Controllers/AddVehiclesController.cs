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
   
    public class AddVehiclesController : Controller
    {
        
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();
   
        // GET: AddVehicles
        //public ActionResult vehicletabs()
        //{
        //    return View();
        //}
        public ActionResult Index()
        {
            AddVehicleService AllVehicles = new AddVehicleService();
            var Vehicles = AllVehicles.GetAllVehicles();
            return View(Vehicles);
        }

        // GET: AddVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddVehicle addVehicle = db.AddVehicles.Find(id);
            if (addVehicle == null)
            {
                return HttpNotFound();
            }
            return View(addVehicle);
        }


       
        // GET: AddVehicles/Create
        public ActionResult Create()
        {
            CityService AllCities = new CityService();
            var Cities = AllCities.GetAllCities();
            ViewBag.cityid_fk = new SelectList(Cities, "city_id", "city1");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Create([Bind(Include = "Vehicle,Name,CreatedTime,updatedtime,createdby,updatedby,Model,Image")] AddVehiclesDTO addVehicle, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                addVehicle.Image = UploadImages(file);
                AddVehicleService AllVehicles = new AddVehicleService();
                var Vehicles = AllVehicles.AddVehicle(addVehicle);
                //addVehicle.CreatedTime = DateTime.Now;
                //addVehicle.createdby = "ADMIN";
                //addVehicle.updatedtime = DateTime.Now;
                //addVehicle.updatedby = "ADMIN";
                //db.AddVehicles.Add(addVehicle);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            CityService AllCities = new CityService();
            var Cities = AllCities.GetAllCities();
            ViewBag.cityid_fk = new SelectList(Cities, "city_id", "city1", addVehicle.city);
            return View(addVehicle);
        }

        public string UploadImages(HttpPostedFileBase file)
        {
            string ImageUrl = null;
                if (file != null)
                {
                       string ext = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                        string weburl = "~/Content/photos/" + DateTime.Now.Ticks + "_"  + ext;
                        string physicalPath = Request.MapPath(weburl);
                        file.SaveAs(physicalPath);
                        string RelativePath = weburl.Replace("/", @"\");
                        ImageUrl = RelativePath.Remove(0, 1);
                        return ImageUrl;
                    
                }
            
            return "";
        }
// GET: AddVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddVehicle addVehicle = db.AddVehicles.Find(id);
            if (addVehicle == null)
            {
                return HttpNotFound();
            }
            return View(addVehicle);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vehicle,Name,CreatedTime,updatedtime,createdby,updatedby,Model,Image")] AddVehicle addVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addVehicle);
        }

        // GET: AddVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddVehicle addVehicle = db.AddVehicles.Find(id);
            if (addVehicle == null)
            {
                return HttpNotFound();
            }
            return View(addVehicle);
        }

        // POST: AddVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddVehicle addVehicle = db.AddVehicles.Find(id);
            db.AddVehicles.Remove(addVehicle);
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
