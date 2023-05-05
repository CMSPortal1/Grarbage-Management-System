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
    public class vehiclesdetailsController : Controller
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();
         public ActionResult AssignVehicles()
        {
            AssignedVehicleService GetVehicle = new AssignedVehicleService();
            int id = Convert.ToInt32(Session["UserId"]);// current UserId
            var Vehicle = GetVehicle.AssignVehicle(id);
           
            //var Vehicle = GetVehicle.VehicleAssigned(id);

            //var check = db.vehiclesdetails.Where(x => x.fk_userid == CurrentUserId).ToList();
            return View(Vehicle);
        }
       // GET: vehiclesdetails
        //public ActionResult Index()
        //{
        //    var vehiclesdetails = db.vehiclesdetails.Include(v => v.AddVehicle).Include(v => v.city).Include(v => v.signup);
        //    return View(vehiclesdetails.ToList());
        //}

        //// GET: vehiclesdetails/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    vehiclesdetail vehiclesdetail = db.vehiclesdetails.Find(id);
        //    if (vehiclesdetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehiclesdetail);
        //}

      
      
        //// GET: vehiclesdetails/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    vehiclesdetail vehiclesdetail = db.vehiclesdetails.Find(id);
        //    if (vehiclesdetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.fk_Name = new SelectList(db.AddVehicles, "Vehicle", "createdby", vehiclesdetail.fk_Name);
        //    ViewBag.areaID = new SelectList(db.areas, "Area_id", "area1", vehiclesdetail.fk_cityid);
        //    ViewBag.fk_userid = new SelectList(db.signups, "Signup_ID", "username", vehiclesdetail.fk_userid);
        //    return View(vehiclesdetail);
        //}

   
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "VehicleId,fk_Name,Model,image,areaID,CreatedTime,Updatedtime,Createdby,updatedby,fk_userid")] vehiclesdetail vehiclesdetail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(vehiclesdetail).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.fk_Name = new SelectList(db.AddVehicles, "Vehicle", "createdby", vehiclesdetail.fk_Name);
        //    ViewBag.areaID = new SelectList(db.areas, "Area_id", "area1", vehiclesdetail.fk_cityid);
        //    ViewBag.fk_userid = new SelectList(db.signups, "Signup_ID", "username", vehiclesdetail.fk_userid);
        //    return View(vehiclesdetail);
        //}
    }
}
