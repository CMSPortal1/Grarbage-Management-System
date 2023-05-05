using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Common.DTO
{
   public class AddDumpedAreaDTO
    {
        public int Dumping_id { get; set; }
        public string source { get; set; }
        public Nullable<int> cityid_fk { get; set; }
        public string createdby { get; set; }
        public string updatedby { get; set; }
        public Nullable<System.DateTime> createdtime { get; set; }
        public Nullable<System.DateTime> updatedtime { get; set; }
        public string Name { get; set; }
    }
}
