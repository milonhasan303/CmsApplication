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
    
    public partial class exam_type
    {
        public exam_type()
        {
            this.results = new HashSet<result>();
        }
    
        public int exam_type_id { get; set; }
        public string exam_type_name { get; set; }
    
        public virtual ICollection<result> results { get; set; }
    }
}
