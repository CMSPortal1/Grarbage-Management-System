using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Common.DTO
{
   public class AddVehiclesDTO
    {
        public int Vehicle { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<System.DateTime> updatedtime { get; set; }
        public string createdby { get; set; }
        public string updatedby { get; set; }
        public string Model { get; set; }
        public string Image { get; set; }
        public Nullable<int> city { get; set; }
    }
}
