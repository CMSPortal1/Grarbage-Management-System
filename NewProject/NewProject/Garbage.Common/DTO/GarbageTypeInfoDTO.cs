using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Common.DTO
{
   public class GarbageTypeInfoDTO
    {
        public int G_id { get; set; }
        public string G_Type { get; set; }
        public string Updated_by { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Updated_On { get; set; }
        public Nullable<System.DateTime> Created_on { get; set; }

    }
}
