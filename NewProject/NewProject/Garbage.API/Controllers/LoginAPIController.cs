using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Garbage.Common.DTO;
using Garbage.EF;

namespace Garbage.API.Controllers
{
    public class LoginAPIController : ApiController
    {
        smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();
        [HttpPost]
        public signup UserLogin(UserDTO User)
        {

            var login = db.signups.Where(x => x.Email == User.Email && x.password == User.password).FirstOrDefault();
            return login;
        }

        //[HttpGet]
        //public signup ResetPassword(string EmailID)
        //{
        //    var verifyemail = db.signups.FirstOrDefault(s => s.Email == EmailID);
        //    return verifyemail;
        //}
    }
}