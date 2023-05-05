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
    public class GetAllGarbageTypeAPIController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

       [HttpGet]
        public List<GarbageTypeInfoDTO> GetAll()
        {
            List<add_Garbage> users = db.add_Garbages.ToList();
            // var garbages = db.garbages.Include(g => g.signup).Include(g => g.add_Garbage);

            List<GarbageTypeInfoDTO> lstUserDto = new List<GarbageTypeInfoDTO>();

            foreach (var item in users)
            {
                lstUserDto.Add(Mapper.Map<GarbageTypeInfoDTO>(item));

            }


            return lstUserDto;
        }
    }
}