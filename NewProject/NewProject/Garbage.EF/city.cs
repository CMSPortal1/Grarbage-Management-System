//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Garbage.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class city
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public city()
        {
            this.dumped_area = new HashSet<dumped_area>();
            this.vehiclesdetails = new HashSet<vehiclesdetail>();
        }
    
        public int city_id { get; set; }
        public string city1 { get; set; }
        public Nullable<System.DateTime> updated_on { get; set; }
        public Nullable<System.DateTime> created_on { get; set; }
        public string updated_by { get; set; }
        public string created_by { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dumped_area> dumped_area { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vehiclesdetail> vehiclesdetails { get; set; }
    }
}