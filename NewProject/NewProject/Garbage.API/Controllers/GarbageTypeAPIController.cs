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
using AutoMapper;
using Garbage.Common.DTO;
using Garbage.EF;

namespace Garbage.API.Controllers
{
    public class GarbageTypeAPIController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        [HttpPost]
        public GarbageTypeInfoDTO AddType(GarbageTypeInfoDTO Add)
        {
            add_Garbage Create = new add_Garbage();
            Create.G_id = Add.G_id;
            Create.G_Type = Add.G_Type;
            Create.Created_on = DateTime.Now;
            Create.Updated_On = DateTime.Now;
            Create.Updated_by = "Admin";
            Create.Created_By = "Admin";
            db.add_Garbages.Add(Create);
            db.SaveChanges();
            return Add;
        }
        [HttpGet]
        public add_Garbage Edit(int id)
        {
            add_Garbage edit = db.add_Garbages.Find(id);
            return edit;
        }

        [HttpPost]
        public add_Garbage SaveData(add_Garbage User)
        {
            db.Entry(User).State = EntityState.Modified;
            db.SaveChanges();
            return User;
        }
        [HttpPost]
        public add_Garbage DelType(add_Garbage User)
        {
            db.add_Garbages.Remove(User);
            db.SaveChanges();
            return User;
        }

    }
}