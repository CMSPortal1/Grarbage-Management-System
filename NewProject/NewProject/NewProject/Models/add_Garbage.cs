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
    
    public partial class add_Garbage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public add_Garbage()
        {
            this.garbages = new HashSet<garbage>();
        }
    
        public int G_id { get; set; }
        public string G_Type { get; set; }
        public string Updated_by { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Updated_On { get; set; }
        public Nullable<System.DateTime> Created_on { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<garbage> garbages { get; set; }
    }
}
