//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Complaint
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
    
        public virtual garbage garbage { get; set; }
        public virtual signup signup { get; set; }
    }
}
