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
    public class ProfilePicAPIController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        [HttpPost]
        public signup ChangeUserPic(signup pic)
        {
            //signup User = new signup();
            
            //User.image = pic.image;
            db.Entry(pic).State = EntityState.Modified;
            db.SaveChanges();
            return pic;
        }
        [HttpGet]
        public List<UserDTO> GetUsers()
        {


            List<signup> users = db.signups.ToList();
            List<UserDTO> lstUserDto = new List<UserDTO>();

            foreach (var item in users)
            {
                lstUserDto.Add(Mapper.Map<UserDTO>(item));

            }


            return lstUserDto;
        }


    }
}