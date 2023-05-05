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
using AutoMapper;
using Garbage.Common;
using Garbage.Common.DTO;
using System.Web.SessionState;
using System.Web;
using Garbage.Common.SendingEmail;

namespace Garbage.API.Controllers
{
    public class signupsAPIController : ApiController
    {
        smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        // GET: api/signupsAPI     
        //[HttpGet]
        //public List<UserDTO> GetUsers()
        //{


        //    List<signup> users = db.signups.ToList();
        //    List<UserDTO> lstUserDto = new List<UserDTO>();

        //    foreach (var item in users)
        //    {
        //        lstUserDto.Add(Mapper.Map<UserDTO>(item));

        //    }


        //    return lstUserDto;
        //}
        [HttpPost]
        public UserDTO AddUser(UserDTO userDto)
        {
            signup User = new signup();
            User.username = userDto.username;
            User.FatherName = userDto.FatherName;
            User.password = userDto.password;
            User.Email = userDto.Email;
            User.address = userDto.address;
            User.phone_no = userDto.phone_no;
            User.gender = userDto.gender;
            User.fk_area_id = userDto.fk_area_id;
            User.fk_city_id = userDto.fk_city_id;
            User.fk_role_id = userDto.fk_role_id;
            User.created_on = DateTime.Now;
            User.updated_on = DateTime.Now;
            User.created_by = userDto.username;
            User.updated_by = userDto.username;

            db.signups.Add(User);
            db.SaveChanges();
          
            return userDto;
        }


        [HttpGet]
        public signup GetProfile(int id)
        {

            var profile = db.signups.Single(x => x.Signup_ID == id);
            
            return profile;
        }

    }
} 
       
