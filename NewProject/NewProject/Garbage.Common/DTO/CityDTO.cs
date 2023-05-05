using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Common.DTO
{
   public class CityDTO
    {
        public int city_id { get; set; }
        public string city1 { get; set; }
        public Nullable<System.DateTime> updated_on { get; set; }
        public Nullable<System.DateTime> created_on { get; set; }
        public string updated_by { get; set; }
        public string created_by { get; set; }
    }
}
