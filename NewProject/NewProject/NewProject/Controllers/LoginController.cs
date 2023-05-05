using NewProject.Models;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Helpers;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using Garbage.Services.implementation;
using Garbage.Common;
using Garbage.Common.DTO;
using Garbage.Common.SendingEmail;

namespace NewProject.Controllers
{
    public class LoginController : Controller
    {
        smart_garbage_management_systemEntities db = new smart_garbage_management_systemEntities();
        // GET: Login

        //public ActionResult ProfileDetail(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    signup signup = db.signups.Find(id);
        //    if (signup == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(signup);
        //}
        public ActionResult Index()
        {
            List<city> citylist = db.cities.ToList();
            List<area> arealist = db.areas.ToList();
            ViewBag.city = new SelectList(citylist, "city_id", "city1");
            ViewBag.area = new SelectList(arealist, "Area_id", "area1");
            return View();
        }
      [HttpGet]
        public ActionResult AllUsers()

        {
            AccountService UserAccount = new AccountService();
            var users = UserAccount.GetAllUsers();
            return View(users);
        }
    


      
        public ActionResult SignIn()
        {
          
            return View();
          
        }
        

        [HttpPost]
        public ActionResult SignIn(UserDTO userlogin)
        {
            AccountService UserAccount = new AccountService();
            
            var userdetails = UserAccount.Login(userlogin);


            Session["UserId"] = userdetails.data.Signup_ID;
            Session["Email"] = userdetails.data.Email;
            Session["UserName"] =userdetails.data.username;
            Session["address"] = userdetails.data.address;
            Session["phone"] = userdetails.data.phone_no;
            Session["image"] = userdetails.data.image;
            Session["roleid"] = userdetails.data.fk_role_id;
            if (userdetails != null && userdetails.data.fk_role_id==8)   
            {
                return RedirectToAction("Create", "garbages1");
            }
          else 
            {
                
                    return RedirectToAction("Index", "Complaints");
                
            }
            
        }

        [HttpGet]
        public JsonResult GetAreasByCity(string cityid)      //Get Cities 
        {
           AreaService GetAreas = new AreaService();
            int id = Convert.ToInt32(cityid);
            Session["cityid"] = id;
            var Area = GetAreas.GetAreasbyCities(id);
            return Json(Area, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult SignUp()
        {
            TempData["error"] = "";

            RolesService CreateRoles = new RolesService();
            var Roles = CreateRoles.AllRoles();
            ViewBag.fk_role_id = new SelectList(Roles, "role_id", "Title");
            CityService AllCities = new CityService();
            var Cities = AllCities.GetAllCities();
            ViewBag.city = Cities;
            return View();
        }
        [HttpPost]
        public ActionResult SignUp([Bind(Include = "Signup_ID,fk_city_id,fk_area_id,fk_role_id,username,FatherName,Email,password,address,phone_no,gender,created_by,updated_by,created_on,updated_on")] UserDTO userDto)

        {
            var message = "";
            AccountService UserAccount = new AccountService();
         
            if (ModelState.IsValid)
            {
                UserAccount.SignIn(userDto);
                
                 // Sending confirmation message to user
              try
                {
                   

                    var mail = UserAccount.GetAdminEmail();
                    GMailer.SenderMail = mail.data.Email;
                    GMailer.GmailPassword = mail.data.password;
                    

                    GMailer mailer = new GMailer();
                    mailer.ToEmail = userDto.Email;
                    mailer.Subject = "Verify your email id";
                    mailer.Body = "Thanks for Registering your account.";
                    mailer.IsHtml = true;
                    mailer.Send();
                    message = "Thanks for Registering your account.";
                }
                catch (Exception)
                {
                    message = "Error while sending email to user";
                    ViewBag.Message = message;
                    return View();
                }
               
                return RedirectToAction("SignIn");

            }
            RolesService CreateRoles = new RolesService();
            var Roles = CreateRoles.AllRoles();
            ViewBag.fk_role_id = new SelectList(Roles, "role_id", "Title");
            CityService AllCities = new CityService();
            var Cities = AllCities.GetAllCities();
            ViewBag.city = Cities;
            return View(userDto);
        }

        public string UploadImages(HttpPostedFileBase file)
        {
            {
                
                string ImageUrl = null;

                if (file != null)
                {
                   string ext = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                    string weburl = "~/Content/photos/" + DateTime.Now.Ticks + "_"+ext;
                    string physicalPath = Request.MapPath(weburl);
                    file.SaveAs(physicalPath);
                    string RelativePath = weburl.Replace("/", @"\");
                    ImageUrl = RelativePath.Remove(0, 1);
                    return ImageUrl;
                
                } 
            }

            return "";
        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            AccountService UserProfile = new AccountService();
            int id = Convert.ToInt32(Session["UserId"]);
           // var profile = db.signups.Single(x => x.Signup_ID == id);
            var profileView = UserProfile.GetUserProfile(id);
            return View(profileView.data);
           // return View();

        }

       [HttpPost]
        public ActionResult EditProfile( HttpPostedFileBase file, string PicUpload)
        {
            string buttonClicked = PicUpload;
            AccountService UserProfile = new AccountService();
            int id = Convert.ToInt32(Session["UserId"]);
            var profileView = UserProfile.GetUserProfile(id);
            var user =profileView.data;      
            if (buttonClicked == "Upload")
            {
               
                string ext = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                string weburl = "~/Content/photos/" + DateTime.Now.Ticks + "_" + ext;
                user.image = UploadImages(file);

            }
           
            var UserPic = UserProfile.ChangePic(user);
            Session["image"] = UserPic.data.image;
            return RedirectToAction("EditProfile");

        }

        //Define Errors
        public ActionResult NotFound()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Errorshow()
        {
            return View();
        }
    }
    }