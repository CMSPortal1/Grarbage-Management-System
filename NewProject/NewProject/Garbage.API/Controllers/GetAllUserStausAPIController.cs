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
    public class GetAllUserStausAPIController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        [HttpGet]
        public List<ComplaintDTO> GetAll()
        {


            List<Complaint> users = db.Complaints.ToList();
            List<ComplaintDTO> lstUserDto = new List<ComplaintDTO>();

            foreach (var item in users)
            {
                lstUserDto.Add(Mapper.Map<ComplaintDTO>(item));

            }


            return lstUserDto;
        }
    }
}