using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Common.DTO
{
   public class AreaDTO
    {
        public int Area_id { get; set; }
        public string area1 { get; set; }
        public Nullable<System.DateTime> created_on { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> updated_time { get; set; }
        public string updated_by { get; set; }
        public Nullable<int> cityid { get; set; }
    }
}
