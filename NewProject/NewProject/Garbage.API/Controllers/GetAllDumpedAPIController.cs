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
    public class GetAllDumpedAPIController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        [HttpGet]
        public List<AssignDumpedAreaDTO> GetAll()
        {


            List<dumping_detail> users = db.dumping_details.Include(d => d.dumped_area).Include(d => d.signup).ToList();
            List<AssignDumpedAreaDTO> lstUserDto = new List<AssignDumpedAreaDTO>();

            foreach (var item in users)
            {
                lstUserDto.Add(Mapper.Map<AssignDumpedAreaDTO>(item));

            }


            return lstUserDto;
        }
    }
}