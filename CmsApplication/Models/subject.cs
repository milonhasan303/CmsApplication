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
    
    public partial class subject
    {
        public subject()
        {
            this.student_selected_subject = new HashSet<student_selected_subject>();
        }
    
        public int subject_id { get; set; }
        public int subject_category_id { get; set; }
        public string subject_name { get; set; }
    
        public virtual ICollection<student_selected_subject> student_selected_subject { get; set; }
        public virtual subject_category subject_category { get; set; }
    }
}
