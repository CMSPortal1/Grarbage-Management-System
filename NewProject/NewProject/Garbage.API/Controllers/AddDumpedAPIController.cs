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
    public class AddDumpedAPIController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();
        public AddDumpedAreaDTO AddDumpedArea(AddDumpedAreaDTO Create)
        {
            dumped_area Add = new dumped_area();
            Add.Dumping_id = Create.Dumping_id;
            Add.source = Create.source;
            Add.cityid_fk = Create.cityid_fk;
            Add.Name = Create.Name;
            Add.createdby = "Admin";
            Add.updatedby = "Admin";
            Add.createdtime = DateTime.Now;
            Add.updatedtime = DateTime.Now;
            db.dumped_areas.Add(Add);
            db.SaveChanges();
            return Create;
        }
        [HttpGet]
        public List<AddDumpedAreaDTO> GetAllDump()
        {


            List<dumped_area> users = db.dumped_areas.Include(d => d.city).ToList();
            List<AddDumpedAreaDTO> lstUserDto = new List<AddDumpedAreaDTO>();

            foreach (var item in users)
            {
                lstUserDto.Add(Mapper.Map<AddDumpedAreaDTO>(item));

            }


            return lstUserDto;
        }


    } 
}