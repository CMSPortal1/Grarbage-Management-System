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
    public class ApproveStatusAPIController : ApiController
    {
        private smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();


        [HttpGet]
        public Complaint ApproveStatus(int id)
        {
            Complaint Status = db.Complaints.Find(id);
            return Status;
        }

        [HttpPost]
        public Complaint RequestApproved(Complaint UserRequest, int id)
        {

            db.Entry(UserRequest).State = EntityState.Modified;
            vehiclesdetail assign = new vehiclesdetail();
            dumping_detail dumped = new dumping_detail();

            assign.fk_cityid = db.Complaints.Where(x => x. Complaint_Id== id).Select(x => x.fk_city_id).FirstOrDefault();
            assign.fk_area_id = db.Complaints.Where(x => x.Complaint_Id == id).Select(x => x.fk_area_id).FirstOrDefault();
            var city = assign.fk_cityid;
            var area = assign.fk_area_id;
            if (assign.fk_cityid == 5 && assign.fk_area_id == 4 || assign.fk_area_id == 6)
            {
                assign.fk_Name = db.AddVehicles.Where(x => x.Name == "Garbage Truck" || x.Name == "Pickup").Select(x => x.Vehicle).FirstOrDefault();
                assign.Model = db.AddVehicles.Where(x => x.Name == "Garbage Truck" || x.Name == "Pickup").Select(x => x.Model).FirstOrDefault();
                assign.image = db.AddVehicles.Where(x => x.Name == "Garbage Truck" || x.Name == "Pickup").Select(x => x.Image).FirstOrDefault();
                dumped.fk_name = db.dumped_areas.Where(x => x.Name == "Mehmood Booti Open Dump").Select(x => x.Dumping_id).FirstOrDefault();
                dumped.destination_fk = db.dumped_areas.Where(x => x.Name == "Mehmood Booti Open Dump").Select(x => x.source).FirstOrDefault();


            }
            else if (assign.fk_cityid == 5 && assign.fk_area_id == 5 || assign.fk_area_id == 7 || assign.fk_area_id == 8)
            {
                assign.fk_Name = db.AddVehicles.Where(x => x.Name == "Pickup").Select(x => x.Vehicle).FirstOrDefault();
                assign.Model = db.AddVehicles.Where(x => x.Name == "Pickup").Select(x => x.Model).FirstOrDefault();
                assign.image = db.AddVehicles.Where(x => x.Name == "Pickup").Select(x => x.Image).FirstOrDefault();
                dumped.fk_name = db.dumped_areas.Where(x => x.Name == " Lakho Dahar").Select(x => x.Dumping_id).FirstOrDefault();
                dumped.destination_fk = db.dumped_areas.Where(x => x.Name == "Lakho Dahar").Select(x => x.source).FirstOrDefault();
            }
            if (assign.fk_cityid == 6)
            {
                assign.fk_Name = db.AddVehicles.Where(x => x.Name == "Bin Wagon").Select(x => x.Vehicle).FirstOrDefault();
                assign.Model = db.AddVehicles.Where(x => x.Name == "Bin Wagon").Select(x => x.Model).FirstOrDefault();
                assign.image = db.AddVehicles.Where(x => x.Name == "Bin Wagon").Select(x => x.Image).FirstOrDefault();
                if (assign.fk_area_id == 9)
                {
                    dumped.fk_name = db.dumped_areas.Where(x => x.Name == " Surjani Town’s Jam Chakhro ").Select(x => x.Dumping_id).FirstOrDefault();
                    dumped.destination_fk = db.dumped_areas.Where(x => x.Name == "Surjani Town’s Jam Chakhro ").Select(x => x.source).FirstOrDefault();
                }
                else if (assign.fk_area_id == 10)
                {
                    dumped.fk_name = db.dumped_areas.Where(x => x.Name == " Deh Gondal Pass").Select(x => x.Dumping_id).FirstOrDefault();
                    dumped.destination_fk = db.dumped_areas.Where(x => x.Name == "Deh Gondal Pass").Select(x => x.source).FirstOrDefault();
                }
            }

            if (assign.fk_cityid == 7)

            {
                assign.fk_Name = db.AddVehicles.Where(x => x.Name == "dustbin lorry").Select(x => x.Vehicle).FirstOrDefault();
                assign.Model = db.AddVehicles.Where(x => x.Name == "dustbin lorry").Select(x => x.Model).FirstOrDefault();
                assign.image = db.AddVehicles.Where(x => x.Name == "dustbin lorry").Select(x => x.Image).FirstOrDefault();
                if (assign.fk_area_id == 11 || assign.fk_area_id == 13)
                {
                    dumped.fk_name = db.dumped_areas.Where(x => x.Name == "Hazar Khwani").Select(x => x.Dumping_id).FirstOrDefault();
                    dumped.destination_fk = db.dumped_areas.Where(x => x.Name == "Hazar Khwani").Select(x => x.source).FirstOrDefault();
                }
                else if (assign.fk_area_id == 12)
                {
                    dumped.fk_name = db.dumped_areas.Where(x => x.Name == "Lundi Akhune Ahmed").Select(x => x.Dumping_id).FirstOrDefault();
                    dumped.destination_fk = db.dumped_areas.Where(x => x.Name == "Lundi Akhune Ahmed").Select(x => x.source).FirstOrDefault();
                }
            }


            if (assign.fk_cityid == 8)
            {
                assign.fk_Name = db.AddVehicles.Where(x => x.Name == "DustCart").Select(x => x.Vehicle).FirstOrDefault();
                assign.Model = db.AddVehicles.Where(x => x.Name == "DustCart").Select(x => x.Model).FirstOrDefault();
                assign.image = db.AddVehicles.Where(x => x.Name == "DustCart").Select(x => x.Image).FirstOrDefault();
                if (assign.fk_area_id == 14)
                {
                    dumped.fk_name = db.dumped_areas.Where(x => x.Name == "I-12" || x.Name == "H-10").Select(x => x.Dumping_id).FirstOrDefault();
                    dumped.destination_fk = db.dumped_areas.Where(x => x.Name == "I-12" || x.Name == "H-10").Select(x => x.source).FirstOrDefault();
                }
                else if (assign.fk_area_id == 15)
                {
                    dumped.fk_name = db.dumped_areas.Where(x => x.Name == "H-10").Select(x => x.Dumping_id).FirstOrDefault();
                    dumped.destination_fk = db.dumped_areas.Where(x => x.Name == "H-10").Select(x => x.source).FirstOrDefault();
                }
            }

            assign.fk_userid = db.Complaints.Where(x => x.Complaint_Id == id).Select(x => x.UserName).FirstOrDefault();
            assign.Createdby = "Admin";
            assign.updatedby = "Admin";
            assign.CreatedTime = DateTime.Now;
            assign.Updatedtime = DateTime.Now;
            db.vehiclesdetails.Add(assign);
            dumped.source_fk = db.signups.Where(x => x.fk_city_id == assign.fk_cityid).Select(x => x.address).FirstOrDefault();
            dumped.fk_area_id = area;
            dumped.fk_city_id = city;
            dumped.fk_userid = db.Complaints.Where(x => x.Complaint_Id == id).Select(x => x.UserName).FirstOrDefault();
            dumped.created_on = DateTime.Now;
            dumped.updated_time = DateTime.Now;
            dumped.created_by = "Admin";
            dumped.updated_by = "Admin";
            db.dumping_details.Add(dumped);
            db.SaveChanges();
            return UserRequest;
        }

  
    }
}