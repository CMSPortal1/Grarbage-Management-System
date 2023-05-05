using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewProject.Models
{
    public class Users
    {
        public string username { get; set; }
        public string FatherName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string phone_no { get; set; }
        public string resetpassword { get; set; }
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(" Password", ErrorMessage = "New Password and Confirm Password does not match")]

        public string ConfirmPassword { get; set; }
    }
}