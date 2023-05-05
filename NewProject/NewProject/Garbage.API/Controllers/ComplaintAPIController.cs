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
    public class ComplaintAPIController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        [HttpGet]
        public List<ComplaintDTO> GetStatus(int id)
        {

            List<Complaint> users = db.Complaints.Where(x => x.UserName == id).ToList();
            List<ComplaintDTO> lstUserDto = new List<ComplaintDTO>();

            foreach (var item in users)
            {
                lstUserDto.Add(Mapper.Map<ComplaintDTO>(item));

            }


            return lstUserDto;
        }
        
        public Complaint ApproveStatus(int id)
        {
            Complaint Status = db.Complaints.Find(id);
            return Status;
        }

    }
}