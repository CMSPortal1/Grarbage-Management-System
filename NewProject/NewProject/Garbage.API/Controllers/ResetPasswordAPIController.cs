using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Garbage.Common.DTO;
using Garbage.Common.SendingEmail;
using Garbage.EF;

namespace Garbage.API.Controllers
{
    public class ResetPasswordAPIController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        [HttpGet]
        public signup ChangePass(string Email)
        {
            var verifyemail = db.signups.FirstOrDefault(s => s.Email == Email);
       
            return verifyemail;
        }

        [HttpGet]
        public signup GetEmail()
        {

            var Mail = db.signups.Where(s => s.Signup_ID == 1039 && s.fk_role_id == 7).FirstOrDefault();
            return Mail;
        }

        [HttpPost]
        public signup SendEmail(signup SendMail)
        {
            db.Entry(SendMail).State = EntityState.Modified;
            db.SaveChanges();
            return SendMail;
        }
            
      
    }

}