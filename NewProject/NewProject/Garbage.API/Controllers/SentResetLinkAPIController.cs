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
using Garbage.EF;

namespace Garbage.API.Controllers
{
    public class SentResetLinkAPIController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        [HttpGet]
        public signup ResetPass(string id)
        {
            var users = db.signups.Where(x => x.resetpassword == id).FirstOrDefault();
            return users;
        }
    }
}