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
    public class ComplaintsController : Controller
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        // GET: Complaints

        public ActionResult Index()
        {
            ComplaintService Status = new ComplaintService();
           
            var GetStatus = Status.GetAllStatus();
            
           // var complaints = db.Complaints.Include(c => c.garbage).Include(c => c.signup);
           
            return View(GetStatus);

        }

        public ActionResult Status()
        {
           List<ComplaintDTO> Checkstatus = new List<ComplaintDTO>();
           int id = Convert.ToInt32(Session["UserId"]);
            ComplaintService Status = new ComplaintService();
            var GetStatus = Status.GetUserStatus(id);
            return View(GetStatus);
        }

        
       
        // GET: Complaints/Edit/5
        public ActionResult Edit(int id,string SubmitButton)
        {
            //if (int?id == null)
            //{
            //    return new httpstatuscoderesult(httpstatuscode.badrequest);
            //}
            ComplaintService Approvestatus = new ComplaintService();
            var GetAproved = Approvestatus.Approve(id);
            Session["ComId"] = GetAproved.data.Complaint_Id;
            int compalintId = Convert.ToInt32(Session["ComId"]);
            if (GetAproved.data == null)
            {
                return HttpNotFound();
            }
            AccountService UserAccount = new AccountService();
            var users = UserAccount.GetAllUsers();
            ViewBag.UserName = new SelectList(users, "Signup_ID", "username", GetAproved.data.UserName);
          //  ViewBag.garbage_id = new SelectList(db.add_Garbages, "G_id", "G_Type", complaint.garbage.add_Garbage.G_Type);
            return View(GetAproved.data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Complaint_Id,UserName,Address,Status,Entrydate,Completiondate,Created_by,Created_time,updated_by,updated_time,Mobile_Number,garbage_id,pending_at")] ComplaintDTO complaint, string SubmitButton)
        {
            if (ModelState.IsValid)
            {
                string buttonClicked = SubmitButton;
                if (buttonClicked == "Approve")
                {
                    complaint.Status = "Approved";
                    
                    complaint.Completiondate = DateTime.Now;
                   
                 }
                else if(buttonClicked == "Disapprove")
                {
                    complaint.Status = "Rejected";

                    complaint.Completiondate = DateTime.Now;
                }

                ComplaintService Approvestatus = new ComplaintService();
                int id = Convert.ToInt32(Session["ComId"]);
                int UserId = Convert.ToInt32(Session["UserId"]);
                var GetApprove = Approvestatus.Approved(complaint, id);
             
                
                return RedirectToAction("Status");
            }
            AccountService UserAccount = new AccountService();
            var users = UserAccount.GetAllUsers();
            ViewBag.UserName = new SelectList(users, "Signup_ID", "username", complaint.UserName);
            return View(complaint);
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
