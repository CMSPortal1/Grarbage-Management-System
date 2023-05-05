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
    public class AssignVehicleAPIController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

       public List<AssignVehcileDTO> GetAssign(int id)
        {
            List<vehiclesdetail> users = db.vehiclesdetails.Where(x => x.fk_userid == id).ToList();
            List<AssignVehcileDTO> lstUserDto = new List<AssignVehcileDTO>();

            foreach (var item in users)
            {
                lstUserDto.Add(Mapper.Map<AssignVehcileDTO>(item));

            }


            return lstUserDto;
        }
    }
}