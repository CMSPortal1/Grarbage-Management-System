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

    public class add_GarbageController : Controller
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();
        public ActionResult Index()
        {
            GarbageTypeInfoService Save = new GarbageTypeInfoService();
            var Saved = Save.GetAllTypes();
            return View(Saved);
        }
        // GET: add_Garbage/Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "G_id,G_Type,Updated_by,Created_By,Updated_On,Created_on")] GarbageTypeInfoDTO add_Garbage)
        {
            if (ModelState.IsValid)
            {
                var message = "";
                GarbageTypeInfoService Save = new GarbageTypeInfoService();
                 var Saved = Save.AddType(add_Garbage);
                 Session["G_Type"] = Saved.data.G_id;
                message = "Data has been inserted Successfully";
                ViewBag.Message = message;
                return RedirectToAction("Create");

              
            }

            return View(add_Garbage);
        }

        // GET: add_Garbage/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            GarbageTypeInfoService Save = new GarbageTypeInfoService();
            
             var edit=  Save.EditType(id);
            if (edit.data == null)
            {
                return HttpNotFound();
            }
            return View(edit.data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "G_id,G_Type,Updated_by,Created_By,Updated_On,Created_on")] GarbageTypeInfoDTO add_Garbage)
        {
            if (ModelState.IsValid)
            {
                GarbageTypeInfoService Save = new GarbageTypeInfoService();
                var Edited=Save.SaveType(add_Garbage);
                return RedirectToAction("Index");
            }
            return View(add_Garbage);
        }

        // GET: add_Garbage/Delete/5
        public ActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //add_Garbage add_Garbage = db.add_Garbages.Find(id);
            GarbageTypeInfoService Save = new GarbageTypeInfoService();

            var edit = Save.EditType(id);
            if (edit.data == null)
            {
                return HttpNotFound();
            }
            return View(edit.data);
        }

        // POST: add_Garbage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GarbageTypeInfoService Save = new GarbageTypeInfoService();
            var edit = Save.EditType(id);
            var Del=Save.ConfirmedDel(edit.data);
            return RedirectToAction("Create");
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
