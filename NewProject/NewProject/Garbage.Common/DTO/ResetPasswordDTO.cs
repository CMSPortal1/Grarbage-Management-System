﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Common.DTO
{
   public class ResetPasswordDTO
    {
        [Required(ErrorMessage = "New Password Required", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        public string ResetCode { get; set; }
    }
}
