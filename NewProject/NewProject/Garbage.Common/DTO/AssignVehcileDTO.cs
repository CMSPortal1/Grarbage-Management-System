using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Common.DTO
{
   public class AssignVehcileDTO
    {
        public int VehicleId { get; set; }
        public Nullable<int> fk_Name { get; set; }
        public string Model { get; set; }
        public string image { get; set; }
        public Nullable<int> fk_cityid { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<System.DateTime> Updatedtime { get; set; }
        public string Createdby { get; set; }
        public string updatedby { get; set; }
        public Nullable<int> fk_userid { get; set; }
        public Nullable<int> fk_area_id { get; set; }

    }
}
