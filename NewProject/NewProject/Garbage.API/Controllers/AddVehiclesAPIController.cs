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
    public class AddVehiclesAPIController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        [HttpGet]
        public List<AddVehiclesDTO> GetVehicles()
        {


            List<AddVehicle> users = db.AddVehicles.ToList();
            List<AddVehiclesDTO> lstUserDto = new List<AddVehiclesDTO>();

            foreach (var item in users)
            {
                lstUserDto.Add(Mapper.Map<AddVehiclesDTO>(item));

            }


            return lstUserDto;
        }

        [HttpPost]
        public AddVehiclesDTO AddNewVehicle(AddVehiclesDTO Add)
        {
            AddVehicle Create = new AddVehicle();
            Create.Vehicle = Add.Vehicle;
            Create.Name = Add.Name;
            Create.Model = Add.Model;
            Create.city = Add.city;
            Create.Image = Add.Image;
            Create.CreatedTime = DateTime.Now;
            Create.updatedtime = DateTime.Now;
            Create.createdby = "Admin";
            Create.updatedby = "admin";
            db.AddVehicles.Add(Create);
            db.SaveChanges();
            return Add;
        }
    }
}