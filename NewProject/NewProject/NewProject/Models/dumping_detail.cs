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
    
    public partial class dumping_detail
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
    
        public virtual dumped_area dumped_area { get; set; }
        public virtual signup signup { get; set; }
        public virtual vehiclesdetail vehiclesdetail { get; set; }
    }
}
