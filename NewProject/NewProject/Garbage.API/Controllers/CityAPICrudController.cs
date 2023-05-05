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
using Garbage.Common.DTO;
using Garbage.EF;

namespace Garbage.API.Controllers
{
    public class CityAPICrudController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();

        [HttpPost]
        public CityDTO CofirmedDel(CityDTO DelCity)
        {
            city City = new city();
            City.city_id = DelCity.city_id;
            City.city1 = DelCity.city1;
            City.created_by = DelCity.created_by;
            City.updated_by = DelCity.updated_by;
            City.created_on = DelCity.created_on;
            City.updated_on = DelCity.updated_on;
            db.cities.Remove(City);
            db.SaveChanges();
            return DelCity;
        }
        [HttpGet]
        public city DeleteCity(int id)
        {
            city Del = db.cities.Find(id);

            return Del;
        }

    }
}