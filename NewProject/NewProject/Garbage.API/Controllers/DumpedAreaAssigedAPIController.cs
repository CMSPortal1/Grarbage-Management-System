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
    public class DumpedAreaAssigedAPIController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        [HttpGet]
        public List<AssignDumpedAreaDTO> DumpedAssign(int id)
        {

            List<dumping_detail> users = db.dumping_details.Where(x => x.fk_userid == id).ToList();
            List<AssignDumpedAreaDTO> lstUserDto = new List<AssignDumpedAreaDTO>();

            foreach (var item in users)
            {
                lstUserDto.Add(Mapper.Map<AssignDumpedAreaDTO>(item));

            }


            return lstUserDto;
        }

     

    }
}