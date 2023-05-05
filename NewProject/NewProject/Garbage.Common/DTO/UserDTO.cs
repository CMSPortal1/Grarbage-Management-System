using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Common.DTO
{
   public class UserDTO
    {
        public int Signup_ID { get; set; }
        public Nullable<int> fk_city_id { get; set; }
        public Nullable<int> fk_area_id { get; set; }
        public Nullable<int> fk_role_id { get; set; }
      
        public string username { get; set; }
   
        public string FatherName { get; set; }
      
        public string Email { get; set; }
    
        public string password { get; set; }
      
        public string address { get; set; }
 
        public string phone_no { get; set; }
     
        public string gender { get; set; }
        public string created_by { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> created_on { get; set; }
        public Nullable<System.DateTime> updated_on { get; set; }
        public string image { get; set; }
        public string resetpassword { get; set; }

    }
}
