using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Common.DTO
{
   public class ComplaintDTO
    {
        public int Complaint_Id { get; set; }
        public Nullable<int> UserName { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> Entrydate { get; set; }
        public Nullable<System.DateTime> Completiondate { get; set; }
        public string Created_by { get; set; }
        public Nullable<System.DateTime> Created_time { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_time { get; set; }
        public string Mobile_Number { get; set; }
        public Nullable<int> garbage_id { get; set; }
        public Nullable<int> pending_at { get; set; }
        public Nullable<int> fk_city_id { get; set; }
        public Nullable<int> fk_area_id { get; set; }
    }
}
