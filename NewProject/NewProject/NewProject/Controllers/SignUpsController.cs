using Garbage.Common;
using Garbage.Common.DTO;
using Garbage.Common.SendingEmail;
using Garbage.Services.implementation;
using NewProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewProject.Controllers
{
    public class SignUpsController : Controller
    {
        smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();
        // GET: SignUps

  

        public ActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Feedback(FeedbackDTO User)
        {
            AccountService UserRating = new AccountService();
            int id = Convert.ToInt32(Session["UserId"]);
            var rating = UserRating.GetUserProfile(id);

            //signup user = db.signups.FirstOrDefault(u => u.Signup_ID == UserId);
            User.Email = rating.data.Email;
            User.UserID = rating.data.Signup_ID;
            User.CreatedBy = Session["UserName"].ToString();
            User.CreatedTime = DateTime.Now;
            User.UpdatedBy = Session["UserName"].ToString();
            User.UpdatedTime = DateTime.Now;
            FeedBackService SaveResponse = new FeedBackService();
            SaveResponse.UserFeedback(User);
            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(string EmailID)
        {
            //Verify EmailId
            //Generate resest password  link
            //send email
            string message = "";
            bool status = false;

            AccountService VerifyID = new AccountService();
            var Id = VerifyID.ChangePassword(EmailID);
            if (Id.data!= null)
            {
                //send email for reset password
                string resetcode = Guid.NewGuid().ToString();
                var mail = VerifyID.GetAdminEmail();
                GMailer.SenderMail = mail.data.Email;
                GMailer.GmailPassword = mail.data.password;

                GMailer mailer = new GMailer();
                var verifyurl = "/SignUps/ResetPassword/" + resetcode;
                var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyurl);
                mailer.ToEmail = EmailID;
                mailer.Subject = "Reset Password";
                mailer.Body = "We got request for reset your password please click on below link to reset your password" +
                    "<br/><br/><a href=" + link + ">Reset Password link</a> ";
                mailer.IsHtml = true;
                mailer.Send();

                Id.data.resetpassword = resetcode;
                var sent = VerifyID.SendMail(Id.data);
               message = "Reset Password link has been sent to your Email ID";
                //status = false;
            }
            else
            {
                message = "Account not found";
            }
            ViewBag.Message = message;
            return View();
        }
        public ActionResult ResetPassword(string id)
        {
            //verify reset password link
            //find account with this link
            //redirect to new password page

            AccountService VerifyID = new AccountService();
            var Id = VerifyID.ResetPassword(id);
            if (Id.data != null)
            {
                ResetPasswordDTO model = new ResetPasswordDTO();
                model.ResetCode = id;
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }


        [HttpPost]
        public ActionResult ResetPassword(string id, string submit, ResetPasswordDTO model)
        {
            var message = "";
            string buttonClicked = submit;
            if (ModelState.IsValid)
            {
                AccountService VerifyID = new AccountService();
                var Id = VerifyID.ResetPassword(id);
                var user = Id.data;
               
                if (user != null && buttonClicked == "Submit")
                {
                    user.password = model.NewPassword;
                    user.resetpassword = "";
                    var sent = VerifyID.SendMail(user);
                   
                    message = "New Password Updated Successfully";

                }
            }
            else
            {
                message = "Something Invalid";
            }
            ViewBag.Message = message;
            return View(model);
        }

        //public JsonResult CheckingUserEmail(string userdata)
        //{ 
        //    System.Threading.Thread.Sleep(200);
        //    var searchdata = db.signups.Where(z => z.Email == userdata).FirstOrDefault();
        //    if(searchdata!=null)
        //    {
        //        return Json(1);
        //    }
        //    else
        //    {
        //        return Json(0);
        //    }
       // }
    }
}