using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Common.DTO
{
 public class GarabgeRequestServiceDTO
    {

        public int garbage_id { get; set; }
        public int fk_user_id { get; set; }
        public string Hygiene_level { get; set; }
        public string Comment { get; set; }
        public string created_by { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> created_on { get; set; }
        public Nullable<System.DateTime> updated_on { get; set; }
        public Nullable<int> Cost { get; set; }
        public Nullable<int> Weight { get; set; }
        public Nullable<int> fk_garbage_type { get; set; }
    }
}
