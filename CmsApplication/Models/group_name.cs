//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CmsApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class group_name
    {
        public group_name()
        {
            this.subject_category = new HashSet<subject_category>();
        }
    
        public int department_id { get; set; }
        public string department_name { get; set; }
    
        public virtual ICollection<subject_category> subject_category { get; set; }
    }
}
