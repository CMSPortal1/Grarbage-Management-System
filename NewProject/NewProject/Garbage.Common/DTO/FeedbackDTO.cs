using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Common.DTO
{
   public class FeedbackDTO
    {
        public int FeedbackID { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<System.DateTime> UpdatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public string Review { get; set; }
        public Nullable<int> UserID { get; set; }
        public string rating { get; set; }

    }
}
