using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewProject.Models
{
    public class ResetPasswordModel
    {
        [Required (ErrorMessage ="New Password Required", AllowEmptyStrings =false)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        //[DataType(DataType.Password)]
        //[Compare("New Password", ErrorMessage ="New Password and Confirm Password does not match")]
        //public string ConfirmPassword { get; set; }
        [Required]
        public string  ResetCode { get; set; }
    }

}