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
    public class AllRolesAPIController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();
        [HttpGet]
        public List<RolesDTO> AllUserRoles()
        {
            List<role> users = db.roles.ToList();
            List<RolesDTO> lstUserDto = new List<RolesDTO>();

            foreach (var item in users)
            {
                lstUserDto.Add(Mapper.Map<RolesDTO>(item));

            }


            return lstUserDto;
        }
        [HttpPost]
        public role SaveUserRoles(role User)
        {
            db.Entry(User).State = EntityState.Modified;
            db.SaveChanges();
            return User;
        }
        public role DeleteRoles(int id)
        {
            role Role = db.roles.Find(id);
            return Role;
        }
        [HttpPost]
          public RolesDTO DelRoles(RolesDTO Roles)
        {
            role AddRoles = new role();
            AddRoles.role_id = Roles.role_id;
            AddRoles.Title = Roles.Title;
            AddRoles.created_on = DateTime.Now;
            AddRoles.updated_on = DateTime.Now;
            AddRoles.updated_by = "Admin";
            AddRoles.created_by = "Admin";
            db.roles.Remove(AddRoles);
            db.SaveChanges();
            return Roles;
        }
    
    }
}