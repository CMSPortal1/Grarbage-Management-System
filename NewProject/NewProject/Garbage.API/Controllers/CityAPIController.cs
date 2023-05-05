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
    public class CityAPIController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();
        [HttpGet]
        public List<CityDTO> GetCities()
        {


            List<city> users = db.cities.ToList();
            List<CityDTO> lstUserDto = new List<CityDTO>();

            foreach (var item in users)
            {
                lstUserDto.Add(Mapper.Map<CityDTO>(item));

            }


            return lstUserDto;
        }
        [HttpPost]
        public CityDTO AddCities(CityDTO Add)
        {
            city Create = new city();
            Create.city1 = Add.city1;
            Create.city_id = Add.city_id;
            Create.created_on = DateTime.Now;
            Create.updated_on = DateTime.Now;
            Create.created_by = "Admin";
            Create.updated_by = "admin";
            db.cities.Add(Create);
            db.SaveChanges();
            return Add;
        }
        //public city DeleteCity(int id)
        //{
        //    city Del = db.cities.Find(id);
            
        //    return Del;
        //}
        //public CityDTO CofirmedDel(CityDTO DelCity)
        //{
        //    city City = new city();
        //    City.city_id = DelCity.city_id;
        //    City.city1 = DelCity.city1;
        //    City.created_by = DelCity.created_by;
        //    City.updated_by = DelCity.updated_by;
        //    City.created_on = DelCity.created_on;
        //    City.updated_on = DelCity.updated_on;
        //    db.cities.Remove(City);
        //    db.SaveChanges();
        //    return DelCity;
        //}
    }
}