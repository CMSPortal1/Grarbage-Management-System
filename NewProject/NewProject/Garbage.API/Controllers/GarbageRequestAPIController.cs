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
    public class GarbageRequestAPIController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();
        [HttpPost]
     public GarabgeRequestServiceDTO GetRequest(GarabgeRequestServiceDTO Request)
        {
            garbage AddNew = new garbage();
            
            AddNew.garbage_id = Request.garbage_id;
            AddNew.Hygiene_level = Request.Hygiene_level;
            AddNew.Comment = Request.Comment;
            AddNew.Weight = Request.Weight;
            AddNew.Cost = Request.Cost;
            AddNew.fk_garbage_type = Request.fk_garbage_type;
            AddNew.created_on= DateTime.Now;
            AddNew.updated_on = DateTime.Now;
            AddNew.fk_user_id = Request.fk_user_id;
          
            db.garbages.Add(AddNew);
            Complaint Com = new Complaint();
            Com.UserName = Request.fk_user_id;
            Com.Address = db.signups.Where(x => x.Signup_ID == AddNew.fk_user_id).Select(x => x.address).FirstOrDefault();     /*Session["address"].ToString();*/
            Com.Mobile_Number = db.signups.Where(x => x.Signup_ID == AddNew.fk_user_id).Select(x => x.phone_no).FirstOrDefault();
            Com.garbage_id = Request.garbage_id;
            Com.Entrydate = DateTime.Now;
            Com.Status = "pending";
            Com.Created_time = DateTime.Now;
            Com.updated_time = DateTime.Now;
            Com.updated_by = db.signups.Where(x => x.Signup_ID == AddNew.fk_user_id).Select(x => x.username).FirstOrDefault();/*Session["UserName"].ToString();*/
            Com.Created_by = db.signups.Where(x => x.Signup_ID == AddNew.fk_user_id).Select(x => x.username).FirstOrDefault();   /* Session["UserName"].ToString();*/
            Com.fk_city_id = db.signups.Where(x => x.Signup_ID == AddNew.fk_user_id).Select(x => x.fk_city_id).FirstOrDefault();
            Com.fk_area_id = db.signups.Where(x => x.Signup_ID == AddNew.fk_user_id).Select(x => x.fk_area_id).FirstOrDefault();

            db.Complaints.Add(Com);
            db.SaveChanges();
            return Request;
            
          }

       [HttpGet]
       public List<GarabgeRequestServiceDTO> GetAllRequest()
        {

            List<garbage> users = db.garbages.ToList();
            var garbages = db.garbages.Include(g => g.signup).Include(g=> g.add_Garbage);
            
            List<GarabgeRequestServiceDTO> lstUserDto = new List<GarabgeRequestServiceDTO>();

            foreach (var item in garbages)
            {
                lstUserDto.Add(Mapper.Map<GarabgeRequestServiceDTO>(item));

            }


            return lstUserDto;
        }

    }
}