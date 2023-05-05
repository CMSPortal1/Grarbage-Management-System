using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Common.DTO
{
   public class AssignDumpedAreaDTO
    {
        public int dump_area_id { get; set; }
        public Nullable<int> fk_name { get; set; }
        public string source_fk { get; set; }
        public string destination_fk { get; set; }
        public Nullable<int> fk_city_id { get; set; }
        public string created_by { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> created_on { get; set; }
        public Nullable<System.DateTime> updated_time { get; set; }
        public Nullable<int> fk_userid { get; set; }
        public Nullable<int> fk_area_id { get; set; }
    }
}
