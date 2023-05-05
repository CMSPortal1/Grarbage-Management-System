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
    public class AreaAPIController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        [HttpGet]
        public List<AreaDTO> GetAreas()
        {


            List<area> users = db.areas.ToList();
            List<AreaDTO> lstUserDto = new List<AreaDTO>();

            foreach (var item in users)
            {
                lstUserDto.Add(Mapper.Map<AreaDTO>(item));

            }


            return lstUserDto;
        }
        [HttpPost]
        public AreaDTO AddCities(AreaDTO Add)
        {
            area Create = new area();
            Create.area1 = Add.area1;
            Create.cityid = Add.cityid;
            Create.Area_id = Add.Area_id;
            Create.created_on = DateTime.Now;
            Create.updated_time = DateTime.Now;
            Create.created_by = "Admin";
            Create.updated_by = "admin";
            db.areas.Add(Create);
            db.SaveChanges();
            return Add;
        }
      
       public List<AreaDTO> GetAreaByCities(int id)
        {


            List<area> users = db.areas.Where(x => x.cityid == id).ToList();
            List<AreaDTO> lstUserDto = new List<AreaDTO>();

            foreach (var item in users)
            {
                lstUserDto.Add(Mapper.Map<AreaDTO>(item));

            }


            return lstUserDto;
        }
    }
}